using System;

namespace HotChocolateIssues.Concurrency.TempModels;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int? ProductVariantId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductSKU { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public string DiscountType { get; set; } = string.Empty;
    public string DiscountCode { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public bool IsGift { get; set; }
    public string GiftWrapType { get; set; } = string.Empty;
    public decimal GiftWrapCost { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Order Order { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public ProductVariant? ProductVariant { get; set; }
}