namespace HotChocolateIssues.FilterUsage.Models;

public class Mutation
{
    
}

public record Contact(
    List<Address> Addresses
);

public record Address(
    List<AddressType> Type,
    string PostalCode
);

public enum AddressType
{
    Office,
    Postal,
}
