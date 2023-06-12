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

                    if (files.Length != 1)
                    {
                        ImageHelper.SetErrorImage(_nameAndPhotoFormViewModel);
                        ImageHelper.SetMoreThanOneFileError(_nameAndPhotoFormViewModel);
                        return;
                    }

                    string file = files[0];
                    string filename = System.IO.Path.GetFileName(file);

                    if (!_nameAndPhotoFormViewModel.ValidateImage(new FileInfo(file))) 
                    {
                        ImageHelper.SetErrorImage(_nameAndPhotoFormViewModel);
                        return;
                    }

                    ImageHelper.SetSuccessfullyAddedImage(_nameAndPhotoFormViewModel, file);
                }
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }
    }
}
