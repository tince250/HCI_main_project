using HCI_main_project.ViewModel;
using Microsoft.Extensions.DependencyInjection;
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
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private readonly RegisterViewModel viewModel;

        //public RegisterPage()
        //{
        //}
        public RegisterPage()
        {
            InitializeComponent();
            DataContext = App.serviceProvider.GetRequiredService<RegisterViewModel>();
        }

    }
}
