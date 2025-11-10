namespace IRM.Core.Exceptions;

public static class CommonErrors
{
   
    public const string NotValidCredencials = "Credenciales invalidas.";
    public const string RequiredField = "El campo {0} es requerido.";
    public const string InvalidValue = "Valor invalido para el campo {0}.";
    public const string OutOfRange = "El valor del campo {0} está fuera del rango permitido.";
    public const string MustBeGreaterThanZero = "El valor del campo {0} debe ser mayor a cero!";
    public const string CannotBeModifiedHasMovement = "{0} no se puede modificar, ya tiene movimientos!";
    public const string CannotBeDeletedHasMovement = "{0} no se puede borrar, ya tiene movimientos!";
    public const string RegisterNotFound = "No se encontró el registro solicitado!";
    public const string NoFilterResults = "No se encontraron resultados!";
    public const string RegisterAlreadyExists = "El registro ya existe.";
    public const string ThereIsNoDetail = "No se puede realizar {0} sin detalles.";
    public const string ErrorToCreate = "Error al crear {0}. Detalle - {1}.";
    public const string ErrorToUpdate = "Error al actualizar {0}. Detalle - {1}.";
    public const string ErrorToDelete = "Error al eliminar {0}. Detalle - {1}.";
    public const string ErrorToGet = "Error al eliminar {0}. Detalle - {1}.";
}
