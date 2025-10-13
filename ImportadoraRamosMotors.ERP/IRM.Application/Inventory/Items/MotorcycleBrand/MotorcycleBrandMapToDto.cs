using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.MotorcycleBrand;

internal class MotorcycleBrandMapToDto
{
    internal static MotorcycleBrandDto Single(MotorcycleBrandEntity entity)
    {
        return new MotorcycleBrandDto
        {
            Id = entity.Id,
            Name = entity.Name,
            IsActive = entity.IsActive,
        };
    }

    internal static List<MotorcycleBrandDto> List(IEnumerable<MotorcycleBrandEntity> entities) 
    { 
        return [.. entities.Select(Single)];
    }
}
