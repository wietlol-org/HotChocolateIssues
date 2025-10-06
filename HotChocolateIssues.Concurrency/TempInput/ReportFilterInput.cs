using System;
using System.Collections.Generic;

namespace HotChocolateIssues.Concurrency.TempInput;

public class ReportFilterInput
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public List<int>? CategoryIds { get; set; }
    public List<string>? Brands { get; set; }
    public List<string>? Countries { get; set; }
    public List<string>? States { get; set; }
    public List<string>? CustomerTypes { get; set; }
    public List<string>? OrderStatuses { get; set; }
    public List<string>? PaymentMethods { get; set; }
    public decimal? MinOrderValue { get; set; }
    public decimal? MaxOrderValue { get; set; }
    public bool? IncludeRefunded { get; set; }
    public bool? IncludeCancelled { get; set; }
    public string? Currency { get; set; }
    public string? GroupBy { get; set; }
    public string? AggregationType { get; set; }
}