using HotChocolateIssues.InvalidFilterType.GraphQl;
using HotChocolateIssues.Web;
using Microsoft.Extensions.DependencyInjection;

namespace HotChocolateIssues.InvalidFilterType;

public class Program
{
    public static void Main(string[] args)
    {
        BaseProgram.Main(args, builder =>
        {
            builder.GraphQlServer
                .AddFiltering()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();
        });
    }
}
