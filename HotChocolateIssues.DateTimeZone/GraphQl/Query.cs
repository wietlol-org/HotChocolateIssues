using HotChocolate;
using HotChocolateIssues.DateTimeZone.Models;

namespace HotChocolateIssues.DateTimeZone.GraphQl;

public class Query
{
    [UseFiltering]
    public IExecutable<Item> Items() =>
        new List<Item>().AsExecutable();

    public OutputDateTime TestDateTime(
        InputDateTime input
    ) =>
        new(
            input.DateTimes,
            input.DateTimes
                .ConvertAll(it => it.ToString("O"))
        );

    public OutputDateTimeOffset TestDateTimeOffset(
        InputDateTimeOffset input
    ) =>
        new(
            input.DateTimes,
            input.DateTimes
                .ConvertAll(it => it.ToString("O"))
        );
}
