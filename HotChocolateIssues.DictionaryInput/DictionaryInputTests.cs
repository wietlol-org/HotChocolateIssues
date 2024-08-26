using HotChocolateIssues.TestBase;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using Snapshooter.Xunit;

namespace HotChocolateIssues.DictionaryInput;

public class DictionaryInputTests(
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
    public async Task TestBook()
    {
        var content = await RunQuery("TestBook");
        
        var json = JObject.Parse(content);
        var book = json.SelectToken("data.testBook");
        var title = book?.SelectToken("title");
        var author = book?.SelectToken("author");
        var name = author?.SelectToken("name");
        var familyName = author?.SelectToken("familyName");

        Assert.NotNull(book);
        Assert.NotNull(author);
        Assert.NotNull(name);
        Assert.Equal("Michael", name.Value<string>());
        Assert.Null(title); // title should be missing in the output
        Assert.Null(familyName); // familyName should be missing in the output
    }
}
