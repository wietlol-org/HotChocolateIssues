using System;
using System.Collections.Generic;

namespace HotChocolateIssues.Concurrency.TempModels;

public class SupportTicket
{
    public int Id { get; set; }
    public string TicketNumber { get; set; } = string.Empty;
    public int CustomerId { get; set; }
    public int? AssignedToUserId { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string SubCategory { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string Resolution { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public DateTime? ClosedAt { get; set; }
    public DateTime? FirstResponseAt { get; set; }
    public TimeSpan? ResponseTime { get; set; }
    public TimeSpan? ResolutionTime { get; set; }
    public string Tags { get; set; } = string.Empty;
    public bool IsEscalated { get; set; }
    public DateTime? EscalatedAt { get; set; }
    public string EscalationReason { get; set; } = string.Empty;
    public double? SatisfactionRating { get; set; }
    public string SatisfactionFeedback { get; set; } = string.Empty;
    public Customer Customer { get; set; } = null!;
    public User? AssignedToUser { get; set; }
    public List<TicketMessage> Messages { get; set; } = new();
    public List<TicketAttachment> Attachments { get; set; } = new();
}