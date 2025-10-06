using System;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;

namespace HotChocolateIssues.Concurrency.TempPayload;

public class BulkOperationPayload
{
    public string OperationId { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public TimeSpan? Duration { get; set; }
    public int TotalItems { get; set; }
    public int ProcessedItems { get; set; }
    public int SuccessfulItems { get; set; }
    public int FailedItems { get; set; }
    public int SkippedItems { get; set; }
    public double ProgressPercentage { get; set; }
    public List<BulkOperationResult> Results { get; set; } = new();
    public List<BulkOperationError> Errors { get; set; } = new();
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, object> Summary { get; set; } = new();
}

public class BulkOperationResult
{
    public int EntityId { get; set; }
    public string Status { get; set; } = string.Empty;
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, object>? Data { get; set; }
    public string? Message { get; set; }
}

public class BulkOperationError
{
    public int EntityId { get; set; }
    public string ErrorCode { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, object>? ErrorDetails { get; set; }
}
