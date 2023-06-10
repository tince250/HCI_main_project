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

namespace HCI_main_project.Components
{
    /// <summary>
    /// Interaction logic for ReserveDialog.xaml
    /// </summary>
    public partial class ReserveDialog : UserControl
    {
        public ReserveDialog(bool isReservation)
        {
            InitializeComponent();
            DataContext = new ReserveDialogViewModel(isReservation);
        }

        private void closeDialog(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
