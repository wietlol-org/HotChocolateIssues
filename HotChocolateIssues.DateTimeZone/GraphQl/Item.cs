namespace HotChocolateIssues.DateTimeZone.GraphQl;

public record Item(
    string Name,
    DateTime CreatedAt,
    DateTimeOffset CreatedAtZoned,
    DateTime? CreatedAt2,
    DateTimeOffset? CreatedAtZoned2
);
