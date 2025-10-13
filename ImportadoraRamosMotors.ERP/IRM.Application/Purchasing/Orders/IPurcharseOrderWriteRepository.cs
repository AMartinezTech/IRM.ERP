using IRM.Core.Interfaces;
using IRM.Core.Purchasing.PurcharseOrders;

namespace IRM.Application.Purchasing.Orders;

public interface IPurcharseOrderWriteRepository : ICreate<PurcharseOrderEntity>, IUpdate<PurcharseOrderEntity>;