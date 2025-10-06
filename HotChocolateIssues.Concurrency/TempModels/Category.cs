using System;
using System.Collections.Generic;

namespace HotChocolateIssues.Concurrency.TempModels;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string IconUrl { get; set; } = string.Empty;
    public int? ParentCategoryId { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; }
    public bool ShowInMenu { get; set; }
    public string MetaTitle { get; set; } = string.Empty;
    public string MetaDescription { get; set; } = string.Empty;
    public string MetaKeywords { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Path { get; set; } = string.Empty;
    public int Level { get; set; }
    public int ProductCount { get; set; }
    public string BannerImageUrl { get; set; } = string.Empty;
    public string FeaturedImageUrl { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public Category? ParentCategory { get; set; }
    public List<Category> SubCategories { get; set; } = new();
    public List<Product> Products { get; set; } = new();
}
