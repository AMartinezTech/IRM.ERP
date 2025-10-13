using IRM.Core.Exceptions; 

namespace IRM.Core.Inventory.Warehouses;

public class WarehouseEntity
{
    public Guid Id { get; private set; }
    public Guid BranchId { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; } = true;

    private WarehouseEntity(Guid branchId, string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        Validate();
    }
    public static WarehouseEntity Create(Guid branchId, string name)
    {
        return new WarehouseEntity(branchId, name);
    }
    private void Validate()
    {

        if (BranchId == Guid.Empty)
            throw new ValidationException($" {string.Format(CommonErrors.RequiredField, "SUCURSAL")} - {nameof(BranchId)}");

        if (string.IsNullOrWhiteSpace(Name.Trim()))
            throw new ValidationException($" {string.Format(CommonErrors.RequiredField, "NOMBRE")} - {nameof(Name)}");
    }
    public void MarkAsActivate() => IsActive = true;
    public void MarkAsDeactivate() => IsActive = false;
    public void Update(string name)
    {
        Name = name;
        Validate();
    }
}
