using HCI_main_project.Model.DTOs;
using HCI_main_project.Model.Services;
using HCI_main_project.Models;
using HCI_main_project.Pages;
using HCI_main_project.ViewModel;
using HCI_main_project.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCI_main_project.Commands.Tours
{
    public class AddTourCommand : CommandBase
    {
        private AddTourPageViewModel _addTourPageViewModel;
        private ITourService _tourService;
        public AddTourCommand(AddTourPageViewModel addTourPageViewModel)
        {
            _addTourPageViewModel = addTourPageViewModel;
            _addTourPageViewModel.RestaurantsDragAndDropControl.PropertyChanged += ViewModel_PropertyChanged;
            _tourService = App.serviceProvider.GetService<ITourService>();
        }

        public override void Execute(object? parameter)
        {
            try
            {
                List<Attraction> attractions = _addTourPageViewModel.AttractionsDragAndDropControl.Attractions2.ToList();
                List<Accommodation> accommodations = _addTourPageViewModel.AccommodationsDragAndDropControl.Accommodations2.ToList();
                List<Restaurant> restaurants = _addTourPageViewModel.RestaurantsDragAndDropControl.Restaurants2.ToList();
                User travelAgent = null;
                string filename = ImageHelper.Save(_addTourPageViewModel.NameAndPhotoFormViewModel.ImageRectangle.Fill as ImageBrush,
                    "Tours", _addTourPageViewModel.NameAndPhotoFormViewModel.File);
                Tour tour = new Tour();
                tour.Name = _addTourPageViewModel.NameAndPhotoFormViewModel.Name;
                tour.Image = filename;
                tour.Description = _addTourPageViewModel.TripDetailsControlViewModel.Description;
                tour.From = (DateTime)_addTourPageViewModel.TripDetailsControlViewModel.DateFrom;
                tour.To = (DateTime)_addTourPageViewModel.TripDetailsControlViewModel.DateTo;
                tour.Price = (double)_addTourPageViewModel.TripDetailsControlViewModel.Price;
                tour.Longitude = 22;
                tour.Latitude = 22;
                try
                {
                    tour.TravelAgent = ApplicationHelper.User;
                } catch (Exception e)
                {
                    tour.TravelAgent = _tourService.GetTravelAgent();
                }

                attractions.ForEach(a => tour.AddAttraction(a));
                accommodations.ForEach(a => tour.AddAccommodation(a));
                restaurants.ForEach(r => tour.AddRestaurant(r));

                _tourService.Add(tour);

                Homepage homePage = new Homepage();
                ApplicationHelper.NavigationService.Navigate(homePage);

                var vm = homePage.DataContext as HomepageViewModel;
                vm.ShowSnackBar("You have successfully created tour!");
            }
            catch (Exception ex)
            {
                _addTourPageViewModel.ShowNegativeSnackBar("Server error. Try again later");
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addTourPageViewModel.RestaurantsDragAndDropControl.Restaurants2))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _addTourPageViewModel.RestaurantsDragAndDropControl.IsValid();
        }
    }
}
