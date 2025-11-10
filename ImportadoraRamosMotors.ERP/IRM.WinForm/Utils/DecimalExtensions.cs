using System.Globalization;

namespace IRM.WinForm.Utils;

public static class DecimalExtensions
{
    public static bool TryParseDecimal(this string input, out decimal result, decimal defaultValue = 0m)
    {
        if (decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
        {
            return true;
        }

        result = defaultValue;
        return false;
    }
}
