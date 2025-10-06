using System;

namespace HotChocolateIssues.Concurrency.TempModels;

public class ReviewVote
{
    public int Id { get; set; }
    public int ReviewId { get; set; }
    public int CustomerId { get; set; }
    public bool IsHelpful { get; set; }
    public DateTime CreatedAt { get; set; }
    public Review Review { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
}