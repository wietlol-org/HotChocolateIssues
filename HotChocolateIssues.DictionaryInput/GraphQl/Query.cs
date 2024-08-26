using HotChocolate;
using HotChocolate.Types;
using HotChocolateIssues.DictionaryInput.GraphQl.Types;
using HotChocolateIssues.DictionaryInput.Models;

namespace HotChocolateIssues.DictionaryInput.GraphQl;

public class Query
{
    [GraphQLType(typeof(AnyType))]
    public Dictionary<string, object?> TestBook(
        [GraphQLType(typeof(NonNullType<PartialType<Book>>))]
        Dictionary<string, object?> input
    )
    {
        return input;
    }
}
