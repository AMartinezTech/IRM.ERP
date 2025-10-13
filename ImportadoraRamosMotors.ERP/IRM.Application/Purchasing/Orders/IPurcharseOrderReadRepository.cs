using IRM.Core.Interfaces;
using IRM.Core.Purchasing.PurcharseOrders;

namespace IRM.Application.Purchasing.Orders;

public interface IPurcharseOrderReadRepository : IFilter<PurcharseOrderEntity>, IGetById<PurcharseOrderEntity,Guid>;