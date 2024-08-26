using HotChocolate.Execution.Configuration;
using HotChocolateIssues.Web.Services;
using Microsoft.AspNetCore.Diagnostics;

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

        var logger = new GraphQlLogger();
        var graphQlServer = builder.Services
            .AddGraphQLServer()
            .AddDiagnosticEventListener(_ => logger);

        onBuild(new BuilderData(builder, graphQlServer));

        var app = builder.Build();

        app.MapGraphQL();

        app.UseExceptionHandler(exceptionHandlerApp =>
        {
            exceptionHandlerApp.Run(context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()!
                    .Error;
                var response = new { error = exception.Message };
                logger.GenericError(exception);
                
                return Task.CompletedTask;
            });
        });
        app.Run();
    }

    public record BuilderData(
        WebApplicationBuilder Builder,
        IRequestExecutorBuilder GraphQlServer
    );
}
