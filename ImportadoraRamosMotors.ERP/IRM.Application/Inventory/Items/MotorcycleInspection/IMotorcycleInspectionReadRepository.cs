using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.MotorcycleInspection;

public interface IMotorcycleInspectionReadRepository : IFilter<MotorcycleInspectionEntity>, IGetById<MotorcycleInspectionEntity, Guid>
{
    Task<bool> ExistsAsync(Guid motorcycleUnitId, Guid warehouseId);
} 