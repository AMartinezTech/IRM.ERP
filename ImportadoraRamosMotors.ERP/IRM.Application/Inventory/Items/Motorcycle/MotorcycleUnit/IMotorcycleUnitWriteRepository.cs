using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.Motorcycle.MotorcycleUnit;

public interface IMotorcycleUnitWriteRepository : ICreate<MotorcycleUnitEntity>, IUpdate<MotorcycleUnitEntity>, IDelete<MotorcycleUnitEntity, Guid>;