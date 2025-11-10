namespace IRM.Core.Organization.Users;

public class UserEntity
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string Name { get; private set; }
    public string? Password { get; private set; }
    public string Phone { get; private set; }
    public Guid RoleId { get; private set; }
    public bool IsActive { get; private set; } = true;
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public Guid? BranchId { get; private set; }  // null si tiene acceso global
    public bool HasGlobalAccess { get; private set; } // 🔹 Nuevo campo

    private UserEntity(
        string email,
        string name,
        string? password,
        string phone,
        Guid roleId,
        Guid? branchId,
        bool hasGlobalAccess)
    {
        Id = Guid.NewGuid();
        Email = email;
        Name = name;
        Password = password;
        Phone = phone;
        RoleId = roleId;
        BranchId = hasGlobalAccess ? null : branchId; // Si tiene acceso global, no se asocia a sucursal
        HasGlobalAccess = hasGlobalAccess;
    }

    public static UserEntity Create(
        string email,
        string name,
        string? password,
        string phone,
        Guid roleId,
        Guid? branchId,
        bool hasGlobalAccess = false)
    {
        return new UserEntity(email, name, password, phone, roleId, branchId, hasGlobalAccess);
    }

    public void Update(string name, string phone, Guid roleId, bool hasGlobalAccess, Guid? branchId = null)
    {
        Name = name;
        Phone = phone;
        RoleId = roleId;
        HasGlobalAccess = hasGlobalAccess;
        BranchId = hasGlobalAccess ? null : branchId;
    }

    public void MarkAsActive() => IsActive = true;
    public void MarkAsInactive() => IsActive = false;
}
