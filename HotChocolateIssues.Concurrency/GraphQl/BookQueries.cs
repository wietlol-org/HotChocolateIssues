using HotChocolateIssues.Concurrency.Models;

namespace HotChocolateIssues.Concurrency.GraphQl;

public class BookQueries
{
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
