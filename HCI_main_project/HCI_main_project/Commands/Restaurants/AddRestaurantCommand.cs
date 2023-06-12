using HCI_main_project.Model.DTOs;
using HCI_main_project.Model.Services;
using HCI_main_project.Models;
using HCI_main_project.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using HCI_main_project.Pages;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using HCI_main_project.ViewModel;

namespace HCI_main_project.Commands
{
    public class AddRestaurantCommand : CommandBase
    {
        private AddRestaurantPageViewModel _addRestaurantPageViewModel;
        private IRestaurantService _restaurantService;
        public AddRestaurantCommand(AddRestaurantPageViewModel addRestaurantPageViewModel)
        {
            _addRestaurantPageViewModel = addRestaurantPageViewModel;
            _addRestaurantPageViewModel.AddressFormViewModel.PropertyChanged += ViewModel_PropertyChanged;
            _restaurantService = App.serviceProvider.GetService<IRestaurantService>();
        }

        public override void Execute(object? parameter)
        {
            try
            {
                AddressDTO address = new AddressDTO(_addRestaurantPageViewModel.AddressFormViewModel.City,  20000,
                    _addRestaurantPageViewModel.AddressFormViewModel.Street,
                    _addRestaurantPageViewModel.AddressFormViewModel.StreetNo
                    );

                string filename = ImageHelper.Save(_addRestaurantPageViewModel.NameAndPhotoFormViewModel.ImageRectangle.Fill as ImageBrush,
                    "Restaurants", _addRestaurantPageViewModel.NameAndPhotoFormViewModel.File);


                RestaurantDTO restaurant = new RestaurantDTO(_addRestaurantPageViewModel.NameAndPhotoFormViewModel.Name,
                    filename, address,
                    _addRestaurantPageViewModel.AddressFormControl.Latitude,
                    _addRestaurantPageViewModel.AddressFormControl.Longitude);
                _restaurantService.Add(restaurant);
                Homepage homePage = new Homepage();
                ApplicationHelper.NavigationService.Navigate(homePage);

                var vm = homePage.DataContext as HomepageViewModel;
                vm.ShowSnackBar("You have successfully created restaurant!");
            }
            catch (Exception ex)
            {
                _addRestaurantPageViewModel.ShowNegativeSnackBar("Server error. Try again later");
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addRestaurantPageViewModel.AddressFormViewModel.Street)
                || e.PropertyName == nameof(_addRestaurantPageViewModel.AddressFormViewModel.StreetNo)
                || e.PropertyName == nameof(_addRestaurantPageViewModel.AddressFormViewModel.City))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _addRestaurantPageViewModel.AddressFormViewModel.IsFormValid();
        }
    }
}
