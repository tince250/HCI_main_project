using HCI_main_project.Models;
using HCI_main_project.UserControls;
using HCI_main_project.ViewModels;
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
        public AddEditRestaurantPage(Restaurant restaurant = null)
        {
            InitializeComponent();
            DataContext = new AddRestaurantPageViewModel(nameAndPhotoFormControl, addressFormControl, snackBarPositive, snackBarNegative, restaurant);
        }
    }
}
