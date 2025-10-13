using IRM.Core.BaseEntities;
using IRM.Core.Enums;
using IRM.Core.Exceptions;
using IRM.Core.Purchasing.Errors;

namespace IRM.Core.Purchasing.PurcharseOrders;

public class PurcharseOrderEntity : EntityBase
{

    public string Code { get; private set; }    
    public DateTime? ReceivedAt { get; private set; }
    public PurchaseOrderStatusEnum Status { get; private set; }     
    public string? ReceivedBy { get; private set; }               
    public IReadOnlyCollection<PurcharseOrderItemEntity> Items => _items.AsReadOnly();

    private readonly List<PurcharseOrderItemEntity> _items = [];

    private PurcharseOrderEntity(string code, Guid createdBy)
    {
        Id = Guid.NewGuid();
        Code = code;
        CreatedAt = DateTime.UtcNow;
        CreatedBy = createdBy;
        Status = PurchaseOrderStatusEnum.Pending;
        Validate();
    }

    public static PurcharseOrderEntity Create(string code, Guid createdBy)
    {
        return new PurcharseOrderEntity(code, createdBy);
    }

    public void AddItem(Guid itemId, int quantity, decimal unitPrice)
    {
        if (Status != PurchaseOrderStatusEnum.Pending)
            throw new InvalidOperationException(PurchaseOrderErrors.CannotModifyNonPendingOrder);

        if (_items.Exists(i => i.MotorcycleUnitId == itemId))
            throw new ValidationException(PurchaseOrderErrors.DuplicateItemInOrder);

        _items.Add(PurcharseOrderItemEntity.Create(Id, itemId, quantity, unitPrice));
    }
    public void MarkAsReceived(string receivedBy)
    {
        if (Status != PurchaseOrderStatusEnum.Pending)
            throw new InvalidOperationException(PurchaseOrderErrors.OnlyPendingOrdersCanBeReceived);

        ReceivedAt = DateTime.UtcNow;
        ReceivedBy = receivedBy;
        Status = PurchaseOrderStatusEnum.Received;
    }
 
    public override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Code))
            throw new ValidationException("Purchase order code is required.");
        if (CreatedBy == Guid.Empty)
            throw new ValidationException("CreatedBy is required.");
    }
}
