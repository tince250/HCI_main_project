using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace HCI_main_project.Converters
{
    class TextToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = (string)value;
            if (str == null) return new SolidColorBrush(Colors.Black);
            return str.Equals("reserve") ? new SolidColorBrush(Color.FromRgb(232, 170, 42)) :
                str.Equals("book") ? new SolidColorBrush(Color.FromRgb(39, 117, 185)) :
                str.Equals("delete") ? new SolidColorBrush(Color.FromRgb(148,38,38)) :
                new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
