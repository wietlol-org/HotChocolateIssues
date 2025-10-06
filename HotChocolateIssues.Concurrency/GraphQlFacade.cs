using HotChocolate.Execution;
using HotChocolateIssues.Concurrency.GraphQl;
using Microsoft.Extensions.DependencyInjection;

namespace HotChocolateIssues.Concurrency;

public record GraphQlFacade(
    IRequestExecutorResolver RequestExecutorResolver
)
{
    public string GetSchema()
    {
        var executor = RequestExecutorResolver.GetRequestExecutorAsync().GetAwaiter().GetResult();
        var schema = executor.Schema;
        return schema.ToString();
    }

    public static GraphQlFacade Create()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<GraphQlFacade>();
        AddGraphQl(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();

        return serviceProvider.GetRequiredService<GraphQlFacade>();
    }

    private static void AddGraphQl(IServiceCollection services)
    {
        var graphqlAssembly = typeof(BookQueries).Assembly;

        services
            .AddGraphQl(
                graphqlAssembly
            );
    }
}
