using IRM.Application.Inventory.Items.Motorcycle.MotorcycleUnit;
using IRM.Core.Inventory.Items.Motorcycles;
namespace IRM.Application.Inventory.Items.Motorcycle;

internal class MotorcycleMapToDto
{
    internal static MotorcycleDto Single(MotorcycleEntity entity)
    {
        return new MotorcycleDto
        {
            Id = entity.Id,
            Brand = entity.Brand,
            Model = entity.Model,
            Color = entity.Color,
            Year = entity.Year,
            Condition = entity.Condition.ToString(),
            IsImported = entity.IsImported,
            EngineDisplacement = entity.EngineDisplacement,
            MotorcycleUnit = [.. entity.MotorcycleUnits.Select(u => new MotorcycleUnitDto
            {
                Id = u.Id,
                MotorcycleCatalogId = u.MotorcycleCatalogId,
                ChassisNumber = u.ChassisNumber,
                EngineNumber = u.EngineNumber,
                Status = u.Status.ToString(),
                CurrentLocation = u.CurrentLocation!.ToString()
            })]
        };
    }

    internal static List<MotorcycleDto> List(IEnumerable<MotorcycleEntity> entities)
    {
        return [.. entities.Select(Single)];
    }
}
