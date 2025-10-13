using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.MotorcycleInspection;

internal class MotorcycleInspectionMapToDto
{
    internal static MotorcycleInspectionDto Single(MotorcycleInspectionEntity entity)
    {
        return new MotorcycleInspectionDto
        {
            Id = entity.Id,
            Date = entity.Date,
            PerformedBy = entity.PerformedBy,
            Mirrors = entity.Mirrors,
            Battery = entity.Battery,
            Tools = entity.Tools,
            ConditionNotes = entity.ConditionNotes,
            MotorcycleUnitId = entity.MotorcycleUnitId,
            WarehouseId = entity.WarehouseId,
        };
    }

    internal static List<MotorcycleInspectionDto> List(IEnumerable<MotorcycleInspectionEntity> entities)
    {
        return [.. entities.Select(Single)];
    }
}
