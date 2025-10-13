namespace IRM.Application.Inventory.Items.MotorcycleInspection;

public class MotorcycleInspectionDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid PerformedBy { get; set; }
    public bool Mirrors { get; set; }
    public bool Battery { get; set; }
    public bool Tools { get; set; }
    public string ConditionNotes { get; set; } = string.Empty;
    public Guid MotorcycleUnitId { get; set; }
    public Guid WarehouseId { get; set; }
}
 