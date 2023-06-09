using HCI_main_project.Commands;
using HCI_main_project.Models;
using HCI_main_project.UserControls;
using HCI_main_project.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        private bool _isImageValid;

        public bool ValidateImage(FileInfo selectedImage)
        {
            if (selectedImage == null || string.IsNullOrEmpty(selectedImage.Name))
            {
                IsImageValid = false;
                ImageValidationError = "Restaurant image is required!";
            }
            else if (!IsImageFile(selectedImage.Name))
            {
                IsImageValid = false;
                ImageValidationError = "File uploaded is not required extension.\nYou can upload .jpg, .jpeg, .png, .bmp!";
            }
            else if (selectedImage.Length > 5 * 1024 * 1024) // 5 MB
            {
                IsImageValid = false;
                ImageValidationError = "Image size is too big.\nYou can upload up to 5MB of size!";
            } else
                IsImageValid = true;
            return IsImageValid;
        }

        private bool IsImageFile(string fileName)
        {
            string[] validExtensions = { ".jpg", ".jpeg", ".png", ".bmp" }; // Add more valid extensions if needed

            string extension = System.IO.Path.GetExtension(fileName);
            return validExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

        public bool IsImageValid
        {
            get { return _isImageValid; }
            set
            {
                _isImageValid = value;
                OnPropertyChanged(nameof(IsImageValid));
            }
        }

        private string _imageValidationError;

        public string ImageValidationError
        {
            get { return _imageValidationError; }
            set 
            { 
                _imageValidationError = value;
                OnPropertyChanged(nameof(ImageValidationError));
            }
        }

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

        private TextBox _nameTextBox;

        public bool IsFormValid()
        {
            return !Validation.GetHasError(_nameTextBox) && Name != "" && Name!=null
                && IsImageValid && File != "" && File != null;
        }

        public NameAndPhotoFormViewModel(Rectangle imageRectangle, TextBox nameTextBox, Restaurant selectedRestaurant = null)
        {
            IsUploaded = Visibility.Visible;
            _imageRectangle = imageRectangle;
            _nameTextBox = nameTextBox;
            ButtonText = "Upload image of restaurant";
            ImageDropCommand = new ImageDropCommand(this);
            UploadImageCommand = new UploadImageCommand(this);
            IsImageValid = true;
            Trace.WriteLine(File);
            FillFieldsWithPreviousData(selectedRestaurant);
        }

        private void FillFieldsWithPreviousData(Restaurant restaurant)
        {
            if (restaurant == null)
                return;
            Name = restaurant.Name;

            string file = System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources\\Restaurants\\"+restaurant.Image);
            IsUploaded = Visibility.Hidden;
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(file, UriKind.Absolute));
            ImageRectangle.Fill = imgBrush;
            ButtonText = "Upload other image";
            File = file;
        }
    }
   
}
