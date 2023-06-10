using HCI_main_project.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCI_main_project.Commands.Attractions
{
    public class FillAddressButtonAttractionCommand : CommandBase
    {
        private AddAttractionPageViewModel _addAttractionPageViewModel;
        public FillAddressButtonAttractionCommand(AddAttractionPageViewModel addAttractionPageViewModel)
        {
            _addAttractionPageViewModel = addAttractionPageViewModel;
            _addAttractionPageViewModel.NameAndPhotoFormViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _addAttractionPageViewModel.IsFillAddressButtonClicked = true;
                _addAttractionPageViewModel.NameAndPhotoFormControl.Visibility = Visibility.Collapsed;
                if (_addAttractionPageViewModel.SelectedAttraction == null)
                    _addAttractionPageViewModel.NextButtonText = "Create attraction";
                else
                    _addAttractionPageViewModel.NextButtonText = "Update attraction";
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }
        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addAttractionPageViewModel.NameAndPhotoFormViewModel.Name)
                || e.PropertyName == nameof(_addAttractionPageViewModel.NameAndPhotoFormViewModel.IsImageValid)
                || e.PropertyName == nameof(_addAttractionPageViewModel.NameAndPhotoFormViewModel.File))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _addAttractionPageViewModel.NameAndPhotoFormViewModel.IsFormValid();
        }
    }
}