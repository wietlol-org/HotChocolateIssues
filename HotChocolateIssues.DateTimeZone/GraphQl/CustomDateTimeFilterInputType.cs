using HotChocolate.Data.Filters;

namespace HotChocolateIssues.DateTimeZone.GraphQl;

public sealed class CustomDateTimeFilterInputType : ComparableOperationFilterInputType<DateTimeOffset>;
