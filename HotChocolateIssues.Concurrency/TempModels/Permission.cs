using System;
using System.Collections.Generic;

namespace HotChocolateIssues.Concurrency.TempModels;

public class Permission
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Resource { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<RolePermission> RolePermissions { get; set; } = new();
}