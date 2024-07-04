using HotChocolateIssues.TestBase;
using Microsoft.AspNetCore.Mvc.Testing;
using Snapshooter.Xunit;

namespace HotChocolateIssues.InvalidFilterType;

public class InvalidFilterTypeTests(
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
    public async Task DeleteBooks()
    {
        var content = await RunQuery("DeleteBooks");

        // the result of the DeleteBooks mutation is the filter that was sent as input,
        // which should be { title: { eq: "Test" } }
        Assert.Contains(content, "\"deleteBooks\":\"{\\\"title\\\":{\\\"eq\\\":\\\"Test\\\"}}\"");
    }
}
