using System;
using System.Collections.Generic;

namespace HotChocolateIssues.Concurrency.TempInput;

public class ProductSearchInput
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? SKU { get; set; }
    public string? Brand { get; set; }
    public string? Manufacturer { get; set; }
    public int? CategoryId { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int? MinStock { get; set; }
    public int? MaxStock { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsFeatured { get; set; }
    public bool? IsDigital { get; set; }
    public bool? RequiresShipping { get; set; }
    public double? MinRating { get; set; }
    public string? Color { get; set; }
    public string? Size { get; set; }
    public string? Material { get; set; }
    public List<string>? Tags { get; set; }
    public DateTime? CreatedAfter { get; set; }
    public DateTime? CreatedBefore { get; set; }
    public int? Skip { get; set; }
    public int? Take { get; set; }
    public string? SortBy { get; set; }
    public string? SortDirection { get; set; }
}