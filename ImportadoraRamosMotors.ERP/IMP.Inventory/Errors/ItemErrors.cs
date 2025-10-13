using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IRM.Core.Inventory.Errors;

public static class ItemErrors
{
    public const string PriceMustBeGrandTheCost = "El costo de ser mayo al precio.";
    public const string ItemDetailCannotBeNull = "El detalle de artículo no puede estár vacío.";
 
}
