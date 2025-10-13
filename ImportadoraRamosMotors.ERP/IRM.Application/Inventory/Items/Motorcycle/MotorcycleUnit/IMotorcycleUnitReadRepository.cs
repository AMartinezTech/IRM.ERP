using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.Motorcycle.MotorcycleUnit;

public interface IMotorcycleUnitReadRepository : IFilter<MotorcycleUnitEntity>, IGetById<MotorcycleUnitEntity, Guid> 
{
    Task<bool> ExistsByChassisAsync(string chassisNumber, string engineNumber);
}