using System;

namespace HotChocolateIssues.Concurrency.TempModels;

public class UserRole
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public DateTime AssignedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public bool IsActive { get; set; }
    public User User { get; set; } = null!;
    public Role Role { get; set; } = null!;
}
