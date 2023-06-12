using HCI_main_project.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCI_main_project.Commands
{
    public class FillAddressButtonRestaurantCommand : CommandBase
    {
        private AddRestaurantPageViewModel _addRestaurantPageViewModel;
        public FillAddressButtonRestaurantCommand(AddRestaurantPageViewModel addRestaurantPageViewModel)
        {
            _addRestaurantPageViewModel = addRestaurantPageViewModel;
            _addRestaurantPageViewModel.NameAndPhotoFormViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _addRestaurantPageViewModel.IsFillAddressButtonClicked = true;
                _addRestaurantPageViewModel.NameAndPhotoFormControl.Visibility = Visibility.Collapsed;
                if (_addRestaurantPageViewModel.SelectedRestaurant == null)
                    _addRestaurantPageViewModel.NextButtonText = "Create restaurant";
                else
                    _addRestaurantPageViewModel.NextButtonText = "Update restaurant";
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }
        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addRestaurantPageViewModel.NameAndPhotoFormViewModel.Name)
                || e.PropertyName == nameof(_addRestaurantPageViewModel.NameAndPhotoFormViewModel.IsImageValid)
                || e.PropertyName == nameof(_addRestaurantPageViewModel.NameAndPhotoFormViewModel.File))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _addRestaurantPageViewModel.NameAndPhotoFormViewModel.IsFormValid();
        }
    }
}
