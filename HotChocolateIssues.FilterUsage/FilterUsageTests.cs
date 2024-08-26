using HotChocolateIssues.TestBase;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using Snapshooter.Xunit;

namespace HotChocolateIssues.FilterUsage;

public class FilterUsageTests(
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
    public async Task TestFilter()
    {
        var content = await RunQuery("TestFilter");
        
        var json = JObject.Parse(content);
        var titles = json
            .SelectTokens("$.data.testFilter[*].title")
            .Select(it => it.Value<string>()!)
            .ToList();
        
        Assert.Equal("C# for dummies", titles[0]);
        Assert.Equal("C# in depth", titles[1]);
        Assert.Equal(2, titles.Count);
    }
}
