using IRM.Core.Exceptions;
using IRM.Core.Shared.Utils;

namespace IRM.Core.Inventory.Items.Motorcycles;

public class MotorcycleColorEntity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; } = true;

    private MotorcycleColorEntity(Guid id, string name, bool isActive)
    {
        Id = id;
        Name = name;
        IsActive = isActive;
         
    }
    public static MotorcycleColorEntity Create(Guid id, string name, bool isActive)
    {
        Validate(name);
        return new MotorcycleColorEntity(GuidID.Generate(id), name,isActive);
    }
    
    private static void Validate(string name)
    {
        if (string.IsNullOrWhiteSpace(name.Trim()))
            throw new ValidationException($" {string.Format(CommonErrors.RequiredField, "NOMBRE")} - {nameof(Name)}");
    }
    public void Update(string name, bool isActive)
    {
        Validate(name);
        Name = name; 
        IsActive = isActive;
    }
}
