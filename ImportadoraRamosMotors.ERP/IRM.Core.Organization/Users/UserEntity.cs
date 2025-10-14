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
 
    private UserEntity(string email, string name, string password, string phone, Guid roleId)
    {
        Id = Guid.NewGuid();
        Email = email;
        Name = name;
        Password = password;
        Phone = phone;
        RoleId = roleId; 
    }

    public static UserEntity Create(string email, string name, string password, string phone, Guid roleId)
    {
        return new UserEntity(email, name, password, phone, roleId);
    }
    public void Update(string name, string phone, Guid roleId)
    {
        Name = name;
        Phone = phone;
        RoleId = roleId;
    }

    public void MarkAsActive() => IsActive = true;
    public void MarkAsInative() => IsActive = false;
}
