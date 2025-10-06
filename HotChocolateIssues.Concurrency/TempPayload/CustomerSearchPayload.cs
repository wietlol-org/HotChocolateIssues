using System;
using System.Collections.Generic;
using HotChocolateIssues.Concurrency.TempModels;

namespace HotChocolateIssues.Concurrency.TempPayload;

public class CustomerSearchPayload
{
    public List<Customer> Customers { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageCount { get; set; }
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }
    public SearchMetadata Metadata { get; set; } = new();
    public List<Facet> Facets { get; set; } = new();
}

public class SearchMetadata
{
    public TimeSpan ExecutionTime { get; set; }
    public string Query { get; set; } = string.Empty;
    public int FilterCount { get; set; }
    public int SortCount { get; set; }
    public DateTime SearchTimestamp { get; set; }
    public string SearchId { get; set; } = string.Empty;
}

public class Facet
{
    public string Field { get; set; } = string.Empty;
    public List<FacetValue> Values { get; set; } = new();
}

public class FacetValue
{
    public string Value { get; set; } = string.Empty;
    public int Count { get; set; }
    public bool IsSelected { get; set; }
}