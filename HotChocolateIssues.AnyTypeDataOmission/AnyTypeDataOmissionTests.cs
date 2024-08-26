using HotChocolateIssues.TestBase;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using Snapshooter.Xunit;
using Xunit.Abstractions;

namespace HotChocolateIssues.AnyTypeDataOmission;

public class AnyTypeDataOmissionTests(
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
    public async Task GetBooks()
    {
        var content = await RunQuery("Books");

        var json = JObject.Parse(content);
        var books = json.SelectTokens("$.data.books[*]").ToList();
        var booksAny = json.SelectTokens("$.data.booksAny[*]").ToList();

        for (int index = 0; index < books.Count; index++)
        {
            var book = books[index];

            AssertBookContainsValues(nameof(books), index, book);
        }

        for (int index = 0; index < booksAny.Count; index++)
        {
            var book = booksAny[index];

            AssertBookContainsValues(nameof(booksAny), index, book);
        }
    }

    private static void AssertBookContainsValues(string collectionName, int index, JToken book)
    {
        var title = book.SelectToken("title")?.ToString();
        var authorName = book.SelectToken("author.name")?.ToString();

        if (string.IsNullOrEmpty(title))
            Assert.Fail($"{collectionName}[{index}].title is null");
        if (string.IsNullOrEmpty(authorName))
            Assert.Fail($"{collectionName}[{index}].author.name is null");
    }
}
