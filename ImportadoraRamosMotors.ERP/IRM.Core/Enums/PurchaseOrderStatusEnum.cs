using System.ComponentModel.DataAnnotations;

namespace IRM.Core.Enums;

public enum PurchaseOrderStatusEnum
{
    [Display(Name = "Pendiente")]
    Pending,        // Pendiente

    [Display(Name = "Recibida")]
    Received,    // Recibida

     
}
