using HotChocolate;
using HotChocolate.Data.Filters;
using HotChocolate.Types;
using HotChocolateIssues.FilterUsage.Models;
using HotChocolateIssues.FilterUsage.Services;

namespace HotChocolateIssues.FilterUsage.GraphQl;

public class Query
{
    public List<Book> TestFilter(
        [GraphQLType(typeof(NonNullType<FilterInputType<Book>>))]
        Dictionary<string, object?> filter
    )
    {
        var engine = new FilterEngine();
        var books = Book.All
            .Where(book => engine.Matches(book, filter))
            .ToList();

        return books;
    }
}
