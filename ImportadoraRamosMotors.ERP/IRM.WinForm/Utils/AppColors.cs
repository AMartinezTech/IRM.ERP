namespace IRM.WinForm.Utils;

internal static class AppColors
{
    public static Color Surface => ColorTranslator.FromHtml("#F5F5F5"); // Fondo general claro
    public static Color SurfaceVariant => ColorTranslator.FromHtml("#FFFFFF"); // Variante de fondo más brillante
    public static Color SurfaceMessage => ColorTranslator.FromHtml("#F0F0F0"); // Fondo para mensajes o paneles secundarios
    public static Color OnSurface => ColorTranslator.FromHtml("#2A2A2A"); // Texto principal (gris oscuro / casi negro) 
    public static Color Primary => ColorTranslator.FromHtml("#ED1C24"); // Rojo principal del logo 
    public static Color OnPrimary => ColorTranslator.FromHtml("#FFFFFF"); // Texto sobre fondo rojo
    public static Color Secondary => ColorTranslator.FromHtml("#3C3C3B"); // Gris carbón (del “R” en el logo)
    public static Color OnSecondary => ColorTranslator.FromHtml("#FFFFFF"); // Texto sobre gris oscuro
    public static Color Outline => ColorTranslator.FromHtml("#C4C4C4"); // Bordes suaves en gris claro
    public static Color Error => ColorTranslator.FromHtml("#E53935"); // Rojo alerta (más brillante para errores)
    public static Color Warning => ColorTranslator.FromHtml("#FFA000"); // Naranja fuerte (resalta con fondo blanco)
    public static Color Success => ColorTranslator.FromHtml("#4CAF50"); // Verde estándar para éxito
    public static Color Info => ColorTranslator.FromHtml("#757575"); // Gris medio para mensajes informativos 
}
