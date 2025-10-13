namespace IRM.Core.Purchasing.PurcharseOrders;

using IRM.Core.Exceptions;


public class PurcharseOrderItemEntity
{
    public Guid Id { get; private set; }
    public Guid PurchaseOrderId { get; private set; }
    public Guid MotorcycleUnitId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    private PurcharseOrderItemEntity() { }

    private PurcharseOrderItemEntity(Guid purchaseOrderId, Guid motorcycleUnitId, int quantity, decimal unitPrice)
    {
        if (quantity <= 0)
            throw new ValidationException($"{string.Format(CommonErrors.MustBeGreaterThanZero, "Quantity")} - {nameof(Quantity)}");
        if (unitPrice <= 0)
            throw new ValidationException($"{string.Format(CommonErrors.MustBeGreaterThanZero, "UnitPrice")} - {nameof(UnitPrice)}");

        Id = Guid.NewGuid();
        PurchaseOrderId = purchaseOrderId;
        MotorcycleUnitId = motorcycleUnitId;
        Quantity = quantity;
        UnitPrice = unitPrice;

       
    }

    public static PurcharseOrderItemEntity Create(Guid purchaseOrderId, Guid itemId, int quantity, decimal unitPrice)
    {
        return new PurcharseOrderItemEntity(purchaseOrderId, itemId, quantity, unitPrice);
    }
}

