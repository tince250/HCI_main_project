using HCI_main_project.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCI_main_project.Commands.Accommodations
{
    public class BackToGeneralInfoButtonAccommodationCommand : CommandBase
    {
        private AddAccommodationPageViewModel _addAccommodationPageViewModel;
        public BackToGeneralInfoButtonAccommodationCommand(AddAccommodationPageViewModel addAccommodationPageViewModel)
        {
            _addAccommodationPageViewModel = addAccommodationPageViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _addAccommodationPageViewModel.IsFillAddressButtonClicked = false;
                _addAccommodationPageViewModel.IsFillGeneralInfoButtonClicked = true;
                _addAccommodationPageViewModel.NameAndPhotoFormControl.Visibility = Visibility.Visible;
                _addAccommodationPageViewModel.NextButtonText = "Fill address info";
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }
    }
}
