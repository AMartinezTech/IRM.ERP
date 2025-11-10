namespace IRM.Application.Inventory.Items.Motorcycle;

public class MotorcycleDto
{
    public Guid Id { get; set; }
    public Guid MotorcycleCatalogId { get; set; }
    public string ChassisNumber { get; set; } = string.Empty;
    public string EngineNumber { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string CurrentLocation { get; set; } = string.Empty;
    public bool IsImported { get; set; }
}
