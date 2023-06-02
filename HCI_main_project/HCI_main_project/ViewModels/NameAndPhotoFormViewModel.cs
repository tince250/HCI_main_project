using HCI_main_project.Commands;
using HCI_main_project.Models;
using HCI_main_project.UserControls;
using HCI_main_project.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCI_main_project.ViewModels
{
    public class NameAndPhotoFormViewModel : ViewModelBase
    {

        private Rectangle _imageRectangle;
        public Rectangle ImageRectangle
        {
            get { return _imageRectangle; }
            set
            {
                _imageRectangle = value;
                OnPropertyChanged(nameof(ImageRectangle));
            }
        }

        private string _file;
        public string File
        {
            get { return _file; }
            set
            {
                _file = value;
                OnPropertyChanged(nameof(File));
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private Visibility isUploaded;
        public Visibility IsUploaded
        {
            get
            {
                return isUploaded;
            }
            set
            {
                isUploaded = value;
                OnPropertyChanged(nameof(IsUploaded));
            }
        }

        public string _buttonText;
        public string ButtonText
        {
            get
            {
                return _buttonText;
            }
            set
            {
                _buttonText = value;
                OnPropertyChanged(nameof(ButtonText));
            }
        }

        public ICommand ImageDropCommand { get; }
        public ICommand UploadImageCommand { get; }

        public NameAndPhotoFormViewModel(Rectangle imageRectangle, Restaurant selectedRestaurant = null)
        {
            IsUploaded = Visibility.Visible;
            _imageRectangle = imageRectangle;
            ButtonText = "Upload image of restaurant";
            ImageDropCommand = new ImageDropCommand(this);
            UploadImageCommand = new UploadImageCommand(this);
            FillFieldsWithPreviousData(selectedRestaurant);
        }

        private void FillFieldsWithPreviousData(Restaurant restaurant)
        {
            if (restaurant == null)
                return;
            Name = restaurant.Name;
        }
    }
   
}
