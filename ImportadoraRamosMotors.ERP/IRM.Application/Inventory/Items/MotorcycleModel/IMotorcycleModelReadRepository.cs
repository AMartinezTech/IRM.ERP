using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.MotorcycleModel;

public interface IMotorcycleModelReadRepository : IFilter<MotorcycleModelEntity>, IGetById<MotorcycleModelEntity, Guid>
{
    Task<string?> ExistsAsync(string name, Guid brandId);
}