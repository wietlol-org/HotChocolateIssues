using System;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;

namespace HotChocolateIssues.Concurrency.TempPayload;

public class AnalyticsPayload
{
    public string AnalyticsId { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string MetricType { get; set; } = string.Empty;
    public List<AnalyticsDataPoint> DataPoints { get; set; } = new();
    public AnalyticsSummary Summary { get; set; } = new();
    public List<Insight> Insights { get; set; } = new();
    public ComparisonData? Comparison { get; set; }
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, object> Metadata { get; set; } = new();
}

public class AnalyticsDataPoint
{
    public DateTime Timestamp { get; set; }
    public string Dimension { get; set; } = string.Empty;
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, double> Metrics { get; set; } = new();
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, string> Properties { get; set; } = new();
}

public class AnalyticsSummary
{
    public double TotalValue { get; set; }
    public double AverageValue { get; set; }
    public double MinValue { get; set; }
    public double MaxValue { get; set; }
    public double PercentChange { get; set; }
    public string Trend { get; set; } = string.Empty;
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, double> Segments { get; set; } = new();
}

public class Insight
{
    public string Type { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Impact { get; set; }
    public string Severity { get; set; } = string.Empty;
    public List<string> Recommendations { get; set; } = new();
}

public class ComparisonData
{
    public DateTime PreviousStartDate { get; set; }
    public DateTime PreviousEndDate { get; set; }
    public double PreviousValue { get; set; }
    public double PercentChange { get; set; }
    public string ChangeDirection { get; set; } = string.Empty;
}
