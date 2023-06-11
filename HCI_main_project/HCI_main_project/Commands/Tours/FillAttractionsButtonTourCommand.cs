using HCI_main_project.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace HCI_main_project.Commands.Tours
{
    public class FillAttractionsButtonTourCommand : CommandBase
    {
        private AddTourPageViewModel _addTourPageViewModel;
        public FillAttractionsButtonTourCommand(AddTourPageViewModel addTourPageViewModel)
        {
            _addTourPageViewModel = addTourPageViewModel;
            _addTourPageViewModel.TripDetailsControlViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _addTourPageViewModel.IsFillAccommodationsButtonClicked = false;
                _addTourPageViewModel.IsFillAttractionsButtonClicked = true;
                _addTourPageViewModel.IsFillDetailsButtonClicked = false;
                _addTourPageViewModel.IsFillRestaurantsButtonClicked = false;
                _addTourPageViewModel.IsFillGeneralInfoButtonClicked = false;
                //_addTourPageViewModel.NameAndPhotoFormControl.Visibility = Visibility.Visible;
                _addTourPageViewModel.NextButtonText = "Select accomodations";
                _addTourPageViewModel.BackButtonText = "Back to details";
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addTourPageViewModel.TripDetailsControlViewModel.Price)
                || e.PropertyName == nameof(_addTourPageViewModel.TripDetailsControlViewModel.DateTo)
                || e.PropertyName == nameof(_addTourPageViewModel.TripDetailsControlViewModel.DateFrom))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _addTourPageViewModel.TripDetailsControlViewModel.IsFormValid();
        }
    }
}