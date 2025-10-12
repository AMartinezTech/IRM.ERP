namespace IRM.Core.Organization.Users;

public class User
{
    public Guid Id { get; private set; }
    public string? Email { get; private set; }
    public string? Name { get; private set; }
    public string? Password { get; private set; }
    public string? Phone { get; private set; }
    public Guid RoleId { get; private set; }
    public bool IsActive { get; private set; } = true;
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public DateTime UpdatedAt { get; private set; } = DateTime.Now;
    private User() { }
    private User(string email, string name, string password, string phone, Guid roleId)
    {
        Id = Guid.NewGuid();
        Email = email;
        Name = name;
        Password = password;
        Phone = phone;
        RoleId = roleId;
    }

    public static User Create(string email, string name, string password, string phone, Guid roleId)
    {
        return new User(email, name, password, phone, roleId);
    }
    public void Update(string name, string phone, Guid roleId)
    {
        Name = name;
        Phone = phone;
        RoleId = roleId;
    }

    public void MarkAsActivate() => IsActive = true;
    public void MarkAsDeactivate() => IsActive = false;
}
