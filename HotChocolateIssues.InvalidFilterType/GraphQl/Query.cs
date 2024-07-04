using HotChocolateIssues.InvalidFilterType.Models;

namespace HotChocolateIssues.InvalidFilterType.GraphQl;

public class Query
{
    [UseFiltering]
    public Book GetBook() =>
        new(
            Title: "C# in depth.",
            Author: new Author(
                Name: "Jon Skeet",
                FamilyName: null
            )
        );
}
