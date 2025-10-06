using System;
using System.Collections.Generic;

namespace HotChocolateIssues.Concurrency.TempModels;

public class Review
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int? OrderId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Rating { get; set; }
    public bool IsVerifiedPurchase { get; set; }
    public bool IsRecommended { get; set; }
    public string Pros { get; set; } = string.Empty;
    public string Cons { get; set; } = string.Empty;
    public int HelpfulVotes { get; set; }
    public int NotHelpfulVotes { get; set; }
    public string Status { get; set; } = string.Empty;
    public string ModeratorNotes { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? ModeratedAt { get; set; }
    public string ReviewerName { get; set; } = string.Empty;
    public string ReviewerLocation { get; set; } = string.Empty;
    public bool IsAnonymous { get; set; }
    public string Source { get; set; } = string.Empty;
    public string ExternalId { get; set; } = string.Empty;
    public Customer Customer { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public Order? Order { get; set; }
    public List<ReviewImage> Images { get; set; } = new();
    public List<ReviewVote> Votes { get; set; } = new();
}