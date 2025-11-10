using IRM.Core.Inventory.Items.Motorcycles; 

namespace IRM.Infrastructure.Supabase.Inventory.MotorcycleModel;

internal class MotorcycleModelMap
{
    internal static MotorcycleModelModel ToModel(MotorcycleModelEntity entity)
    {
        return new MotorcycleModelModel
        {
            Id = entity.Id,
            Name = entity.Name,
            IsActive = entity.IsActive,
            BrandId = entity.BrandId
        };
    }

    internal static MotorcycleModelEntity ToEntity(MotorcycleModelModel model)
    {
        return MotorcycleModelEntity.Create(model.Id,model.BrandId, model.Name, model.IsActive);
    }
}
