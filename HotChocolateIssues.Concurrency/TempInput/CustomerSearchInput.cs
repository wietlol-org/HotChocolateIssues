using System;

namespace HotChocolateIssues.Concurrency.TempInput;

public class CustomerSearchInput
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? CustomerType { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public decimal? MinCreditLimit { get; set; }
    public decimal? MaxCreditLimit { get; set; }
    public DateTime? CreatedAfter { get; set; }
    public DateTime? CreatedBefore { get; set; }
    public bool? IsActive { get; set; }
    public bool? HasOrders { get; set; }
    public bool? HasReviews { get; set; }
    public int? Skip { get; set; }
    public int? Take { get; set; }
    public string? SortBy { get; set; }
    public string? SortDirection { get; set; }
}