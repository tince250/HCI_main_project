using HCI_main_project.Models;
using HCI_main_project.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCI_main_project.View
{
    /// <summary>
    /// Interaction logic for TripDetails.xaml
    /// </summary>
    public partial class TripDetails : Page
    {
        private TripDetailsViewModel viewModel;
        public TripDetails()
        {
            InitializeComponent();
            this.viewModel = App.serviceProvider.GetRequiredService<TripDetailsViewModel>();
            DataContext = viewModel;
            setPushPins();
        }

        private void setPushPins()
        {
            setRestaurantPushPins();
            setAccommodationsPushPins();
            setAttractionsPushPins();
        }

        private void setRestaurantPushPins()
        {
            foreach (Restaurant restaurant in viewModel.Restaurants)
            {
                Pushpin Pin = new Microsoft.Maps.MapControl.WPF.Pushpin();
                Pin.Location = new Location(restaurant.Latitude, restaurant.Longitude);
                Pin.Background = new SolidColorBrush(Color.FromRgb(24, 179, 21));
                this.map.Children.Add(Pin);
            }
        }

        private void setAttractionsPushPins()
        {
            foreach (Attraction attraction in viewModel.Attractions)
            {
                Pushpin Pin = new Microsoft.Maps.MapControl.WPF.Pushpin();
                Pin.Location = new Location(attraction.Latitude, attraction.Longitude);
                Pin.Background = new SolidColorBrush(Color.FromRgb(39, 117, 185));
                this.map.Children.Add(Pin);
            }
        }

        private void setAccommodationsPushPins()
        {
            foreach (Accommodation accommodation in viewModel.Accommodations)
            {
                Pushpin Pin = new Microsoft.Maps.MapControl.WPF.Pushpin();
                Pin.Location = new Location(accommodation.Latitude, accommodation.Longitude);
                Pin.Background = new SolidColorBrush(Color.FromRgb(232, 170, 42));
                this.map.Children.Add(Pin);
            }
        }
    }
}
