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
    public class FillAddressButtonAccommodationCommand : CommandBase
    {
        private AddAccommodationPageViewModel _addAccommodationPageViewModel;
        public FillAddressButtonAccommodationCommand(AddAccommodationPageViewModel addAccommodationPageViewModel)
        {
            _addAccommodationPageViewModel = addAccommodationPageViewModel;
            _addAccommodationPageViewModel.NameAndPhotoFormViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _addAccommodationPageViewModel.IsFillAddressButtonClicked = true;
                _addAccommodationPageViewModel.IsFillGeneralInfoButtonClicked = false;
                _addAccommodationPageViewModel.NameAndPhotoFormControl.Visibility = Visibility.Collapsed;
                _addAccommodationPageViewModel.BackButtonText = "Back to general info";
                if (_addAccommodationPageViewModel.SelectedAccommodation == null)
                    _addAccommodationPageViewModel.NextButtonText = "Create accommodation";
                else
                    _addAccommodationPageViewModel.NextButtonText = "Update accommodation";
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }
        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addAccommodationPageViewModel.NameAndPhotoFormViewModel.Name)
                || e.PropertyName == nameof(_addAccommodationPageViewModel.NameAndPhotoFormViewModel.IsImageValid)
                || e.PropertyName == nameof(_addAccommodationPageViewModel.NameAndPhotoFormViewModel.File))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _addAccommodationPageViewModel.NameAndPhotoFormViewModel.IsFormValid();
        }
    }
}