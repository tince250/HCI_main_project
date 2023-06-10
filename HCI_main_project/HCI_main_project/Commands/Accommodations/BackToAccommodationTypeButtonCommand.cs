using HCI_main_project.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCI_main_project.Commands.Accommodations
{
    public class BackToAccommodationTypeButtonAccommodationCommand : CommandBase
    {
        private AddAccommodationPageViewModel _addAccommodationPageViewModel;
        public BackToAccommodationTypeButtonAccommodationCommand(AddAccommodationPageViewModel addAccommodationPageViewModel)
        {
            _addAccommodationPageViewModel = addAccommodationPageViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _addAccommodationPageViewModel.IsFillGeneralInfoButtonClicked = false;
                _addAccommodationPageViewModel.AccommodationTypeControl.Visibility = Visibility.Visible;
                _addAccommodationPageViewModel.NextButtonText = "Fill general info";
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }
    }
}
