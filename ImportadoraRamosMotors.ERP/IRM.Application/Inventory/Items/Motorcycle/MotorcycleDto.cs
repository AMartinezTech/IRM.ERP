using IRM.Application.Inventory.Items.Motorcycles; 

namespace IRM.Application.Inventory.Items.Motorcycle;

public class MotorcycleDto
{
    public Guid Brand { get; private set; }
    public Guid Model { get; private set; }
    public Guid Color { get; private set; }
    public int Year { get; private set; }
    public string Condition { get; private set; }   =string.Empty;
    public bool IsImported { get; private set; }
    public int EngineDisplacement { get; private set; } // CC (Ej: 125)
    public MotorcycleUnitDto MotorcycleUnit { get; private set; } = new();
}
