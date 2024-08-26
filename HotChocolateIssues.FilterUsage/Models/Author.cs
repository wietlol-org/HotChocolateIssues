namespace HotChocolateIssues.FilterUsage.Models;

public record Author(
    string Name,
    string? FamilyName
)
{
    public static Author JonSkeet { get; } = new(
        Name: "Jon",
        FamilyName: "Skeet"
    );
    public static Author MichaelStaib { get; } = new(
        Name: "Michael",
        FamilyName: "Staib"
    );
}
