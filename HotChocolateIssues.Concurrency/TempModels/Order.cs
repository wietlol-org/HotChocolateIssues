using System;
using System.Collections.Generic;

namespace HotChocolateIssues.Concurrency.TempModels;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public DateTime? ShippingDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal SubTotal { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string PaymentStatus { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public string ShippingAddress { get; set; } = string.Empty;
    public string BillingAddress { get; set; } = string.Empty;
    public string TrackingNumber { get; set; } = string.Empty;
    public string ShippingCarrier { get; set; } = string.Empty;
    public string ShippingMethod { get; set; } = string.Empty;
    public string SpecialInstructions { get; set; } = string.Empty;
    public bool IsGift { get; set; }
    public string GiftMessage { get; set; } = string.Empty;
    public int? SalesRepId { get; set; }
    public string Source { get; set; } = string.Empty;
    public string CampaignCode { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Customer Customer { get; set; } = null!;
    public List<OrderItem> OrderItems { get; set; } = new();
    public List<OrderStatusHistory> StatusHistory { get; set; } = new();
}
