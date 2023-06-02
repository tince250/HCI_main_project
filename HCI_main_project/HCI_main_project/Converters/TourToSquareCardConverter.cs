using HCI_main_project.Model.Entities;
using HCI_main_project.Models;
using HCI_main_project.User_Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HCI_main_project.Converters
{
    public class TourToSquareCardConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Tour tour)
            {
                if (tour != null)
                {
                    var squareCard = new SquareCard();
                    squareCard.Tour = tour;

                    return squareCard;
                }
            }

            if (value is Attraction attraction)
            {
                if (attraction != null)
                {
                    var simplerCard = new SimplerCard();
                    simplerCard.CardContent = new SimpleCardContent(attraction);

                    return simplerCard;
                }
            }

            if (value is Accommodation accommodation)
            {
                if (accommodation != null)
                {
                    var simplerCard = new SimplerCard();
                    simplerCard.CardContent = new SimpleCardContent(accommodation);

                    return simplerCard;
                }
            }

            if (value is Restaurant restaurant)
            {
                if (restaurant != null)
                {
                    var simplerCard = new SimplerCard();
                    simplerCard.CardContent = new SimpleCardContent(restaurant);

                    return simplerCard;
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
