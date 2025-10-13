using IRM.Core.Inventory.Warehouses;

namespace IRM.Application.Inventory.Warehouses;

internal class WarehouseMapToDto
{
    internal static WarehouseDto Single(WarehouseEntity entity)
    {
        return new WarehouseDto
        {
            Id = entity.Id,
            BranchId = entity.BranchId,
            Name = entity.Name,
            IsActive = entity.IsActive,
        };
    }

    internal static List<WarehouseDto> List(IEnumerable<WarehouseEntity> entities) 
    {
        return [.. entities.Select(Single)];
    }
}
