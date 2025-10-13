using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.MotorcycleModel;

public interface IMotorcycleModelWriteRepository : ICreate<MotorcycleModelEntity>, IUpdate<MotorcycleModelEntity>, IDelete<MotorcycleModelEntity, Guid>;