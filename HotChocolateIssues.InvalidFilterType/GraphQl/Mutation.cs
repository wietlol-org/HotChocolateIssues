using HotChocolate;
using HotChocolate.Data.Filters;
using HotChocolateIssues.InvalidFilterType.Models;
using Newtonsoft.Json;

namespace HotChocolateIssues.InvalidFilterType.GraphQl;

public class Mutation
{
    public string DeleteBooks(
        [GraphQLType(typeof(FilterInputType<Book>))]
        IDictionary<string, object?> filter
    )
    {
        return JsonConvert.SerializeObject(filter);
    }
}
