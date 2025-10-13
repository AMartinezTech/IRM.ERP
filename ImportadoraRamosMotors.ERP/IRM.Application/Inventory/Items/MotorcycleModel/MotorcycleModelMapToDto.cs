using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.MotorcycleModel;

internal class MotorcycleModelMapToDto
{
    internal static MotorcycleModelDto Single(MotorcycleModelEntity entity)
    {
        return new MotorcycleModelDto
        {
            Id = entity.Id,
            Name = entity.Name,
            IsActive = entity.IsActive,
        };
    }

    internal static List<MotorcycleModelDto> List(IEnumerable<MotorcycleModelEntity> entities)
    {
        return [.. entities.Select(Single)];
    }
}
