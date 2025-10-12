using IRM.Core.BaseEntities;
using IRM.Core.Enums;
using IRM.Core.Exceptions;
using IRM.Core.Purchasing.Errors;

namespace IRM.Core.Purchasing.PurcharseOrders;

public class PurchaseOrder : EntityBase
{

    public string Code { get; private set; }                       // Código o correlativo 
    public DateTime? ReceivedAt { get; private set; }
    public PurchaseOrderStatusEnum Status { get; private set; }    // Estado de la orden 
    public string? ReceivedBy { get; private set; }                // Usuario que recibe
    public IReadOnlyCollection<PurchaseOrderItem> Items => _items.AsReadOnly();

    private readonly List<PurchaseOrderItem> _items = [];

    private PurchaseOrder() { }

    private PurchaseOrder(string code, Guid createdBy)
    {
        Id = Guid.NewGuid();
        Code = code;
        CreatedAt = DateTime.UtcNow;
        CreatedBy = createdBy;
        Status = PurchaseOrderStatusEnum.Pending;
        Validate();
    }

    public static PurchaseOrder Create(string code, Guid createdBy)
    {
        return new PurchaseOrder(code, createdBy);
    }

    public void AddItem(Guid itemId, int quantity, decimal unitPrice)
    {
        if (Status != PurchaseOrderStatusEnum.Pending)
            throw new InvalidOperationException(PurchaseOrderErrors.CannotModifyNonPendingOrder);

        if (_items.Exists(i => i.MotorcycleUnitId == itemId))
            throw new ValidationException(PurchaseOrderErrors.DuplicateItemInOrder);

        _items.Add(PurchaseOrderItem.Create(Id, itemId, quantity, unitPrice));
    }
    public void MarkAsReceived(string receivedBy)
    {
        if (Status != PurchaseOrderStatusEnum.Pending)
            throw new InvalidOperationException(PurchaseOrderErrors.OnlyPendingOrdersCanBeReceived);

        ReceivedAt = DateTime.UtcNow;
        ReceivedBy = receivedBy;
        Status = PurchaseOrderStatusEnum.Received;
    }
    public override void MarkAsActive() => IsActive = true;

    public override void MarkAsInactive() => IsActive = false;

    public override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Code))
            throw new ValidationException("Purchase order code is required.");
        if (CreatedBy == Guid.Empty)
            throw new ValidationException("CreatedBy is required.");
    }
}
