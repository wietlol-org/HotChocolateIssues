using System;
using System.Collections.Generic;

namespace HotChocolateIssues.Concurrency.TempInput;

public class AnalyticsFilterInput
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? MetricType { get; set; }
    public string? Dimension { get; set; }
    public List<string>? Segments { get; set; }
    public List<int>? EntityIds { get; set; }
    public string? TimeGranularity { get; set; }
    public bool? IncludeComparisons { get; set; }
    public string? ComparisonPeriod { get; set; }
    public List<string>? Filters { get; set; }
    public int? Limit { get; set; }
    public string? SortBy { get; set; }
    public string? SortDirection { get; set; }
}
