using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.MotorcycleColor;

public interface IMotorcycleColorWriteRepository : ICreate<MotorcycleColorEntity>, IUpdate<MotorcycleColorEntity>, IDelete<MotorcycleColorEntity, Guid>;