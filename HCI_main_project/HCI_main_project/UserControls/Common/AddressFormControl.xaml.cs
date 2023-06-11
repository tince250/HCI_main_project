using Castle.DynamicProxy;
using HCI_main_project.Model.Services;
using HCI_main_project.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
using Windows.UI.Xaml.Input;

namespace HCI_main_project.UserControls
{
    /// <summary>
    /// Interaction logic for AddressFormControl.xaml
    /// </summary>
    public partial class AddressFormControl : UserControl
    {
        private LocationService service;
        public AddressFormControl()
        {
            InitializeComponent();
            service = new LocationService();
            map.Center = new Location(44.0165, 21.0059);
            map.ZoomLevel = 6.5;
        }

        async void PointerPressed(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(map);
            Location pinLocation = map.ViewportPointToLocation(mousePosition);
            Pushpin pin = new Pushpin();
            pin.Location = pinLocation;
            map.Children.Clear();
            map.Children.Add(pin);

            AddressFormViewModel viewModel = this.DataContext as AddressFormViewModel;
            service.GetAddress(pinLocation.Latitude, pinLocation.Longitude, viewModel);
        }

        async void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            AddressFormViewModel viewModel = this.DataContext as AddressFormViewModel;
            string address = viewModel.Street + " " + viewModel.StreetNo;
            var location = service.getLocationByAddress(address, viewModel.City);

            Pushpin pin = new Pushpin();
            pin.Location = await location;
            map.Children.Clear();
            map.Children.Add(pin);
            map.Center = (pin.Location);
            map.ZoomLevel = 15;
        }
    }
}
