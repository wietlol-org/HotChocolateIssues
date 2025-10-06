using System;
using System.Collections.Generic;

namespace HotChocolateIssues.Concurrency.TempModels;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal CostPrice { get; set; }
    public decimal Weight { get; set; }
    public string WeightUnit { get; set; } = string.Empty;
    public string Dimensions { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public string Material { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public string ManufacturerPartNumber { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public int StockQuantity { get; set; }
    public int ReorderLevel { get; set; }
    public int MaxStockLevel { get; set; }
    public bool IsActive { get; set; }
    public bool IsFeatured { get; set; }
    public bool IsDigital { get; set; }
    public bool RequiresShipping { get; set; }
    public bool IsTaxable { get; set; }
    public string TaxCategory { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DiscontinuedAt { get; set; }
    public string Tags { get; set; } = string.Empty;
    public string MetaTitle { get; set; } = string.Empty;
    public string MetaDescription { get; set; } = string.Empty;
    public string MetaKeywords { get; set; } = string.Empty;
    public double AverageRating { get; set; }
    public int ReviewCount { get; set; }
    public Category Category { get; set; } = null!;
    public List<ProductImage> Images { get; set; } = new();
    public List<ProductVariant> Variants { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
    public List<OrderItem> OrderItems { get; set; } = new();
}