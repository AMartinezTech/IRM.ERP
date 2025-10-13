using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles.TransferOrders;

namespace IRM.Application.Inventory.Items.MotorcycleTransferOrder;

public interface IMotorcycleTransferOrderWriteRepository : ICreate<MotorcycleTransferOrderEntity>, IUpdate<MotorcycleTransferOrderEntity>;
