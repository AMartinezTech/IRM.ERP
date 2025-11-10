namespace IRM.WinForm.Utils.Messages;

public class MessageColors
{
    public static Color GetColorForMessageType(MessageType type)
    {
        return type switch
        {
            MessageType.Information => AppColors.Info,   // Información: Azul
            MessageType.Error => AppColors.Error,         // Error: Rojo
            MessageType.Warning => AppColors.Warning,    // Advertencia: Naranja
            MessageType.Success => AppColors.Success,     // Éxito: Verde
            _ => Color.Black,                       // Predeterminado: Negro
        };
    }

}