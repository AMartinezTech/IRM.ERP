using IRM.Core.Exceptions;
using System.Xml.Linq;

namespace IRM.Core.Inventory.Items.Motorcycles;

public class MotorcycleInspectionEntity
{
    public Guid Id { get; private set; }
    public DateTime Date { get; private set; }
    public string PerformedBy { get; private set; }
    public bool Mirrors { get; private set; }
    public bool Battery { get; private set; }
    public bool Tools { get; private set; }
    public string ConditionNotes { get; private set; }

    private MotorcycleInspectionEntity() { }

    private MotorcycleInspectionEntity(string performedBy, bool mirrors, bool battery, bool tools, string conditionNotes)
    {
        Id = Guid.NewGuid();
        Date = DateTime.UtcNow;
        PerformedBy = performedBy;
        Mirrors = mirrors;
        Battery = battery;
        Tools = tools;
        ConditionNotes = conditionNotes;
    }

    public static MotorcycleInspectionEntity Create(string performedBy, bool mirrors, bool battery, bool tools, string conditionNotes)
    {
        if (string.IsNullOrWhiteSpace(performedBy))
            throw new ValidationException($" {string.Format(CommonErrors.RequiredField, "INSPECTOR")} - {nameof(performedBy)}");

        return new MotorcycleInspectionEntity(performedBy, mirrors, battery, tools, conditionNotes);
    }
}