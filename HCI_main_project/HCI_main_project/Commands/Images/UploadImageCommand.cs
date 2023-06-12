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
