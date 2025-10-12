using System.ComponentModel.DataAnnotations;

namespace IRM.Core.Enums;

public enum ItemType
{
    [Display(Name = "Partes")] 
    Parts,
    
    [Display(Name = "Servicios")] 
    Service,

    [Display(Name = "Moticicleta")] 
    Motocicle
}

