using HCI_main_project.Models;
using HCI_main_project.Pages;
using MaterialDesignExtensions.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TripagoContext dbContext;
        public MainWindow(TripagoContext tripagoContext)
        {
            InitializeComponent();

            // Set the DataContext of the AddRestaurantPage to the restaurant object tripagoContext.Restaurants.Include(r => r.Address).FirstOrDefault(r => r.Id == 8)
            //AddEditRestaurantPage addEditRestaurantPage = new AddEditRestaurantPage(tripagoContext.Restaurants.Include(r => r.Address).FirstOrDefault(r => r.Id == 11));
            //AddEditRestaurantPage addEditRestaurantPage = new AddEditRestaurantPage();
            AddEditAttractionPage addEditAttractionPage = new AddEditAttractionPage(tripagoContext.Attractions.Include(r => r.Address).FirstOrDefault(r => r.Id == 1));
            // Set the content of the Frame to the AddRestaurantPage
            Frame.Content = addEditAttractionPage;
        }


    }
}
