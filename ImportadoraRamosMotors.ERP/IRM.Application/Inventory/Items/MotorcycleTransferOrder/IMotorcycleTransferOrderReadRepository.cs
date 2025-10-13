using IRM.Core.Interfaces;
using IRM.Core.Inventory.Items.Motorcycles.TransferOrders;

namespace IRM.Application.Inventory.Items.MotorcycleTransferOrder;

public interface IMotorcycleTransferOrderReadRepository : IFilter<MotorcycleTransferOrderEntity>, IGetById<MotorcycleTransferOrderEntity,Guid>;