namespace IRM.Application.Inventory.Items.Motorcycle.Catalog;

public class MotorcycleCatalogDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get;  set; }
    public Guid CreatedBy { get;  set; }
    public Guid BrandId { get; set; }
    public Guid ModelId { get; set; }
    public Guid ColorId { get; set; }
    public int Year { get; set; }
    public string Condition { get; set; } = string.Empty; 
    public int EngineDisplacement { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }

    public List<MotorcycleDto> MotorcycleUnit { get; set; } = [];
}

