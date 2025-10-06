using System.Collections.Generic;
using HotChocolateIssues.Concurrency.TempModels;

namespace HotChocolateIssues.Concurrency.TempPayload;

public class ProductSearchPayload
{
    public List<Product> Products { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageCount { get; set; }
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }
    public SearchMetadata Metadata { get; set; } = new();
    public List<Facet> Facets { get; set; } = new();
    public PriceRange PriceRange { get; set; } = new();
    public List<string> AvailableBrands { get; set; } = new();
    public List<string> AvailableCategories { get; set; } = new();
}

public class PriceRange
{
    public decimal Min { get; set; }
    public decimal Max { get; set; }
    public decimal Average { get; set; }
}