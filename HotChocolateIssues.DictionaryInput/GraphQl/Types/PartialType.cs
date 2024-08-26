using System.Reflection;
using HotChocolate.Types;
using static HotChocolateIssues.DictionaryInput.GraphQl.Types.PartialTypeHelper;

namespace HotChocolateIssues.DictionaryInput.GraphQl.Types;

public class PartialType<T> : InputObjectType
{
    protected override void Configure(IInputObjectTypeDescriptor descriptor)
    {
        var type = typeof(T);

        var name = $"{type.Name}Partial";
        descriptor.Name(name);

        foreach (var property in type.GetProperties())
        {
            descriptor
                .Field(CamelCase(property.Name))
                .Type(GetPropertyType(property)
                );
        }
    }
}

public class PartialTypeHelper
{
    public static string CamelCase(string name) =>
        char.ToLowerInvariant(name[0]) + name[1..];

    public static Type GetPropertyType(PropertyInfo property)
    {
        var type = property.PropertyType;
        if (type.IsPrimitive)
            return type;
        if (type == typeof(string))
            return type;

//        return typeof(AnyType);

        var newType = typeof(PartialTypeHelper)
            .GetMethod(nameof(GetPartialType), BindingFlags.NonPublic | BindingFlags.Static)!
            .MakeGenericMethod(type)
            .Invoke(null, [])!;
        return (Type) newType;
    }

    private static Type GetPartialType<T>()
    {
        return typeof(PartialType<T>);
    }
}
