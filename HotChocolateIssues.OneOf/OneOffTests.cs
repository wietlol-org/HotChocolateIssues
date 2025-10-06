using HotChocolateIssues.TestBase;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using Snapshooter.Xunit;

namespace HotChocolateIssues.OneOf;

public class OneOffTests(
    WebApplicationFactory<Program> factory
) : TestHelper<Program>
{
    protected override WebApplicationFactory<Program> Factory { get; } = factory;

    [Fact]
    public async Task SchemaSnapshot()
    {
        Snapshot.Match(await GetSchema());
    }

    [Fact]
    // the issue is that the models for input and output in case of a polymorphic model are different.
    // the input model needs to have a wrapping structure with a property for each type, where only one property is set.
    // while the output uses an interface (or base class) and describes the type by __typename.
    // 
    // the issue is solved by creating the AutomaticOneOfAttribute.
    // which allows the input and output models to simply define an IModel property.
    // which is a one-of in the input.
    // and is a polymorphic type in the output.
    public async Task Person()
    {
        var content = await RunQuery("Person");

        var json = JObject.Parse(content);
        var pets = json.SelectTokens("$.data.person.pets[*]").ToList();

        Assert.Equal(2, pets.Count);

        var cat = pets[0];
        Assert.Equal("Cat", cat.SelectToken("__typename")?.Value<string>());
        Assert.Equal("Felix", cat.SelectToken("name")?.Value<string>());

        var dog = pets[1];
        Assert.Equal("Dog", dog.SelectToken("__typename")?.Value<string>());
        Assert.Equal("Cerberos", dog.SelectToken("name")?.Value<string>());
        Assert.Equal("Hotdog", dog.SelectToken("breed")?.Value<string>());
    }
}
