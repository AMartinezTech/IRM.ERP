using IRM.Core.Exceptions;
using IRM.Core.Shared.Utils;

namespace IRM.Core.Inventory.Items.Motorcycles;

public class MotorcycleModelEntity
{
    public Guid Id { get; private set; }
    public Guid BrandId { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; } = true;

    private MotorcycleModelEntity(Guid id, Guid brandId, string name, bool isActive)
    {
        Id = id;
        BrandId = brandId;
        Name = name;
        IsActive = isActive;
    }
    public static MotorcycleModelEntity Create(Guid id, Guid brandId, string name, bool isActive)
    {
        if (brandId == Guid.Empty)
            throw new ValidationException($" {string.Format(CommonErrors.RequiredField, "MARCA")} - {nameof(BrandId)}");

        Validate(name);
        return new MotorcycleModelEntity(GuidID.Generate(id), brandId, name, isActive);
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
