using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;

namespace HotChocolateIssues.Concurrency.TempInput;

public class ComplexSearchInput
{
    public string? Query { get; set; }
    public List<string>? SearchFields { get; set; }
    public List<FilterInput>? Filters { get; set; }
    public List<SortInput>? Sorting { get; set; }
    public PaginationInput? Pagination { get; set; }
    public List<string>? IncludeFields { get; set; }
    public List<string>? ExcludeFields { get; set; }
    public bool? FuzzySearch { get; set; }
    public double? MinScore { get; set; }
    public string? SearchType { get; set; }
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, object>? CustomFilters { get; set; }
}

public class FilterInput
{
    public string Field { get; set; } = string.Empty;
    public string Operator { get; set; } = string.Empty;
    public object? Value { get; set; }
    public List<object>? Values { get; set; }
}

public class SortInput
{
    public string Field { get; set; } = string.Empty;
    public string Direction { get; set; } = "ASC";
}

public class PaginationInput
{
    public int? Skip { get; set; }
    public int? Take { get; set; }
    public string? Cursor { get; set; }
}
