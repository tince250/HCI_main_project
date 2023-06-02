using HCI_main_project.ViewModels;
using System;
using System.Collections.Generic;
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
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _addRestaurantPageViewModel.IsFillAddressButtonClicked = true;
                _addRestaurantPageViewModel.NameAndPhotoFormControl.Visibility = Visibility.Collapsed;
                _addRestaurantPageViewModel.NextButtonText = "Add restaurant";
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }
    }
}
