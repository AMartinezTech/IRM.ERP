
using IRM.Core.Inventory.Items.Motorcycles;
namespace IRM.Application.Inventory.Items.Motorcycle.Catalog;

internal class MotorcycleCatalogMapToDto
{
    internal static MotorcycleCatalogDto Single(MotorcycleCatalogEntity entity)
    {
        return new MotorcycleCatalogDto
        {
            Id = entity.Id,
            BrandId = entity.BrandId,
            ModelId = entity.ModelId,
            ColorId = entity.ColorId,
            Year = entity.Year,
            Condition = entity.Condition.ToString(), 
            EngineDisplacement = entity.EngineDisplacement,
            MotorcycleUnit = [.. entity.Motorcycles.Select(u => new MotorcycleDto
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

    internal static List<MotorcycleCatalogDto> List(IEnumerable<MotorcycleCatalogEntity> entities)
    {
        return [.. entities.Select(Single)];
    }
}
