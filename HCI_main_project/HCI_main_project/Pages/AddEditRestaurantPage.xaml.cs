using HCI_main_project.Components;
using HCI_main_project.Models;
using HCI_main_project.UserControls;
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

namespace HCI_main_project
{
    /// <summary>
    /// Interaction logic for AddRestaurantPage.xaml
    /// </summary>
    public partial class AddEditRestaurantPage : Page
    {
        public AddEditRestaurantPage()
        {
            
            InitializeComponent();
            Restaurant tour = App.serviceProvider.GetService<TripagoContext>().Restaurants.FirstOrDefault(t => t.Id == 13);
            DataContext = new AddRestaurantPageViewModel(nameAndPhotoFormControl, addressFormControl, snackBarPositive, snackBarNegative, tour);
        }

        private void openGoBackDialog(object sender, RoutedEventArgs e)
        {
            this.mainGrid.Children.Add(new ConfirmDialog(DialogType.GO_BACK_CRUD));
        }
    }
}
