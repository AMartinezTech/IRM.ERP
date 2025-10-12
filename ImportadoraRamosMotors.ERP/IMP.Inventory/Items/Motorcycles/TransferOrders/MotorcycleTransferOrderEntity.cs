using IRM.Core.BaseEntities;
using IRM.Core.Enums;
using IRM.Core.Exceptions;
using IRM.Core.Inventory.Errors;

namespace IRM.Core.Inventory.Items.Motorcycles.TransferOrders;

public class MotorcycleTransferOrderEntity : EntityBase
{
    public string Code { get; private set; }                     // Código o correlativo de traslado
    public Guid SourceWarehouseId { get; private set; }          // Origen
    public Guid TargetWarehouseId { get; private set; }          // Destino

    public DateTime? SentAt { get; private set; }                // Fecha de envío
    public DateTime? ReceivedAt { get; private set; }            // Fecha de recepción
    public TransferStatusEnum Status { get; private set; }       // Estado del traslado

    public string? SentBy { get; private set; }                  // Usuario que despacha
    public string? ReceivedBy { get; private set; }              // Usuario que recibe
    public IReadOnlyCollection<MotorcycleTransferItemEntity> Items => _items.AsReadOnly();

    private readonly List<MotorcycleTransferItemEntity> _items = [];
    private MotorcycleTransferOrderEntity() { }

    private MotorcycleTransferOrderEntity(string code, Guid sourceWarehouseId, Guid targetWarehouseId, Guid createdBy)
    {
        Id = Guid.NewGuid();
        Code = code;
        SourceWarehouseId = sourceWarehouseId;
        TargetWarehouseId = targetWarehouseId;
        CreatedAt = DateTime.UtcNow;
        CreatedBy = createdBy;
        Status = TransferStatusEnum.Pending;
        Validate();
    }
    public override void Validate()
    {
        if (SourceWarehouseId == TargetWarehouseId)
            throw new ValidationException(TransferErrors.SourceAndTargetMustBeDifferent);
    }
    public static MotorcycleTransferOrderEntity Create(string code, Guid sourceWarehouseId, Guid targetWarehouseId, Guid createdBy)
    {
       
        return new MotorcycleTransferOrderEntity(code, sourceWarehouseId, targetWarehouseId, createdBy);
    }

    public void AddItem(Guid motorcycleUnitId)
    {
        if (Status != TransferStatusEnum.Pending)
            throw new InvalidOperationException(TransferErrors.CannotModifyNonPendingTransfer);

        if (_items.Exists(i => i.MotorcycleUnitId == motorcycleUnitId))
            throw new ValidationException(TransferErrors.DuplicateMotorcycleInTransfer);

        _items.Add(MotorcycleTransferItemEntity.Create(Id, motorcycleUnitId));
    }

    public void MarkAsSent(string sentBy)
    {
        if (Status != TransferStatusEnum.Pending)
            throw new InvalidOperationException(TransferErrors.OnlyPendingTransfersCanBeSent);

        SentAt = DateTime.UtcNow;
        SentBy = sentBy;
        Status = TransferStatusEnum.InTransit;
    }

    public void MarkAsReceived(string receivedBy)
    {
        if (Status != TransferStatusEnum.InTransit)
            throw new InvalidOperationException(TransferErrors.OnlyInTransitTransfersCanBeReceived);

        ReceivedAt = DateTime.UtcNow;
        ReceivedBy = receivedBy;
        Status = TransferStatusEnum.Completed;
    }

    public override void MarkAsActive() => IsActive = true;
    public override void MarkAsInactive() => IsActive = false;
   
}
