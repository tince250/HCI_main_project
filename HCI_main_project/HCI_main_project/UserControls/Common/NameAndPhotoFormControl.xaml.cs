﻿
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

namespace HCI_main_project.UserControls
{
    /// <summary>
    /// Interaction logic for NameAndPhotoFormControl.xaml
    /// </summary>
    public partial class NameAndPhotoFormControl : UserControl
    {
        public NameAndPhotoFormControl()
        {
            InitializeComponent();
        }

        private void OnKeyDownHandlerImage(object sender, KeyEventArgs e)
        {
            var viewModel = DataContext as NameAndPhotoFormViewModel;
            if (e.Key == Key.Return)
            {
                if (viewModel.UploadImageCommand.CanExecute(null))
                    viewModel.UploadImageCommand.Execute(null);
            }
        }
    }
}
