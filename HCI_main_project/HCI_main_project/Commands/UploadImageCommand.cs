using System;
using HCI_main_project.ViewModels;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Reflection;

namespace HCI_main_project.Commands
{
    public class UploadImageCommand : CommandBase
    {
        private NameAndPhotoFormViewModel _nameAndPhotoFormViewModel;
        public UploadImageCommand(NameAndPhotoFormViewModel nameAndPhotoFormViewModel)
        {
            _nameAndPhotoFormViewModel = nameAndPhotoFormViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                bool? response = openFileDialog.ShowDialog();
                if (response == true)
                {
                    string[] files = openFileDialog.FileNames;

                    foreach (string file in files)
                    {
                        string filename = Path.GetFileName(file);
                        FileInfo fileInfo = new FileInfo(filename);
                        _nameAndPhotoFormViewModel.IsUploaded = Visibility.Hidden;
                        ImageBrush imgBrush = new ImageBrush();
                        imgBrush.ImageSource = new BitmapImage(new Uri(file, UriKind.Absolute));
                        _nameAndPhotoFormViewModel.ImageRectangle.Fill = imgBrush;
                        _nameAndPhotoFormViewModel.ButtonText = "Upload other image";
                        _nameAndPhotoFormViewModel.File = file;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }
    }
}
