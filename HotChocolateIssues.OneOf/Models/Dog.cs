namespace HotChocolateIssues.OneOf.Models;

public record Dog(
    string Name,
    string Breed
) : IPet;
