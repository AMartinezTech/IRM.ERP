using System.ComponentModel.DataAnnotations;

namespace IRM.Core.Enums;

public enum MovementTypeEnum
{
    [Display(Name = "Entrada")] 
    Entry, 
     
    [Display(Name = "Transferencia")] 
    Transfer
}
