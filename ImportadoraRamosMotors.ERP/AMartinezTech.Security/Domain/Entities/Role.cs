namespace AMartinezTech.Security.Domain.Entities;

public class Role(string name)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public bool IsActive { get; private set; } = true;

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;
}
