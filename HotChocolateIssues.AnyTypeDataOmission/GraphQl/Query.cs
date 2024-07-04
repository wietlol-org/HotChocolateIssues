using HotChocolate;
using HotChocolate.Types;
using HotChocolateIssues.AnyTypeDataOmission.Models;

namespace HotChocolateIssues.AnyTypeDataOmission.GraphQl;

public class Query
{
    [GraphQLType<AnyType>]
    public List<Book> GetBooksAny() =>
        GetBooks();

    public List<Book> GetBooks() =>
    [
        new Book(
            Title: "C# for dummies",
            Author: new Author(
                Name: "Jon Skeet"
            )
        ),
        new Book(
            Title: "Hot Chocolate: A .NET GraphQl server",
            Author: new Author(
                Name: "Michael Staib"
            )
        ),
        new Book(
            Title: "C# in depth.",
            Author: new Author(
                Name: "Jon Skeet"
            )
        ),
    ];
}
