using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;

namespace HotChocolateIssues.Concurrency.TempPayload;

public class ComplexSearchPayload<T>
{
    public List<T> Results { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageCount { get; set; }
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }
    public string? NextCursor { get; set; }
    public string? PreviousCursor { get; set; }
    public SearchMetadata Metadata { get; set; } = new();
    public List<Facet> Facets { get; set; } = new();
    public List<SearchSuggestion> Suggestions { get; set; } = new();
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, object> Aggregations { get; set; } = new();
}

public class SearchSuggestion
{
    public string Text { get; set; } = string.Empty;
    public double Score { get; set; }
    public string Type { get; set; } = string.Empty;
}
