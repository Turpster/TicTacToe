using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace TickTackToe.Converters
{
    public class TurnToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                var val = value as bool?;

                if (val.Value)
                {
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#548E19"));
                }
                else return Brushes.White;
            }
            else throw new ArgumentException("Value must be bool type");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
