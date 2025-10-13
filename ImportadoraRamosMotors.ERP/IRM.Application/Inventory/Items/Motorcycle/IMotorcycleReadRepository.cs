using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.Motorcycle;

public interface IMotorcycleReadRepository : IFilter<MotorcycleEntity>, IGetById<MotorcycleEntity, Guid>
{
    Task<bool> ExistsAsync(Guid brand, Guid model, Guid color, int year, int engineDisplacement);
}