using HCI_main_project.Model.DTOs;
using HCI_main_project.Model.Services;
using HCI_main_project.Models;
using HCI_main_project.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCI_main_project.Commands
{
    public class AddRestaurantCommand : CommandBase
    {
        private AddRestaurantPageViewModel _addRestaurantPageViewModel;
        private IRestaurantService _restaurantService;
        public AddRestaurantCommand(AddRestaurantPageViewModel addRestaurantPageViewModel)
        {
            _addRestaurantPageViewModel = addRestaurantPageViewModel;
            _restaurantService = App.serviceProvider.GetService<IRestaurantService>();
        }

        /*private RestaurantDTO CollectData()
        {
            return new RestaurantDTO(_addRestaurantPageViewModel.NameAndPhotoFormControl.vM.Name,
                null,
                null);
        }*/

        public override void Execute(object? parameter)
        {
            try
            {
                //Trace.WriteLine(_addRestaurantPageViewModel.NameAndPhotoFormControl.vM);
                Address address = new Address(_addRestaurantPageViewModel.AddressFormViewModel.City,
                    20000,
                    _addRestaurantPageViewModel.AddressFormViewModel.Street,
                    int.Parse(_addRestaurantPageViewModel.AddressFormViewModel.StreetNo)
                    );

                ImageBrush imgBrush = _addRestaurantPageViewModel.NameAndPhotoFormViewModel.ImageRectangle.Fill as ImageBrush;
                string filename = "";
                if (imgBrush != null)
                {
                    ImageSource imageSource = imgBrush.ImageSource;
                    if (imageSource is BitmapImage bitmapImage)
                    {
                        filename = System.IO.Path.GetFileName(bitmapImage.UriSource.LocalPath);
                    }
                }

                string baseDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string destinationFolder = Path.Combine(baseDirectory, "Resources\\Restaurants");
                string destinationPath = Path.Combine(destinationFolder, filename);
                File.Copy(_addRestaurantPageViewModel.NameAndPhotoFormViewModel.File, destinationPath, overwrite: true);


                Restaurant restaurant = new Restaurant(_addRestaurantPageViewModel.NameAndPhotoFormViewModel.Name,
                    filename, address);
                _restaurantService.Add(restaurant);
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }
    }
}
