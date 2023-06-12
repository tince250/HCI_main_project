﻿using HCI_main_project.UserControls;
using HCI_main_project.ViewModels;
using HCI_main_project.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using HCI_main_project.Models;
using HCI_main_project.Components;

namespace HCI_main_project.Pages
{
    /// <summary>
    /// Interaction logic for AddEditTourPage.xaml
    /// </summary>
    public partial class AddEditTourPage : Page
    {
        public AddEditTourPage()
        {
            InitializeComponent();
            Tour tour = App.serviceProvider.GetService<TripagoContext>().Tours.FirstOrDefault(t => t.Id==2);
            DataContext = new AddTourPageViewModel(nameAndPhotoFormControl, tripDetailsControl, 
                attractionsDragAndDropControl, accommodationsDragAndDropControl, restaurantsDragAndDropControl, tour);
        }

        private void openGoBackDialog(object sender, RoutedEventArgs e)
        {
            this.mainGrid.Children.Add(new ConfirmDialog(DialogType.GO_BACK_CRUD));
        }
    }
}
