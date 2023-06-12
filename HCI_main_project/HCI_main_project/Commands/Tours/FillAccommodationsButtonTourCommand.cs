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
    internal class FillAccommodationsButtonTourCommand : CommandBase
    {
        private AddTourPageViewModel _addTourPageViewModel;
        public FillAccommodationsButtonTourCommand(AddTourPageViewModel addTourPageViewModel)
        {
            _addTourPageViewModel = addTourPageViewModel;
            _addTourPageViewModel.AttractionsDragAndDropControl.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _addTourPageViewModel.IsFillAccommodationsButtonClicked = true;
                _addTourPageViewModel.IsFillAttractionsButtonClicked = false;
                _addTourPageViewModel.IsFillDetailsButtonClicked = false;
                _addTourPageViewModel.IsFillRestaurantsButtonClicked = false;
                _addTourPageViewModel.IsFillGeneralInfoButtonClicked = false;
                _addTourPageViewModel.NameAndPhotoFormControl.Visibility = Visibility.Collapsed;
                //_addTourPageViewModel.NameAndPhotoFormControl.Visibility = Visibility.Visible;
                _addTourPageViewModel.NextButtonText = "Select restaurants";
                _addTourPageViewModel.BackButtonText = "Back to attractions";
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addTourPageViewModel.AttractionsDragAndDropControl.Attractions2))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _addTourPageViewModel.AttractionsDragAndDropControl.IsValid();
        }
    }
}
