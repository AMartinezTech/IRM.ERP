namespace IRM.WinForm.Utils.Messages;

public class HandlerMessages
{
    // Contenido del mensaje
    public string Message { get; set; }
    public Color MessageColor { get; private set; }
    public MessageType Type { get; set; }
    public string Icon { get; private set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;

    public HandlerMessages(string message, MessageType type = MessageType.Information)
    {
        Message = message;
        Type = type;
        MessageColor = MessageColors.GetColorForMessageType(type);
        Icon = GetIconForMessageType(type);
    }

    private string GetIconForMessageType(MessageType type)
    {
        return type switch
        {
            MessageType.Information => "ℹ️",    // Información: ícono de información
            MessageType.Error => "❌",          // Error: ícono de error
            MessageType.Warning => "⚠️",       // Advertencia: ícono de advertencia
            MessageType.Success => "✅",        // Éxito: ícono de check
            _ => "❔",                          // Predeterminado: ícono de pregunta
        };
    }
    public override string ToString()
    {
        return $"{Icon} [{Timestamp}] {Type}: {Message}";
    }



}
