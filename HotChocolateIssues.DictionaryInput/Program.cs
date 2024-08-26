using HotChocolateIssues.DictionaryInput.GraphQl;
using HotChocolateIssues.Web;
using Microsoft.Extensions.DependencyInjection;

namespace HotChocolateIssues.DictionaryInput;

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
