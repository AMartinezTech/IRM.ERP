namespace IRM.Application.Inventory.Items.Motorcycle.Catalog;

public class MotorcycleCatalogDto
{
    public Guid Id { get; set; }
    public Guid Brand { get; set; }
    public Guid Model { get; set; }
    public Guid Color { get; set; }
    public int Year { get; set; }
    public string Condition { get; set; } = string.Empty; 
    public int EngineDisplacement { get; set; }
    public List<MotorcycleDto> MotorcycleUnit { get; set; } = [];
}

