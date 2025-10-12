using IRM.Core.Exceptions; 

namespace IRM.Core.Inventory.Warehouses;

public class Warehouse
{
    public Guid Id { get; private set; }
    public Guid BranchId { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; } = true;

    private Warehouse(Guid branchId, string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        Validate();
    }
    public static Warehouse Create(Guid branchId, string name)
    {
        return new Warehouse(branchId, name);
    }
    private void Validate()
    {

        if (BranchId == Guid.Empty)
            throw new ValidationException($" {string.Format(CommonErrors.RequiredField, "SUCURSAL")} - {nameof(BranchId)}");

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
