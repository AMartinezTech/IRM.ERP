namespace IRM.Infrastructure.Supabase.Organization.Users;

using global::Supabase.Postgrest.Attributes;
using global::Supabase.Postgrest.Models;
using System;


[Table("users")]
public class UserModel : BaseModel
{
    [PrimaryKey("id", false)]
    public Guid Id { get; set; }

    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("password")]
    public string? Password { get; set; }

    [Column("phone")]
    public string Phone { get; set; } = string.Empty;

    [Column("role_id")]
    public Guid RoleId { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    [Column("created_at", ignoreOnInsert: true, ignoreOnUpdate: true)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("branch_id")]
    public Guid BranchId { get; set; }

    [Column("has_global_access")]
    public bool HasGlobalAccess { get; set; } = true;
}

