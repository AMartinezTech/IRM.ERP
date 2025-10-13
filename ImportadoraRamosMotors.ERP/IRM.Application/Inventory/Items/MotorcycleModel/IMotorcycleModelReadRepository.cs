using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.MotorcycleModel;

public interface IMotorcycleModelReadRepository : IFilter<MotorcycleModelEntity>, IGetById<MotorcycleModelEntity, Guid>
{
    Task<bool> ExistsAsync(string name);
}