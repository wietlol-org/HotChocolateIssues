using System.Collections;
using System.Reflection;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace HotChocolateIssues.OneOf.GraphQl.Types;

public class AutomaticOneOfAttribute : InputFieldDescriptorAttribute
{
    protected override void OnConfigure(IDescriptorContext context, IInputFieldDescriptor descriptor, MemberInfo member)
    {
        if (member is not PropertyInfo property)
            throw new InvalidOperationException("Cannot determine nullability of a non-property GraphQl field.");

        descriptor.Type(GetFieldType(property));
    }

    private static IInputType GetFieldType(PropertyInfo property)
    {
        var context = NullabilityContext.Create(property);
        return context.WriteState is NullabilityState.Nullable
            ? GetFieldTypeRoot(property, context)
            : new NonNullType(GetFieldTypeRoot(property, context));
    }

    private static IInputType GetFieldTypeRoot(PropertyInfo property, NullabilityInfo context) =>
        property.PropertyType.IsAssignableTo(typeof(IEnumerable))
            ? new ListType(GetFieldElementType(property, context))
            : CreateOneOfType(property.PropertyType);

    private static IInputType GetFieldElementType(PropertyInfo property, NullabilityInfo context) =>
        context.GenericTypeArguments[0].WriteState is NullabilityState.Nullable
            ? CreateOneOfType(property.PropertyType.GenericTypeArguments[0])
            : new NonNullType(CreateOneOfType(property.PropertyType.GenericTypeArguments[0]));

    private static IInputType CreateOneOfType(Type type) =>
        (IInputType) typeof(AutomaticOneOfAttribute)
            .GetMethod(nameof(CreateOneOfTypeGeneric), BindingFlags.Static | BindingFlags.NonPublic)!
            .MakeGenericMethod(type)
            .Invoke(null, [])!;

    private static IInputType CreateOneOfTypeGeneric<T>() =>
        new OneOfType<T>();

    private static NullabilityInfoContext NullabilityContext { get; } = new();
}
