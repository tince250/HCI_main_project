using HCI_main_project.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCI_main_project.Commands.Accommodations
{
    public class FillGeneralInfoButtonAccommodationCommand : CommandBase
    {
        private AddAccommodationPageViewModel _addAccommodationPageViewModel;
        public FillGeneralInfoButtonAccommodationCommand(AddAccommodationPageViewModel addAccommodationPageViewModel)
        {
            _addAccommodationPageViewModel = addAccommodationPageViewModel;
            _addAccommodationPageViewModel.AccommodationTypeViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _addAccommodationPageViewModel.IsFillGeneralInfoButtonClicked = true;
                _addAccommodationPageViewModel.AccommodationTypeControl.Visibility = Visibility.Collapsed;
                _addAccommodationPageViewModel.AddressFormControl.Visibility = Visibility.Visible;
                _addAccommodationPageViewModel.NextButtonText = "Fill address info";
                _addAccommodationPageViewModel.BackButtonText = "Back to nzm";
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }
        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addAccommodationPageViewModel.AccommodationTypeViewModel.IsApartmentSelected)
                || e.PropertyName == nameof(_addAccommodationPageViewModel.AccommodationTypeViewModel.IsHotelSelected))
            {
                OnCanExecuteChanged();
            }
            
        }

        public override bool CanExecute(object? parameter)
        {
            return _addAccommodationPageViewModel.AccommodationTypeViewModel.IsValid();
        }
    }
}
