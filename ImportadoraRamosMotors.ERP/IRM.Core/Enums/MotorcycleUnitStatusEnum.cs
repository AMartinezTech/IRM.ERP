using System.ComponentModel.DataAnnotations;

namespace IRM.Core.Enums;

public enum MotorcycleUnitStatusEnum
{
    [Display(Name = "Orden de compra")] // Cuando se negocia con el proveedor pero las motocicleta se han recibido aun
    PurchaseOrder,

    [Display(Name = "En Almacén")] // Cuando se reciben las motocicleta 
    InWarehouse,

    [Display(Name = "En Tránsito")] // Cuando salen del almacén  a las sucursales, debe ir con el proceso de inspeción al salir de InWarehouse
    InTransit,

    [Display(Name = "Inventario")] // Cuando la sucursales la reciben, debe ir con el proceso de inspeción para confirma en inventario
    Inventory,

    [Display(Name = "Vendida")] // Cuando se vende desde una de la sucursales
    Sold,

    [Display(Name = "Robada")]
    Stolen,

    [Display(Name = "Dañada")]
    Damaged,

    [Display(Name = "Desmantelada")]
    Dismantled
}
