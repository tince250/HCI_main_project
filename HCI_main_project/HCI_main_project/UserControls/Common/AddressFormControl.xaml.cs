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
        public AddressFormControl()
        {
            InitializeComponent();
            map.Center = new Location(44.0165, 21.0059);
            map.ZoomLevel = 6.5;
        }

        async void MyMap_PointerPressedOverride(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(map);
            Location pinLocation = map.ViewportPointToLocation(mousePosition);
            Pushpin pin = new Pushpin();
            pin.Location = pinLocation;
            map.Children.Add(pin);

            var locationService = new LocationService();
            var address = await locationService.GetAddress(pinLocation.Latitude, pinLocation.Latitude);
            streetTextBox.Text = address;
        }
    }
}
