using IRM.Core.Exceptions; 

namespace IRM.Core.Inventory.Items.Motorcycles;

public class MotorcycleInspectionEntity
{
    public Guid Id { get; private set; }
    public DateTime Date { get; private set; }
    public Guid PerformedBy { get; private set; }
    public bool Mirrors { get; private set; }
    public bool Battery { get; private set; }
    public bool Tools { get; private set; }
    public string ConditionNotes { get; private set; }
    public Guid MotorcycleUnitId { get; private set; }
    public Guid WarehouseId { get; private set; }
     

    private MotorcycleInspectionEntity(Guid performedBy, bool mirrors, bool battery, bool tools, string conditionNotes, Guid motorcycleUnitId, Guid warehouseId)
    {
        Id = Guid.NewGuid();
        Date = DateTime.UtcNow;
        PerformedBy = performedBy;
        Mirrors = mirrors;
        Battery = battery;
        Tools = tools;
        ConditionNotes = conditionNotes;
        MotorcycleUnitId = motorcycleUnitId;
        WarehouseId = warehouseId;
    }

    public static MotorcycleInspectionEntity Create(Guid performedBy, bool mirrors, bool battery, bool tools, string conditionNotes, Guid motorcycleUnitId, Guid warehouseId)
    {
        if (performedBy == Guid.Empty)
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "INSPECTOR")} - {nameof(performedBy)}");

        return new MotorcycleInspectionEntity(performedBy, mirrors, battery, tools, conditionNotes, motorcycleUnitId, warehouseId);
    }
    
    public void UpdateNotes(string condictionNotes)
    {
        ConditionNotes = condictionNotes;
    }
}