using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace HCI_main_project.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string imagePath && !string.IsNullOrEmpty(imagePath))
            {
                // Check if the image file exists
                if (File.Exists(imagePath))
                {
                    // Return the valid image source
                    return new BitmapImage(new Uri(Path.GetFullPath(imagePath)));
                }
            }

            // Return the default image source
            return new BitmapImage(new Uri("pack://application:,,,/Images/Tours/hram.jpg"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
