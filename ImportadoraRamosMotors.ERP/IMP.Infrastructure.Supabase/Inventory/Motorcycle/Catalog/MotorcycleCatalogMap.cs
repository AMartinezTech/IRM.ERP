using IRM.Core.Inventory.Items.Motorcycles;
using Newtonsoft.Json.Linq;
using System;

namespace IRM.Infrastructure.Supabase.Inventory.Motorcycle.Catalog;

internal class MotorcycleCatalogMap
{
    internal static MotorcycleCatalogModel ToModel(MotorcycleCatalogEntity entity)
    {
        return new MotorcycleCatalogModel
        {
            Id = entity.Id,
            BrandId = entity.BrandId,
            ModelId = entity.ModelId,
            ColorId = entity.ColorId,
            Year = entity.Year,
            Condition = entity.Condition.ToString(),
            EngineDisplacement = entity.EngineDisplacement,
        };
    }

    internal static MotorcycleCatalogEntity ToEntity(MotorcycleCatalogModel model)
    {
         
        return MotorcycleCatalogEntity.Create(model.Id, model.BrandId, model.ModelId, model.ColorId, model.Year, model.Condition, model.EngineDisplacement);
    }
}
