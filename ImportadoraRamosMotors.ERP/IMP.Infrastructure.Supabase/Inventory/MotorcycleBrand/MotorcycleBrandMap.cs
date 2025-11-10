using IRM.Core.Inventory.Items.Motorcycles; 

namespace IRM.Infrastructure.Supabase.Inventory.MotorcycleBrand;

internal class MotorcycleBrandMap
{
    internal static MotorcycleBrandModel ToModel(MotorcycleBrandEntity entity)
    {
        return new MotorcycleBrandModel
        {
            Id = entity.Id,
            Name = entity.Name,
            IsActive = entity.IsActive,
        };
    }

    internal static MotorcycleBrandEntity ToEntity(MotorcycleBrandModel model)
    {
        return MotorcycleBrandEntity.Create(model.Id, model.Name, model.IsActive);
    }
}
