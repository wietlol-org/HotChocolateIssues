using System;

namespace HotChocolateIssues.Concurrency.TempModels;

public class ReviewImage
{
    public int Id { get; set; }
    public int ReviewId { get; set; }
    public string Url { get; set; } = string.Empty;
    public string AltText { get; set; } = string.Empty;
    public string Caption { get; set; } = string.Empty;
    public int SortOrder { get; set; }
    public DateTime CreatedAt { get; set; }
    public Review Review { get; set; } = null!;
}