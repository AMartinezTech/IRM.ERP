using IRM.Core.Interfaces;
using IRM.Core.Inventory.Warehouses;

namespace IRM.Application.Inventory.Warehouses;

public interface IWarehouseReadRepository : IFilter<WarehouseEntity>, IGetById<WarehouseEntity, Guid>
{
    Task<bool> ExistsAsync(Guid branchId, string name);
}