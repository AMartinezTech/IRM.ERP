using IRM.Application.Inventory.Items.MotorcycleInspection;
using IRM.Core.Inventory.Items.Motorcycles.TransferOrders;

namespace IRM.Application.Inventory.Items.MotorcycleTransferOrder;

internal class MotorcycleTransferOrderMapToDto
{
    internal static MotorcycleTransferOrderDto Single(MotorcycleTransferOrderEntity entity)
    {
        return new MotorcycleTransferOrderDto
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            Code = entity.Code,
            SourceWarehouseId = entity.SourceWarehouseId,
            TargetWarehouseId = entity.TargetWarehouseId,
            SentAt = entity.SentAt,
            ReceivedAt = entity.ReceivedAt,
            Status = entity.Status.ToString(),
            SentBy = entity.SentBy,
            ReceivedBy = entity.ReceivedBy,
            Items = [.. entity.Items.Select(i => new MotorcycleTransferOrderItemDto
            {
                Id = i.Id,
                TransferOrderId = i.TransferOrderId,
                MotorcycleUnitId = i.MotorcycleUnitId,
                OutgoingInspection = i.OutgoingInspection == null ? null : new MotorcycleInspectionDto
                {
                    Id = i.OutgoingInspection.Id,
                    Date = i.OutgoingInspection.Date,
                    PerformedBy = i.OutgoingInspection.PerformedBy,
                    Mirrors = i.OutgoingInspection.Mirrors,
                    Battery = i.OutgoingInspection.Battery,
                    Tools = i.OutgoingInspection.Tools,
                    ConditionNotes = i.OutgoingInspection.ConditionNotes,
                    MotorcycleUnitId = i.OutgoingInspection.MotorcycleUnitId,
                    WarehouseId = i.OutgoingInspection.WarehouseId
                },

                IncomingInspection = i.IncomingInspection == null ? null : new MotorcycleInspectionDto
                {
                    Id = i.IncomingInspection.Id,
                    Date = i.IncomingInspection.Date,
                    PerformedBy = i.IncomingInspection.PerformedBy,
                    Mirrors = i.IncomingInspection.Mirrors,
                    Battery = i.IncomingInspection.Battery,
                    Tools = i.IncomingInspection.Tools,
                    ConditionNotes = i.IncomingInspection.ConditionNotes,
                    MotorcycleUnitId = i.IncomingInspection.MotorcycleUnitId,
                    WarehouseId = i.IncomingInspection.WarehouseId
                }

            })]
        };
    }

    internal static List<MotorcycleTransferOrderDto> List(IEnumerable<MotorcycleTransferOrderEntity> entities)
    {
        return [.. entities.Select(Single)];
    }
}
