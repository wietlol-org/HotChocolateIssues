using HotChocolateIssues.DateTimeZone.GraphQl;
using HotChocolateIssues.Web;
using Microsoft.Extensions.DependencyInjection;

namespace HotChocolateIssues.DateTimeZone;

public class Program
{
    public static void Main(string[] args)
    {
        BaseProgram.Main(args, builder =>
        {
            builder.GraphQlServer
                .AddQueryType<Query>()
                .AddType<ItemFilterType>()
                .BindRuntimeType<DateTime, CustomDateTimeType>()
                .BindRuntimeType<DateTime?, CustomDateTimeType>()
                .BindRuntimeType<DateTimeOffset, CustomDateTimeType>()
                .BindRuntimeType<DateTimeOffset?, CustomDateTimeType>()
                .AddFiltering(
                    c => c
                        .AddDefaults()
                        .BindRuntimeType<DateTime, CustomDateTimeFilterInputType>()
                        .BindRuntimeType<DateTime?, CustomDateTimeFilterInputType>()
                        .BindRuntimeType<DateTimeOffset, CustomDateTimeFilterInputType>()
                        .BindRuntimeType<DateTimeOffset?, CustomDateTimeFilterInputType>()
                );
        });
    }
}
