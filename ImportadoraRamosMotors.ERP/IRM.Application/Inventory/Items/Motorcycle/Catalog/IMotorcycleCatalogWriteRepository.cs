using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.Motorcycle.Catalog;

public interface IMotorcycleCatalogWriteRepository :ICreate<MotorcycleCatalogEntity>, IUpdate<MotorcycleCatalogEntity>, IDelete<MotorcycleCatalogEntity, Guid>;

