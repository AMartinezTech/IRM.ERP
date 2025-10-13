namespace IRM.Application.Inventory.Items.MotorcycleModel;

public class MotorcycleModelDto
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
