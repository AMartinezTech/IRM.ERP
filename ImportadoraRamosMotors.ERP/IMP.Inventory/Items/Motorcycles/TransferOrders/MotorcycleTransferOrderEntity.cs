using IRM.Core.BaseEntities;
using IRM.Core.Enums;
using IRM.Core.Exceptions;
using IRM.Core.Inventory.Errors;

namespace IRM.Core.Inventory.Items.Motorcycles.TransferOrders;

public class MotorcycleTransferOrderEntity : EntityBase
{
    public string Code { get; private set; }                    
    public Guid SourceWarehouseId { get; private set; }         
    public Guid TargetWarehouseId { get; private set; }         
    public DateTime? SentAt { get; private set; }               
    public DateTime? ReceivedAt { get; private set; }           
    public TransferStatusEnum Status { get; private set; }      
    public string? SentBy { get; private set; }                 
    public string? ReceivedBy { get; private set; }             
    public IReadOnlyCollection<MotorcycleTransferItemEntity> Items => _items.AsReadOnly();

    private readonly List<MotorcycleTransferItemEntity> _items = [];
     
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
        if (_items.Count == 0)
            throw new InvalidOperationException($"{string.Format(CommonErrors.ThereIsNoDetail,"MARCAR COMO ENVIADA")}");

        if (Status != TransferStatusEnum.Pending)
            throw new InvalidOperationException(TransferErrors.OnlyPendingTransfersCanBeSent);

        SentAt = DateTime.UtcNow;
        SentBy = sentBy;
        Status = TransferStatusEnum.InTransit;
    }
    public void MarkAsCanceled()
    {
        if (Status == TransferStatusEnum.Pending)
            throw new InvalidOperationException(TransferErrors.OnlyPendingTransfersCanBeCanceled);
        Status = TransferStatusEnum.Canceled;
    }
    public void MarkAsReceived(string receivedBy)
    {
        if (_items.Count == 0)
            throw new InvalidOperationException($"{string.Format(CommonErrors.ThereIsNoDetail, "MARCAR COMO RECIVIDA")}");


        if (Status != TransferStatusEnum.InTransit)
            throw new InvalidOperationException(TransferErrors.OnlyInTransitTransfersCanBeReceived);

        ReceivedAt = DateTime.UtcNow;
        ReceivedBy = receivedBy;
        Status = TransferStatusEnum.Completed;
    }
 
   
}
