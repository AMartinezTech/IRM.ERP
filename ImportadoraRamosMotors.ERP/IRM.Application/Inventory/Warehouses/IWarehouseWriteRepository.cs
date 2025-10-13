using IRM.Core.Interfaces;
using IRM.Core.Inventory.Warehouses;

namespace IRM.Application.Inventory.Warehouses;

public interface IWarehouseWriteRepository : ICreate<WarehouseEntity>, IUpdate<WarehouseEntity>;
