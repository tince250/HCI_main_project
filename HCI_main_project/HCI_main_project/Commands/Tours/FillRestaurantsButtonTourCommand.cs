using HCI_main_project.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace HCI_main_project.Commands.Tours
{
    public class FillRestaurantsButtonTourCommand : CommandBase
    {
        private AddTourPageViewModel _addTourPageViewModel;
        public FillRestaurantsButtonTourCommand(AddTourPageViewModel addTourPageViewModel)
        {
            _addTourPageViewModel = addTourPageViewModel;
            _addTourPageViewModel.AccommodationsDragAndDropControl.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _addTourPageViewModel.IsFillAccommodationsButtonClicked = false;
                _addTourPageViewModel.IsFillAttractionsButtonClicked = false;
                _addTourPageViewModel.IsFillDetailsButtonClicked = false;
                _addTourPageViewModel.IsFillRestaurantsButtonClicked = true;
                _addTourPageViewModel.IsFillGeneralInfoButtonClicked = false;
                _addTourPageViewModel.NameAndPhotoFormControl.Visibility = Visibility.Collapsed;
                _addTourPageViewModel.NextButtonText = "Create tour";
                if (_addTourPageViewModel.SelectedTour != null)
                    _addTourPageViewModel.NextButtonText = "Update tour";
                _addTourPageViewModel.BackButtonText = "Back to accommodations";
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addTourPageViewModel.AccommodationsDragAndDropControl.Accommodations2))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _addTourPageViewModel.AccommodationsDragAndDropControl.IsValid();
        }
    }
}