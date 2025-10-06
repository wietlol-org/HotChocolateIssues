using HotChocolateIssues.OneOf.GraphQl;
using HotChocolateIssues.OneOf.GraphQl.Types;
using HotChocolateIssues.OneOf.Models;
using HotChocolateIssues.Web;
using Microsoft.Extensions.DependencyInjection;

namespace HotChocolateIssues.OneOf;

public class Program
{
    public static void Main(string[] args)
    {
        BaseProgram.Main(args, builder =>
        {
            builder.GraphQlServer
                .AddQueryType<Query>()
                .ModifyOptions(o => o.EnableOneOf = true)
                .AddType<Dog>()
                .AddType<Cat>();
        });
    }
}
