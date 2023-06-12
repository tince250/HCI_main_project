using HCI_main_project.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCI_main_project.Commands.Tours
{
    public class FillDetailsButtonTourCommand : CommandBase
    {
        private AddTourPageViewModel _addTourPageViewModel;
        public FillDetailsButtonTourCommand(AddTourPageViewModel addTourPageViewModel)
        {
            _addTourPageViewModel = addTourPageViewModel;
            _addTourPageViewModel.NameAndPhotoFormViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _addTourPageViewModel.IsFillAccommodationsButtonClicked = false;
                _addTourPageViewModel.IsFillAttractionsButtonClicked = false;
                _addTourPageViewModel.IsFillDetailsButtonClicked = true;
                _addTourPageViewModel.IsFillRestaurantsButtonClicked = false;
                _addTourPageViewModel.IsFillGeneralInfoButtonClicked = false;
                _addTourPageViewModel.TripDetailsControl.Visibility = Visibility.Visible;
                _addTourPageViewModel.NameAndPhotoFormControl.Visibility = Visibility.Collapsed;
                _addTourPageViewModel.NextButtonText = "Select attractions";
                _addTourPageViewModel.BackButtonText = "Back to general info";
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addTourPageViewModel.NameAndPhotoFormViewModel.Name)
                || e.PropertyName == nameof(_addTourPageViewModel.NameAndPhotoFormViewModel.IsImageValid)
                || e.PropertyName == nameof(_addTourPageViewModel.NameAndPhotoFormViewModel.File))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            //return true;
            return _addTourPageViewModel.NameAndPhotoFormViewModel.IsFormValid();
        }


    }
}
