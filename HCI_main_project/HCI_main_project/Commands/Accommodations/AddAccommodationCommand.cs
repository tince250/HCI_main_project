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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using HCI_main_project.Pages;
using HCI_main_project.ViewModel;

namespace HCI_main_project.Commands.Accommodations
{
    public class AddAccommodationCommand : CommandBase
    {
        private AddAccommodationPageViewModel _addAccommodationPageViewModel;
        private IAccommodationService _accommodationService;
        public AddAccommodationCommand(AddAccommodationPageViewModel addAccommodationPageViewModel)
        {
            _addAccommodationPageViewModel = addAccommodationPageViewModel;
            _addAccommodationPageViewModel.AddressFormViewModel.PropertyChanged += ViewModel_PropertyChanged;
            _accommodationService = App.serviceProvider.GetService<IAccommodationService>();
        }

        public override void Execute(object? parameter)
        {
            try
            {
                AddressDTO address = new AddressDTO(_addAccommodationPageViewModel.AddressFormViewModel.City, 20000,
                    _addAccommodationPageViewModel.AddressFormViewModel.Street,
                    _addAccommodationPageViewModel.AddressFormViewModel.StreetNo
                    );

                string filename = ImageHelper.Save(_addAccommodationPageViewModel.NameAndPhotoFormViewModel.ImageRectangle.Fill as ImageBrush,
                    "Accommodations", _addAccommodationPageViewModel.NameAndPhotoFormViewModel.File);

                AccommodationType type = _addAccommodationPageViewModel.AccommodationTypeViewModel.IsHotelSelected ? AccommodationType.HOTEL : AccommodationType.APARTMENT;

                AccommodationDTO accommodation = new AccommodationDTO(_addAccommodationPageViewModel.NameAndPhotoFormViewModel.Name,
                    filename, type, address,
                    _addAccommodationPageViewModel.AddressFormControl.Latitude,
                    _addAccommodationPageViewModel.AddressFormControl.Longitude);
                _accommodationService.Add(accommodation);

                Homepage homePage = new Homepage();
                ApplicationHelper.NavigationService.Navigate(homePage);

                var vm = homePage.DataContext as HomepageViewModel;
                vm.ShowSnackBar("You have successfully created accommodation!");
            }
            catch (Exception ex)
            {
                _addAccommodationPageViewModel.ShowNegativeSnackBar("Server error. Try again later");
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addAccommodationPageViewModel.AddressFormViewModel.Street)
                || e.PropertyName == nameof(_addAccommodationPageViewModel.AddressFormViewModel.StreetNo)
                || e.PropertyName == nameof(_addAccommodationPageViewModel.AddressFormViewModel.City))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _addAccommodationPageViewModel.AddressFormViewModel.IsFormValid();
        }
    }
}
