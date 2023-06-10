﻿using HCI_main_project.Model.DTOs;
using HCI_main_project.Model.Services;
using HCI_main_project.Models;
using HCI_main_project.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace HCI_main_project.Commands.Attractions
{
    public class AddAttractionCommand : CommandBase
    {
        private AddAttractionPageViewModel _addAttractionPageViewModel;
        private IAttractionService _attractionService;
        public AddAttractionCommand(AddAttractionPageViewModel addAttractionPageViewModel)
        {
            _addAttractionPageViewModel = addAttractionPageViewModel;
            _addAttractionPageViewModel.AddressFormViewModel.PropertyChanged += ViewModel_PropertyChanged;
            _attractionService = App.serviceProvider.GetService<IAttractionService>();
        }

        public override void Execute(object? parameter)
        {
            try
            {
                AddressDTO address = new AddressDTO(_addAttractionPageViewModel.AddressFormViewModel.City, 20000,
                    _addAttractionPageViewModel.AddressFormViewModel.Street,
                    int.Parse(_addAttractionPageViewModel.AddressFormViewModel.StreetNo)
                    );

                string filename = ImageHelper.Save(_addAttractionPageViewModel.NameAndPhotoFormViewModel.ImageRectangle.Fill as ImageBrush,
                    "Attractions", _addAttractionPageViewModel.NameAndPhotoFormViewModel.File);


                AttractionDTO attraction = new AttractionDTO(_addAttractionPageViewModel.NameAndPhotoFormViewModel.Name,
                    filename, address);
                _attractionService.Add(attraction);
            }
            catch (Exception ex)
            {
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addAttractionPageViewModel.AddressFormViewModel.Street)
                || e.PropertyName == nameof(_addAttractionPageViewModel.AddressFormViewModel.StreetNo)
                || e.PropertyName == nameof(_addAttractionPageViewModel.AddressFormViewModel.City))
            {
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _addAttractionPageViewModel.AddressFormViewModel.IsFormValid();
        }
    }
}
