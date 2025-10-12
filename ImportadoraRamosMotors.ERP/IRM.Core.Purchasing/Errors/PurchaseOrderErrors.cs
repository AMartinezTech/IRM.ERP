namespace IRM.Core.Purchasing.Errors;

public static class PurchaseOrderErrors
{
    public const string CannotModifyNonPendingOrder = "Only pending orders can be modified.";
    public const string DuplicateItemInOrder = "This item is already added to the purchase order.";
    public const string OnlyPendingOrdersCanBeReceived = "Only pending orders can be marked as received.";

}
