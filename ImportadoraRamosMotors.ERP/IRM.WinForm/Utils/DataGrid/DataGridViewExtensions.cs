using System.Reflection;

namespace IRM.WinForm.Utils.DataGrid;

internal static class DataGridViewExtensions
{
    public static void EnableDoubleBuffering(this DataGridView dgv)
    {
        typeof(DataGridView).InvokeMember(
            "DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null,
            dgv,
            new object[] { true }
        );
    }
}
