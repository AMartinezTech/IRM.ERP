namespace IRM.Core.Inventory.Errors;

public static class InventoryErrors
{
    public const string OnlyTransferCanBeInTransit = "Sólo los movimientos de transferencia se pueden marcar como En tránsito.";
    public const string MustBePendingToTransit = "El movimiento debe estar pendiente antes de marcarlo como en tránsito.";
    public const string OnlyInTransitOrPendingCanBeCompleted = "Sólo se podrán completar movimientos en tránsito o pendientes.";
    public const string InspectionCanOnlyVehicle = "";

    public const string CompletedMovementsCannotBeCanceled = "Los movimientos completados no se pueden cancelar.";
    public const string QuantityCannotBeZero = "La cantidad debe ser mayor que cero.";
}

