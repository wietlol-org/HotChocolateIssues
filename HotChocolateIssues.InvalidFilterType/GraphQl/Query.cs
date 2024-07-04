using HotChocolateIssues.InvalidFilterType.Models;

namespace HotChocolateIssues.InvalidFilterType.GraphQl;

public class Query
{
    public Book GetBook() =>
        new(
            Title: "C# in depth.",
            Author: new Author(
                Name: "Jon Skeet"
            )
        );
}
