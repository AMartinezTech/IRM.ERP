using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.Motorcycle.MotorcycleUnit;

internal class MotorcycleUnitMapToDto
{
    internal static MotorcycleUnitDto Single(MotorcycleUnitEntity entity)
    {
        return new MotorcycleUnitDto
        {
            Id = entity.Id,
            ChassisNumber = entity.ChassisNumber,
            EngineNumber = entity.EngineNumber,
            MotorcycleCatalogId = entity.MotorcycleCatalogId,
            CurrentLocation = entity.CurrentLocation!.ToString(),
            Status = entity.Status.ToString(),
        };
    }

    internal static List<MotorcycleUnitDto> List(IEnumerable<MotorcycleUnitEntity> entities) 
    {
        return [.. entities.Select(Single)];
    }
}
