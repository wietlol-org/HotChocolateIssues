using System;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;

namespace HotChocolateIssues.Concurrency.TempPayload;

public class ReportPayload
{
    public string ReportId { get; set; } = string.Empty;
    public string ReportName { get; set; } = string.Empty;
    public DateTime GeneratedAt { get; set; }
    public TimeSpan GenerationTime { get; set; }
    public List<ReportData> Data { get; set; } = new();
    public ReportSummary Summary { get; set; } = new();
    public List<ChartData> Charts { get; set; } = new();
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, object> Metadata { get; set; } = new();
}

public class ReportData
{
    public string Category { get; set; } = string.Empty;
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, object> Values { get; set; } = new();
    public DateTime? Date { get; set; }
    public string? Label { get; set; }
}

public class ReportSummary
{
    public int TotalRecords { get; set; }
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, decimal> Totals { get; set; } = new();
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, double> Averages { get; set; } = new();
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, int> Counts { get; set; } = new();
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, object> CustomMetrics { get; set; } = new();
}

public class ChartData
{
    public string ChartType { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public List<string> Labels { get; set; } = new();
    public List<ChartSeries> Series { get; set; } = new();
}

public class ChartSeries
{
    public string Name { get; set; } = string.Empty;
    public List<double> Data { get; set; } = new();
    public string Color { get; set; } = string.Empty;
}
