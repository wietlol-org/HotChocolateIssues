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
    // the issue is that when using typed dictionaries as input, the dictionary is filled with all the properties from the type.
    // while the goal is to only include the values that were included in the input, allowing us to know which values were set (explicitly to null)
    // and which properties were not present in the input data.
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
        Assert.Null(title); // title should be missing in the output because it is not included in the input
        Assert.Null(familyName); // familyName should be missing in the output because it is not included in the input
    }
}
