using System.ComponentModel.DataAnnotations;

namespace IRM.Core.Enums;

public enum TransferStatusEnum
{
    [Display(Name = "Pendiente")]
    Pending,

    [Display(Name = "En transito")]
    InTransit,

    [Display(Name = "Completada")]
    Completed,

    [Display(Name = "Cancelada")]
    Canceled
}
