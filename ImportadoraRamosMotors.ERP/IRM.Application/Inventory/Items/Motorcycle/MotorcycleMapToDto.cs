using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.Motorcycle;

internal class MotorcycleMapToDto
{
    internal static MotorcycleDto Single(MotorcycleEntity entity)
    {
        return new MotorcycleDto
        {
            Id = entity.Id,
            ChassisNumber = entity.ChassisNumber,
            EngineNumber = entity.EngineNumber,
            MotorcycleCatalogId = entity.MotorcycleCatalogId,
            CurrentLocation = entity.CurrentLocation!.ToString(),
            Status = entity.Status.ToString(),
        };
    }

    internal static List<MotorcycleDto> List(IEnumerable<MotorcycleEntity> entities) 
    {
        return [.. entities.Select(Single)];
    }
}
