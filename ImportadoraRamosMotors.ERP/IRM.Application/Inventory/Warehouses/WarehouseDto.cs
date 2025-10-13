namespace IRM.Application.Inventory.Warehouses;

public class WarehouseDto
{
    public Guid Id { get; set; }
    public Guid BranchId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }  
}
