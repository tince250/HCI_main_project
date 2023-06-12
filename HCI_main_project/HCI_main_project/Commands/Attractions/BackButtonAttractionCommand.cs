using HCI_main_project.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCI_main_project.Commands.Attractions
{
    public class BackButtonAttractionCommand : CommandBase
    {
        private AddAttractionPageViewModel _addAttractionPageViewModel;
        public BackButtonAttractionCommand(AddAttractionPageViewModel addAttractionPageViewModel)
        {
            _addAttractionPageViewModel = addAttractionPageViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _addAttractionPageViewModel.IsFillAddressButtonClicked = false;
                _addAttractionPageViewModel.NameAndPhotoFormControl.Visibility = Visibility.Visible;
                _addAttractionPageViewModel.NextButtonText = "Fill address info";
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }
    }
}
