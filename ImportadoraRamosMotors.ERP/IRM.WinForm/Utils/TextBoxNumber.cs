namespace IRM.WinForm.Utils;

public static class TextBoxNumber
{
    public static void AllowDecimalNumbers(this TextBox textBox)
    {
        textBox.KeyPress += (sender, e) =>
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && !char.IsControl(e.KeyChar))
            {
                // Permitir un solo punto decimal o coma decimal
                if ((e.KeyChar == '.' || e.KeyChar == ',') && !textBox.Text.Contains('.') && !textBox.Text.Contains(','))
                {
                    return;
                }

                e.Handled = true;
            }
        };
    }

    public static void AllowIntNumbers(this TextBox textBox)
    {
        textBox.KeyPress += (sender, e) =>
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        };
    }
}