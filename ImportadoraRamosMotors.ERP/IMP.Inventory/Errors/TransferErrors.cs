namespace IRM.Core.Inventory.Errors;

public static class TransferErrors
{
    public const string SourceAndTargetMustBeDifferent = "Los almacenes de origen y de destino deben ser diferentes.";
    public const string CannotModifyNonPendingTransfer = "Sólo se pueden modificar las transferencias pendientes.";
    public const string DuplicateMotorcycleInTransfer = "Esta motocicleta ya está incluida en el traslado.";
    public const string OnlyPendingTransfersCanBeSent = "Sólo se pueden enviar transferencias pendientes.";
    public const string OnlyInTransitTransfersCanBeReceived = "Solamente se podrán recibir transferencias en tránsito.";
}
