using HCI_main_project.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCI_main_project.Commands
{
    public class ImageDropCommand : CommandBase
    {

        private NameAndPhotoFormViewModel _nameAndPhotoFormViewModel;
        public ImageDropCommand(NameAndPhotoFormViewModel nameAndPhotoFormViewModel)
        {
            _nameAndPhotoFormViewModel = nameAndPhotoFormViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                if (parameter is DragEventArgs e && e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    foreach (string file in files)
                    {
                        string filename = System.IO.Path.GetFileName(file);
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
