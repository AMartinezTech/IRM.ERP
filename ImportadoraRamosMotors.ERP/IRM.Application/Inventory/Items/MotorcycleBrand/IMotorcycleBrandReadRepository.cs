using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.MotorcycleBrand;

public interface IMotorcycleBrandReadRepository : IFilter<MotorcycleBrandEntity>, IGetById<MotorcycleBrandEntity, Guid>
{
    Task<string?> ExistsAsync(string name);
}
