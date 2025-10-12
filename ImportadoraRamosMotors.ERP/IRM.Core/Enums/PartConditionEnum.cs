using System.ComponentModel.DataAnnotations;

namespace IRM.Core.Enums;

public enum PartConditionEnum
{
    [Display(Name = "Buena")]
    Good,

    [Display(Name = "Dañada")]
    Damaged,

    [Display(Name = "Falta")]
    Missing
}
