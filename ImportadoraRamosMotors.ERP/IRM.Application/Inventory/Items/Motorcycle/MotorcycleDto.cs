using IRM.Application.Inventory.Items.Motorcycle.MotorcycleUnit;

namespace IRM.Application.Inventory.Items.Motorcycle;

public class MotorcycleDto
{
    public Guid Id { get; set; }
    public Guid Brand { get; set; }
    public Guid Model { get; set; }
    public Guid Color { get; set; }
    public int Year { get; set; }
    public string Condition { get; set; } = string.Empty;
    public bool IsImported { get; set; }
    public int EngineDisplacement { get; set; }
    public List<MotorcycleUnitDto> MotorcycleUnit { get; set; } = [];
}

