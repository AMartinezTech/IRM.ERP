using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.MotorcycleColor;

public interface IMotorcycleColorReadRepository : IFilter<MotorcycleColorEntity>, IGetById<MotorcycleColorEntity, Guid>
{
    Task<string?> ExistsAsync(string name);

}