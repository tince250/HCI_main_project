using HCI_main_project.Components;
using HCI_main_project.Model.Entities;
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
    class TourToDetailsCardConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value is Attraction attraction)
            {
                if (attraction != null)
                {
                    var detailsCard = new DetailsCard();
                    detailsCard.DetailsContent = new DetailsCardContent(attraction);

                    return detailsCard;
                }
            }
            if (value is Accommodation accommodation)
            {
                if (accommodation != null)
                {
                    var detailsCard = new DetailsCard();
                    detailsCard.DetailsContent = new DetailsCardContent(accommodation);

                    return detailsCard;
                }
            }
            if (value is Restaurant restaurant)
            {
                if (restaurant != null)
                {
                    var detailsCard = new DetailsCard();
                    detailsCard.DetailsContent = new DetailsCardContent(restaurant);

                    return detailsCard;
                }
            }

            if (value is Tour tour)
            {
                if (tour != null)
                {
                    var detailsCard = new DetailsCard();
                    detailsCard.DetailsContent = new DetailsCardContent(tour);

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
