using System.ComponentModel.DataAnnotations;

namespace IRM.Core.Enums;

public enum MotorcycleCondition
{
    [Display(Name = "Nuevo")] 
    New,        // Nuevo

    [Display(Name = "Semi nuevo")]
    SemiNew,    // Semi nuevo

    [Display(Name = "Usada")]
    Used        // Usado
}
