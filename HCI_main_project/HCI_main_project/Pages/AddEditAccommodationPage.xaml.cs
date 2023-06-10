using HCI_main_project.Models;
using HCI_main_project.ViewModels;
using System;
using System.Collections.Generic;
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

namespace HCI_main_project.Pages
{
    /// <summary>
    /// Interaction logic for AddEditAccommodationPage.xaml
    /// </summary>
    public partial class AddEditAccommodationPage : Page
    {
        public AddEditAccommodationPage()
        {
            InitializeComponent();
            DataContext = new AddAccommodationPageViewModel(accommodationTypeControl, nameAndPhotoFormControl, addressFormControl, null);
        }
    }
}
