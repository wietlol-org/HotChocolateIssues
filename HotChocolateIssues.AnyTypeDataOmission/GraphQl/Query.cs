using HotChocolate;
using HotChocolate.Types;
using HotChocolateIssues.AnyTypeDataOmission.Models;

namespace HotChocolateIssues.AnyTypeDataOmission.GraphQl;

public class Query
{
    [GraphQLType<AnyType>]
    public List<Book> GetBooksAny() =>
        GetBooks();

    public List<Book> GetBooks()
    {
        var jonSkeet = new Author(
            Name: "Jon Skeet"
        );
        var michaelStaib = new Author(
            Name: "Michael Staib"
        );
        
        return
        [
            new Book(
                Title: "C# for dummies",
                Author: jonSkeet
            ),
            new Book(
                Title: "Hot Chocolate: A .NET GraphQl server",
                Author: michaelStaib
            ),
            new Book(
                Title: "C# in depth.",
                Author: jonSkeet
            ),
        ];
    }
}
