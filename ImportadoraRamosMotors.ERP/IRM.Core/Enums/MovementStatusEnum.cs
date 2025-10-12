using System.ComponentModel.DataAnnotations;

namespace IRM.Core.Enums;

public enum MovementStatusEnum
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
