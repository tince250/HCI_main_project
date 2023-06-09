﻿using HCI_main_project.Components;
using HCI_main_project.Help;
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
        public TripDetailsViewModel viewModel { get; set; }
        public TripDetailsPage()
        {
            InitializeComponent();
            this.viewModel = new TripDetailsViewModel(App.serviceProvider.GetRequiredService<TripagoContext>());
            DataContext = viewModel;
            setPushPins();
            this.map.ZoomLevel = 11.5;
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
                this.map.Center = Pin.Location;
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
                this.map.Center = Pin.Location;
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
                this.map.Center = Pin.Location;
                this.map.Children.Add(Pin);
            }
        }

        private void openReservationDialog(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Add(new ConfirmDialog(DialogType.RESERVE_TOUR, viewModel));
        }

        private void openCancelDialog(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Add(new ConfirmDialog(DialogType.DELETE_RESERVATION, viewModel));
        }

        private void openBookingDialog(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Add(new ConfirmDialog(DialogType.BOOK_TOUR, viewModel));
        }

        private void openReservationsDialog(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Add(new UsersInTourDialog());
        }

        public void openReservationDialogShortcut()
        {
            mainGrid.Children.Add(new ConfirmDialog(DialogType.RESERVE_TOUR, viewModel));
        }

        public void openCancelDialogShortcut()
        {
            mainGrid.Children.Add(new ConfirmDialog(DialogType.DELETE_RESERVATION, viewModel));
        }

        public void openBookingDialogShortcut()
        {
            mainGrid.Children.Add(new ConfirmDialog(DialogType.BOOK_TOUR, viewModel));
        }

        public void openReservationsDialogShortcut()
        {
            mainGrid.Children.Add(new UsersInTourDialog());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicationHelper.User.Role == UserRole.AGENT)
                HelpProvider.SetHelpKey((DependencyObject)this, "DetailsHelpAgent");
            else
                HelpProvider.SetHelpKey((DependencyObject)this, "DetailsHelpTraveler");
            string str = HelpProvider.GetHelpKey((DependencyObject)this);
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            HelpProvider.ShowHelp(str, mainWindow);
        }
    }
}
