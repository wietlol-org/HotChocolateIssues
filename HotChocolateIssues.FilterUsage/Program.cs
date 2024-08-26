using HotChocolateIssues.FilterUsage.GraphQl;
using HotChocolateIssues.Web;
using Microsoft.Extensions.DependencyInjection;

namespace HotChocolateIssues.FilterUsage;

public class Program
{
    public static void Main(string[] args)
    {
        BaseProgram.Main(args, builder =>
        {
            builder.GraphQlServer
                .AddFiltering()
                .AddQueryType<Query>();
        });
    }
}
