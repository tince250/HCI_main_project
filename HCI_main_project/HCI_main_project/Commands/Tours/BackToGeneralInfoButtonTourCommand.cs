using HCI_main_project.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCI_main_project.Commands.Tours
{
    public class BackToGeneralInfoButtonTourCommand : CommandBase
    {
        private AddTourPageViewModel _addTourPageViewModel;
        public BackToGeneralInfoButtonTourCommand(AddTourPageViewModel addTourPageViewModel)
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
                _addTourPageViewModel.IsFillRestaurantsButtonClicked = false;
                _addTourPageViewModel.IsFillGeneralInfoButtonClicked = true;
                _addTourPageViewModel.NameAndPhotoFormControl.Visibility = Visibility.Visible;
                _addTourPageViewModel.NextButtonText = "Fill details info";
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }
    }
}
