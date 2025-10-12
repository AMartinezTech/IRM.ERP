namespace IRM.Application.Inventory.Items.Motorcycles;

public class MotorcycleUnitDto
{
    public Guid MotorcycleCatalogId { get;  set; } 
    public string ChassisNumber { get;  set; } = string.Empty;
    public string EngineNumber { get;  set; } = string.Empty;
    public string Status { get;  set; }  = string.Empty ;
    public string CurrentLocation { get; set; } = string.Empty;

}
