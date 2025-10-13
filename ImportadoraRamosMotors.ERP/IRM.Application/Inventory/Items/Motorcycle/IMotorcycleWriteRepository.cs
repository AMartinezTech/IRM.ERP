using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.Motorcycle;

public interface IMotorcycleWriteRepository :ICreate<MotorcycleEntity>, IUpdate<MotorcycleEntity>, IDelete<MotorcycleEntity, Guid>;

