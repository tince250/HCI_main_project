using HCI_main_project.Components;
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
    public partial class TripDetailsPage : Page
    {
        private TripDetailsViewModel viewModel;
        public TripDetailsPage()
        {
            InitializeComponent();
            this.viewModel = App.serviceProvider.GetRequiredService<TripDetailsViewModel>();
            DataContext = viewModel;
            setPushPins();
        }

        private void setPushPins()
        {
            setAttractionsPushPins();
            setRestaurantPushPins();
            setAccommodationsPushPins();
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
            MapPolyline routeLine = new MapPolyline();
            routeLine.Locations = new LocationCollection();
            routeLine.Stroke = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            routeLine.StrokeThickness = 4;
            routeLine.Opacity = 0.7;
            foreach (Attraction attraction in viewModel.Attractions)
            {
                Pushpin Pin = new Microsoft.Maps.MapControl.WPF.Pushpin();
                Pin.Location = new Location(attraction.Latitude, attraction.Longitude);
                Pin.Background = new SolidColorBrush(Color.FromRgb(39, 117, 185));
                this.map.Children.Add(Pin);
                routeLine.Locations.Add(Pin.Location);
            }
            this.map.Children.Add(routeLine);
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

        private void openReservationDialog(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Add(new ConfirmDialog(DialogType.RESERVE_TOUR));
        }

        private void openBookingDialog(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Add(new ConfirmDialog(DialogType.BOOK_TOUR));
        }
    }
}
