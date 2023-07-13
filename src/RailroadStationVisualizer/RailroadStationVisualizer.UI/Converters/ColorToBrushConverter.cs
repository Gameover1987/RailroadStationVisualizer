using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace RailroadStationVisualizer.UI.Converters
{
    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var color = (Color) value;

            var brush = new SolidColorBrush(color);
            brush.Freeze();

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
