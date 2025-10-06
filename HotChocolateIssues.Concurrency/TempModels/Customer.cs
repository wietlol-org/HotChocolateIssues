using System;
using System.Collections.Generic;

namespace HotChocolateIssues.Concurrency.TempModels;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public decimal CreditLimit { get; set; }
    public decimal CurrentBalance { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public string CustomerType { get; set; } = string.Empty;
    public string PreferredLanguage { get; set; } = string.Empty;
    public string TimeZone { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public int? ManagerId { get; set; }
    public string Website { get; set; } = string.Empty;
    public string LinkedInProfile { get; set; } = string.Empty;
    public string TwitterHandle { get; set; } = string.Empty;
    public List<Order> Orders { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
    public List<SupportTicket> SupportTickets { get; set; } = new();
}
