using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.MotorcycleColor;

internal class MotorcycleColorMapToDto
{
    internal static MotorcycleColorDto Single(MotorcycleColorEntity entity)
    {
        return new MotorcycleColorDto
        {
            Id = entity.Id,
            Name = entity.Name,
            IsActive = entity.IsActive,
        };
    }

    internal static List<MotorcycleColorDto> List(IEnumerable<MotorcycleColorEntity> entities)
    {
        return [.. entities.Select(Single)];
    }
}
