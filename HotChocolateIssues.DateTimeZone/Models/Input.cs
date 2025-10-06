namespace HotChocolateIssues.DateTimeZone.Models;

public record InputDateTime(
    List<DateTime> DateTimes
);

public record OutputDateTime(
    List<DateTime> DateTimes,
    List<string> Texts
);

public record InputDateTimeOffset(
    List<DateTimeOffset> DateTimes
);

public record OutputDateTimeOffset(
    List<DateTimeOffset> DateTimes,
    List<string> Texts
);
