namespace HotChocolateIssues.OneOf.GraphQl.Types;

[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class)]
public class OneOfOptionsAttribute(
    Type[] types
) : Attribute
{
    public Type[] Types { get; } = types;
}
