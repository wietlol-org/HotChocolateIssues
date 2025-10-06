using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;

namespace HotChocolateIssues.Concurrency.TempInput;

public class BulkOperationInput
{
    public List<int> EntityIds { get; set; } = new();
    public string Operation { get; set; } = string.Empty;
    [GraphQLType<NonNullType<AnyType>>]
    public Dictionary<string, object>? Parameters { get; set; }
    public bool ValidateBeforeOperation { get; set; }
    public bool ContinueOnError { get; set; }
    public int? BatchSize { get; set; }
    public bool ReturnResults { get; set; }
    public string? NotificationEmail { get; set; }
}
