namespace IRM.Core.Inventory.Errors;

public static class StockErrors
{
    public const string CannotIncreaseForVehiculeType = "No se puede aumentar la cantidad de stock del tipo de vehículo.";
    public const string CannotDecreseForVehiculeType = "No se puede disminuir la cantidad de stock del tipo de vehículo.";
    public const string NotEnoughQuantityStock = "No hay suficiente existencia";
}
