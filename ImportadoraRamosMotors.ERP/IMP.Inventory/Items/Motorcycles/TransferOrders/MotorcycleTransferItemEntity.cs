namespace IRM.Core.Inventory.Items.Motorcycles.TransferOrders;

public class MotorcycleTransferItemEntity
{
    public Guid Id { get; private set; }
    public Guid TransferOrderId { get; private set; }
    public Guid MotorcycleUnitId { get; private set; }
    public MotorcycleInspectionEntity? OutgoingInspection { get; private set; }
    public MotorcycleInspectionEntity? IncomingInspection { get; private set; }

    private MotorcycleTransferItemEntity() { }

    private MotorcycleTransferItemEntity(Guid transferOrderId, Guid motorcycleUnitId)
    {
        Id = Guid.NewGuid();
        TransferOrderId = transferOrderId;
        MotorcycleUnitId = motorcycleUnitId;
    }

    public static MotorcycleTransferItemEntity Create(Guid transferOrderId, Guid motorcycleUnitId)
        => new(transferOrderId, motorcycleUnitId);

    public void AssignOutgoingInspection(MotorcycleInspectionEntity inspection)
    {
        OutgoingInspection = inspection ?? throw new ArgumentNullException(nameof(inspection));
    }

    public void AssignIncomingInspection(MotorcycleInspectionEntity inspection)
    {
        IncomingInspection = inspection ?? throw new ArgumentNullException(nameof(inspection));
    }
}

