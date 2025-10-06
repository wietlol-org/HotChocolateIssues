using System;
using System.Collections.Generic;

namespace HotChocolateIssues.Concurrency.TempModels;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public string ProfileImageUrl { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public int? ManagerId { get; set; }
    public DateTime HireDate { get; set; }
    public decimal? Salary { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public bool IsEmailVerified { get; set; }
    public bool IsPhoneVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public DateTime? LastPasswordChangeAt { get; set; }
    public int FailedLoginAttempts { get; set; }
    public DateTime? LockedOutUntil { get; set; }
    public string TimeZone { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string Theme { get; set; } = string.Empty;
    public string NotificationPreferences { get; set; } = string.Empty;
    public string TwoFactorSecret { get; set; } = string.Empty;
    public bool IsTwoFactorEnabled { get; set; }
    public User? Manager { get; set; }
    public List<User> DirectReports { get; set; } = new();
    public List<UserRole> UserRoles { get; set; } = new();
    public List<SupportTicket> AssignedTickets { get; set; } = new();
    public List<UserSession> Sessions { get; set; } = new();
}