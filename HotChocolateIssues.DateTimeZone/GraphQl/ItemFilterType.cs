using HotChocolate.Data.Filters;

namespace HotChocolateIssues.DateTimeZone.GraphQl;

public class ItemFilterType : FilterInputType<Item>
{
    protected override void Configure(
        IFilterInputTypeDescriptor<Item> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Ignore(it => it.Name);
    }
}
