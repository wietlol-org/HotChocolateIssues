using System;

namespace HotChocolateIssues.Concurrency.TempInput;

public class OrderSearchInput
{
    public string? OrderNumber { get; set; }
    public int? CustomerId { get; set; }
    public string? Status { get; set; }
    public string? PaymentStatus { get; set; }
    public string? PaymentMethod { get; set; }
    public DateTime? OrderDateFrom { get; set; }
    public DateTime? OrderDateTo { get; set; }
    public DateTime? ShippingDateFrom { get; set; }
    public DateTime? ShippingDateTo { get; set; }
    public decimal? MinAmount { get; set; }
    public decimal? MaxAmount { get; set; }
    public string? Currency { get; set; }
    public string? ShippingCarrier { get; set; }
    public string? TrackingNumber { get; set; }
    public bool? IsGift { get; set; }
    public int? SalesRepId { get; set; }
    public string? Source { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public int? Skip { get; set; }
    public int? Take { get; set; }
    public string? SortBy { get; set; }
    public string? SortDirection { get; set; }
}