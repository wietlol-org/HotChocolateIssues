using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;
using HotChocolateIssues.Concurrency.TempModels;

namespace HotChocolateIssues.Concurrency.TempPayload;

public class OrderSearchPayload
{
    public List<Order> Orders { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageCount { get; set; }
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }
    public SearchMetadata Metadata { get; set; } = new();
    public OrderSummary Summary { get; set; } = new();
    public List<Facet> Facets { get; set; } = new();
}

public class OrderSummary
{
    public decimal TotalValue { get; set; }
    public decimal AverageOrderValue { get; set; }
    public int TotalItems { get; set; }
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, int> StatusCounts { get; set; } = new();
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, decimal> PaymentMethodTotals { get; set; } = new();
}
