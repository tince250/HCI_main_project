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
    /// Interaction logic for TripDetails.xaml
    /// </summary>
    public partial class TripDetails : Page
    {
        public TripDetails()
        {
            InitializeComponent();
            DataContext = App.serviceProvider.GetRequiredService<TripDetailsViewModel>();

        }
    }
}
