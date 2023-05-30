using HCI_main_project.ViewModel;
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

namespace HCI_main_project.View
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            var viewModel = new LoginViewModel();
            DataContext = viewModel;
        }

        private void SwitchToRegister(object sender, RoutedEventArgs e)
        {
            RegisterPage page = new RegisterPage();
            NavigationService.GetNavigationService(this).Navigate(page);
        }
    }
}
