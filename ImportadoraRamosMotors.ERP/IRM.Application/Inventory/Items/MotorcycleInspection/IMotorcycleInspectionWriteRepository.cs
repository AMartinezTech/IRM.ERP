using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.MotorcycleInspection;

public interface IMotorcycleInspectionWriteRepository :ICreate<MotorcycleInspectionEntity>, IUpdate<MotorcycleInspectionEntity>;