using HotChocolate.Execution.Configuration;

namespace HotChocolateIssues.Web;

public class BaseProgram
{
    public static void Main(string[] args)
    {
        Main(args, _ => {});
    }
    
    public static void Main(string[] args, Action<BuilderData> onBuild)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        var graphQlServer = builder.Services
            .AddGraphQLServer();

        onBuild(new BuilderData(builder, graphQlServer));

        var app = builder.Build();

        app.MapGraphQL();

        app.Run();
    }

    public record BuilderData(
        WebApplicationBuilder Builder,
        IRequestExecutorBuilder GraphQlServer
    );
}
