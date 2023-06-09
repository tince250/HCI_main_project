using HCI_main_project.ViewModels;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCI_main_project.Commands
{
    public class ImageHelper
    {
       public static string save(ImageBrush imgBrush, string type, string file, bool edit = false)
        {
            string filename = "";
            if (imgBrush != null)
            {
                ImageSource imageSource = imgBrush.ImageSource;
                if (imageSource is BitmapImage bitmapImage)
                {
                    filename = Path.GetFileName(bitmapImage.UriSource.LocalPath);
                }
            }

            string baseDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string destinationFolder = Path.Combine(baseDirectory, "Resources\\"+type);
                filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + filename;
            string destinationPath = Path.Combine(destinationFolder, filename);
            File.Copy(file, destinationPath, overwrite: true);
            return filename;
        }

        public static void SetSuccessfullyAddedImage(NameAndPhotoFormViewModel nameAndPhotoFormViewModel, string file)
        {
            nameAndPhotoFormViewModel.IsUploaded = Visibility.Hidden;
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(file, UriKind.Absolute));
            nameAndPhotoFormViewModel.ImageRectangle.Fill = imgBrush;
            nameAndPhotoFormViewModel.ButtonText = "Upload other image";
            nameAndPhotoFormViewModel.File = file;
        }

        public static void SetErrorImage(NameAndPhotoFormViewModel nameAndPhotoFormViewModel)
        {
            nameAndPhotoFormViewModel.ImageRectangle.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xEE, 0xEE));
            nameAndPhotoFormViewModel.ButtonText = "Upload image of restaurant";
            nameAndPhotoFormViewModel.File = "";
        }

        public static void SetMoreThanOneFileError(NameAndPhotoFormViewModel nameAndPhotoFormViewModel)
        {
            nameAndPhotoFormViewModel.IsImageValid = false;
            nameAndPhotoFormViewModel.ImageValidationError = "You can only upload one image!";
        }
    }
}
