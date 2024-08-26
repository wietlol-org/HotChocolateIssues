namespace HotChocolateIssues.FilterUsage.Services;

public class FilterEngine
{
    public bool Matches(object? value, IDictionary<string, object?> filter)
    {
        return true;
    }
}
