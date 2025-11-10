using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.Motorcycle.Catalog;

public interface IMotorcycleCatalogReadRepository : IFilter<MotorcycleCatalogEntity>, IGetById<MotorcycleCatalogEntity, Guid>
{
    Task<bool> ExistsAsync(Guid brandId, Guid modelId, Guid colorId, int year, int engineDisplacement);
}