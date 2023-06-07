using HCI_main_project.Models;
using HCI_main_project.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace HCI_main_project.User_Controls
{
    public partial class SquareCard : UserControl
    {


        public Tour Tour
        {
            get { return (Tour)GetValue(TourProperty); }
            set { SetValue(TourProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Tour.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TourProperty =
            DependencyProperty.Register("Tour", typeof(Tour), typeof(SquareCard));


        public SquareCard()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationHelper.TourId = this.Tour.Id;
            TripDetailsPage detailsPage = new TripDetailsPage();
            ApplicationHelper.NavigationService.Navigate(detailsPage);
        }
    }
}
