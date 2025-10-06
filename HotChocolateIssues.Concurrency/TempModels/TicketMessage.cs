using System;

namespace HotChocolateIssues.Concurrency.TempModels;

public class TicketMessage
{
    public int Id { get; set; }
    public int TicketId { get; set; }
    public int? UserId { get; set; }
    public int? CustomerId { get; set; }
    public string Content { get; set; } = string.Empty;
    public string MessageType { get; set; } = string.Empty;
    public bool IsInternal { get; set; }
    public bool IsSystemMessage { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ReadAt { get; set; }
    public SupportTicket Ticket { get; set; } = null!;
    public User? User { get; set; }
    public Customer? Customer { get; set; }
}
