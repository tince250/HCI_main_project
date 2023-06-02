using HCI_main_project.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCI_main_project.Commands
{
    public class BackButtonRestaurantCommand : CommandBase
    {
        private AddRestaurantPageViewModel _addRestaurantPageViewModel;
        public BackButtonRestaurantCommand(AddRestaurantPageViewModel addRestaurantPageViewModel)
        {
            _addRestaurantPageViewModel = addRestaurantPageViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _addRestaurantPageViewModel.IsFillAddressButtonClicked = false;
                _addRestaurantPageViewModel.NameAndPhotoFormControl.Visibility = Visibility.Visible;
                _addRestaurantPageViewModel.NextButtonText = "Fill address";
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }
    }
}

