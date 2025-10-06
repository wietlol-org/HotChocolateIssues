using System.Reflection;
using HotChocolate.AspNetCore;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;

namespace HotChocolateIssues.Concurrency;

public static class ServiceCollectionExtensions
{
    public static IRequestExecutorBuilder AddGraphQl(
        this IServiceCollection services,
        Assembly graphqlTypeAssembly,
        bool addRootTypes = true,
        bool addGraphQlTypesManually = false,
        bool? allowIntrospection = null,
        GraphQLServerOptions? graphqlServerOptions = null)
    {
        services.AddSingleton(graphqlServerOptions ?? new GraphQLServerOptions());
        var graphQlServer = services.AddGraphQLServer().InitializeOnStartup();

        if (addRootTypes) graphQlServer.AddQueryType(d => d.Name(OperationTypeNames.Query));

        if (!addGraphQlTypesManually) graphQlServer.AddGraphQlTypes(graphqlTypeAssembly, addRootTypes);

        return graphQlServer;
    }

    private static IRequestExecutorBuilder AddGraphQlTypes(
        this IRequestExecutorBuilder builder,
        Assembly assembly,
        bool addRootTypes = true)
    {
        var types = assembly.GetTypes().Where(q => q.GetCustomAttribute<ExtendObjectTypeAttribute>() != null)
            .ToList();

        if (addRootTypes && types.Any(x =>
            x.GetCustomAttribute<ExtendObjectTypeAttribute>()!.Name == OperationTypeNames.Mutation))
            builder.AddMutationType(d => d.Name(OperationTypeNames.Mutation));

        if (addRootTypes && types.Any(x =>
            x.GetCustomAttribute<ExtendObjectTypeAttribute>()!.Name == OperationTypeNames.Subscription))
            builder.AddSubscriptionType(d => d.Name(OperationTypeNames.Subscription));

        foreach (var type in types)
            builder.AddTypeExtension(type);

        return builder;
    }
}
