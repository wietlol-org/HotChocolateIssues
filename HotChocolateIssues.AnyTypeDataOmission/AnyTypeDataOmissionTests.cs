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
    // issue solved in HotChocolate@14.0.0-p.139
    // issue used to be that with the "any" types, the values that have already been included in the output were omitted.
    // so in the case of authors for multiple books, the author would only be included for the first book in the output.
    // if multiple authors are in the result, it would be impossible to deduce which author is for the remaining books.
    // e.g.:
    // books: [
    //   {title: "C# for dummies", author: {name: "Jon Skeet"}},
    //   {title: "Hot Chocolate: A .NET GraphQl server", author: {name: "Michael Staib"}},
    //   {title: "C# in depth."} // impossible to know who the author is
    // ]
    // this is more obvious when using records, as they are often implemented with value-equality
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
