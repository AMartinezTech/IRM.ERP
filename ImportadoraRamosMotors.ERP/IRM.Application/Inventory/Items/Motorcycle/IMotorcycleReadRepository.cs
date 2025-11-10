using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.Motorcycle;

public interface IMotorcycleReadRepository : IFilter<MotorcycleEntity>, IGetById<MotorcycleEntity, Guid> 
{
    Task<bool> ExistsByChassisAsync(string chassisNumber, string engineNumber);
}