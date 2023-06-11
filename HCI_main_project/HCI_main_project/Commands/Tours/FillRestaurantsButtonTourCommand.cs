using HCI_main_project.ViewModels;
using System;
using System.Collections.Generic;
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
                //_addTourPageViewModel.NameAndPhotoFormControl.Visibility = Visibility.Visible;
                _addTourPageViewModel.NextButtonText = "Create tour";
                _addTourPageViewModel.BackButtonText = "Back to accommodations";
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }
    }
}