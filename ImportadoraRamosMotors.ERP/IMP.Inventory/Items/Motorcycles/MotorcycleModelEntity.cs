using IRM.Core.Exceptions;

namespace IRM.Core.Inventory.Items.Motorcycles;

public class MotorcycleModelEntity
{
    public Guid Id { get; private set; }
    public Guid Brand { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; } = true;
      
    private MotorcycleModelEntity(Guid brandId, string name)
    {
        Id = Guid.NewGuid();
        Brand = brandId;
        Name = name;
        Validate();
    }
    public static MotorcycleModelEntity Create(Guid brandId, string name)
    {
        return new MotorcycleModelEntity(brandId,name);
    }
    private void Validate()
    {
        if (Brand == Guid.Empty)
            throw new ValidationException($" {string.Format(CommonErrors.RequiredField, "MARCA")} - {nameof(Brand)}");

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
