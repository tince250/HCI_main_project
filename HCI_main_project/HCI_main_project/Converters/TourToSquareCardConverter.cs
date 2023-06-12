using HCI_main_project.Model.Entities;
using HCI_main_project.Models;
using HCI_main_project.User_Controls;
using HCI_main_project.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
   

            if (value is Tour tour && ApplicationHelper.HomePageVm.SelectedType == "tours")
            {
                if (tour != null)
                {
                    var squareCard = new SquareCard();
                    squareCard.DataContext = new TourCardViewModel(ApplicationHelper.HomePageVm, tour);

                    return squareCard;
                }
            }

            if (value is Attraction attraction)
            {
                if (attraction != null)
                {
                    var simplerCard = new SimplerCard();
                    simplerCard.DataContext = new SimplerCardViewModel(ApplicationHelper.HomePageVm, new SimpleCardContent(attraction), "attraction");

                    return simplerCard;
                }
            }

            if (value is Accommodation accommodation)
            {
                if (accommodation != null)
                {
                    var simplerCard = new SimplerCard();
                    simplerCard.DataContext = new SimplerCardViewModel(ApplicationHelper.HomePageVm, new SimpleCardContent(accommodation), "accommodation");

                    return simplerCard;
                }
            }

            if (value is Restaurant restaurant)
            {
                if (restaurant != null)
                {
                    var simplerCard = new SimplerCard();
                    simplerCard.DataContext = new SimplerCardViewModel(ApplicationHelper.HomePageVm, new SimpleCardContent(restaurant), "restaurant");

                    return simplerCard;
                }
            }

            if (value is Tour tourHistory && ApplicationHelper.HomePageVm.SelectedType == "history")
            {
                if (tourHistory != null)
                {
                    var historyCard = new HistoryCard();

                    return historyCard;
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
