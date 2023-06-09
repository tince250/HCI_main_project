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
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCI_main_project.Commands
{
    public class EditRestaurantCommand : CommandBase
    {
        private AddRestaurantPageViewModel _addRestaurantPageViewModel;
        private IRestaurantService _restaurantService;
        public EditRestaurantCommand(AddRestaurantPageViewModel addRestaurantPageViewModel)
        {
            _addRestaurantPageViewModel = addRestaurantPageViewModel;
            _addRestaurantPageViewModel.AddressFormViewModel.PropertyChanged += ViewModel_PropertyChanged;
            _restaurantService = App.serviceProvider.GetService<IRestaurantService>();
        }

        public override void Execute(object? parameter)
        {
            try
            {
                //Trace.WriteLine(_addRestaurantPageViewModel.NameAndPhotoFormControl.vM);
                AddressDTO address = new AddressDTO(_addRestaurantPageViewModel.AddressFormViewModel.City, 20000,
                    _addRestaurantPageViewModel.AddressFormViewModel.Street,
                    int.Parse(_addRestaurantPageViewModel.AddressFormViewModel.StreetNo)
                    );
                ImageHelper.RemoveOld("Restaurants",_addRestaurantPageViewModel.SelectedRestaurant.Image);
                string filename = ImageHelper.Save(_addRestaurantPageViewModel.NameAndPhotoFormViewModel.ImageRectangle.Fill as ImageBrush,
                    "Restaurants", _addRestaurantPageViewModel.NameAndPhotoFormViewModel.File, false);

                RestaurantDTO restaurant = new RestaurantDTO(_addRestaurantPageViewModel.NameAndPhotoFormViewModel.Name,
                    filename, address);
                _restaurantService.Edit(11, restaurant);
            }
            catch (Exception ex)
            {
                ex.GetType();
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
