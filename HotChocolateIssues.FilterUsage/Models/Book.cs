namespace HotChocolateIssues.FilterUsage.Models;

public record Book(
    string Title,
    Author Author
)
{
    public static Book CSharpForDummies { get; } = new(
        Title: "C# for dummies",
        Author: Author.JonSkeet
    );

    public static Book HotChocolate { get; } = new(
        Title: "Hot Chocolate: A .NET GraphQl server",
        Author: Author.MichaelStaib
    );

    public static Book CSharpInDepth { get; } = new(
        Title: "C# in depth",
        Author: Author.JonSkeet
    );

    public static List<Book> All =>
    [
        CSharpForDummies,
        HotChocolate,
        CSharpInDepth,
    ];
}
