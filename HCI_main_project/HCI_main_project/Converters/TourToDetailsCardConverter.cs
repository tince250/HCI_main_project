using HCI_main_project.Components;
using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HCI_main_project.Converters
{
    class TourToSquareCardConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value is Attraction attraction)
            {
                if (attraction != null)
                {
                    var detailsCard = new DetailsCard();
                    detailsCard.Attraction = attraction;

                    return detailsCard;
                }
            }


            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
