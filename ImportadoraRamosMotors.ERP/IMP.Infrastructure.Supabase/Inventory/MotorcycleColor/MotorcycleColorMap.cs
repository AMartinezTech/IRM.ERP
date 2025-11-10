using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Infrastructure.Supabase.Inventory.MotorcycleColor;

internal class MotorcycleColorMap
{
    internal static MotorcycleColorModel ToModel(MotorcycleColorEntity entity)
    {
        return new MotorcycleColorModel
        {
            Id = entity.Id,
            Name = entity.Name,
            IsActive = entity.IsActive,
        };
    }

    internal static MotorcycleColorEntity ToEntity(MotorcycleColorModel model) 
    {
        return MotorcycleColorEntity.Create(model.Id, model.Name, model.IsActive);
    }
}
