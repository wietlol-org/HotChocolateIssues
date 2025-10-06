using HotChocolate;
using HotChocolateIssues.OneOf.GraphQl.Types;
using HotChocolateIssues.OneOf.Models;

namespace HotChocolateIssues.OneOf.GraphQl;

public class Query
{
    public Task<Person> PersonAsync(
        Person person
    ) =>
        Task.FromResult(person);
}
