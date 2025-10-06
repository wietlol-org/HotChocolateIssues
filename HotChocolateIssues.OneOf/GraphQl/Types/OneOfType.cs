using System.Reflection;
using HotChocolate;
using HotChocolate.Types;

namespace HotChocolateIssues.OneOf.GraphQl.Types;

public class OneOfType<T> : InputObjectType<T>
{
    protected override void Configure(IInputObjectTypeDescriptor<T> descriptor)
    {
        descriptor.OneOf();

        var options = typeof(T).GetCustomAttribute<OneOfOptionsAttribute>();
        var types = options == null
            ? AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(it => !it.IsInterface)
                .Where(it => typeof(T).IsAssignableFrom(it))
                .ToArray()
            : options.Types;

        foreach (var optionsType in types)
        {
            descriptor
                .Field(FirstCharToLowerCase(optionsType.Name))
                .Type(optionsType);
        }

        descriptor.Extend().Definition.CreateInstance = objects =>
        {
            var nonNulls = objects.Where(it => it != null).ToList();
            if (nonNulls.Count == 1)
                return nonNulls[0]!;

            throw new InvalidOperationException($"GraphQl @oneOf directive did not produce a valid single object in the input. Number of objects provided: {nonNulls.Count}.");
        };
    }

    private static string FirstCharToLowerCase(string str)
    {
        if (!string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
            return str.Length == 1 ? char.ToLower(str[0]).ToString() : char.ToLower(str[0]) + str[1..];

        return str;
    }
}
