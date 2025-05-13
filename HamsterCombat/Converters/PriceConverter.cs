using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterCombat.Converters;

public class PriceConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is float price && parameter is object[] parameters && parameters.Length == 2)
        {
            int level = (int)parameters[0];
            float ratio = (float)parameters[1];
            return (price * level * ratio).ToString("0.00");
        }
        return "0.00";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
