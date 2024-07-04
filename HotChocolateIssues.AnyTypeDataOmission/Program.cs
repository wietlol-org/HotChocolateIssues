using HotChocolateIssues.AnyTypeDataOmission.GraphQl;
using HotChocolateIssues.Web;
using Microsoft.Extensions.DependencyInjection;

namespace HotChocolateIssues.AnyTypeDataOmission;

public class Program
{
    public static void Main(string[] args)
    {
        BaseProgram.Main(args, builder =>
        {
            builder.GraphQlServer
                .AddQueryType<Query>();
        });
    }
}
