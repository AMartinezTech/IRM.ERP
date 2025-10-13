using IRM.Core.Purchasing.PurcharseOrders;

namespace IRM.Application.Purchasing.Orders;

internal class PurcharseOrderMapToDto
{
    internal static PurcharseOrderDto Single(PurcharseOrderEntity entity)
    {
        return new PurcharseOrderDto
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            Code = entity.Code,
            ReceivedAt = entity.ReceivedAt,
            Status = entity.Status.ToString(),
            ReceivedBy = entity.ReceivedBy,
            Items = [.. entity.Items.Select(i=> new PurcharseOrderItemDto
            {
                Id = i.Id,
                PurchaseOrderId = i.PurchaseOrderId,
                MotorcycleUnitId = i.MotorcycleUnitId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice,
            })]
        };
    }

    internal static List<PurcharseOrderDto> List(IEnumerable<PurcharseOrderEntity> entities) 
    {
        return [.. entities.Select(Single)];
    }
}
