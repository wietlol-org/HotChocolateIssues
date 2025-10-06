using HotChocolateIssues.OneOf.GraphQl.Types;

namespace HotChocolateIssues.OneOf.Models;

public record Person(
    string Name,
    [property: AutomaticOneOf]
    List<IPet> Pets
);
