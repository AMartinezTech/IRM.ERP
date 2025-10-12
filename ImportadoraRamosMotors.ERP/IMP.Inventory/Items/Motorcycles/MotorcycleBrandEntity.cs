using IRM.Core.Exceptions;

namespace IRM.Core.Inventory.Items.Motorcycles;

public class MotorcycleBrandEntity
{
     
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; } = true;

    private MotorcycleBrandEntity(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        Validate();
    }
    public static MotorcycleBrandEntity Create(string name)
    {
        return new MotorcycleBrandEntity(name);
    }
    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name.Trim()))
            throw new ValidationException($" {string.Format(CommonErrors.RequiredField, "NOMBRE")} - {nameof(Name)}");
    }
    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
    public void Update(string name)
    {
        Name = name;
        Validate();
    }
}
