using HCI_main_project.Models;
using HCI_main_project.View;
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
using System.Windows.Navigation;
using HCI_main_project.Pages;
using HCI_main_project.ViewModel;

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
            /*this.dbContext = tripagoContext;
            this.dbContext.Database.EnsureCreated();*/

            InitializeComponent();

            // Set the DataContext of the AddRestaurantPage to the restaurant object tripagoContext.Restaurants.Include(r => r.Address).FirstOrDefault(r => r.Id == 8)
            //AddEditRestaurantPage addEditRestaurantPage = new AddEditRestaurantPage(tripagoContext.Restaurants.Include(r => r.Address).FirstOrDefault(r => r.Id == 11));
            //AddEditRestaurantPage addEditRestaurantPage = new AddEditRestaurantPage();
            //AddEditAttractionPage addEditAttractionPage = new AddEditAttractionPage(tripagoContext.Attractions.Include(r => r.Address).FirstOrDefault(r => r.Id == 1));
            //AddEditAccommodationPage addEditAttractionPage = new AddEditAccommodationPage();
            // Set the content of the Frame to the AddRestaurantPage
            //Frame.Content = addEditAttractionPage;
        }

            // Console.WriteLine("Adding some authors into database...");
            //Console.WriteLine("Adding some authors into database...");
            //User user = new User
            //{
            //    Email = "user@gmail.com",
            //    FirstName = "tina",
            //    LastName = "miha",
            //    Password = "123",
            //    Role = UserRole.AGENT
            //};
            //this.dbContext.Users.Add(user);
            //this.dbContext.SaveChanges();

            //this.dbContext.Tours.Add(new Tour
            //{
            //    Name = "Krstarenje Dunavom sa posetom Petrovaradinu",
            //    Description = "",
            //    From = new DateTime(2023, 6, 1),
            //    To = new DateTime(2023, 6, 5),
            //    Image = "petrovaradin.jpg",
            //    Price = 20,
            //    TravelAgentId = 1
            //});

            //this.dbContext.Tours.Add(new Tour
            //{
            //    Name = "Obilazak Hrama Svetog Save",
            //    Description = "",
            //    From = new DateTime(2023, 7, 1),
            //    To = new DateTime(2023, 7, 5),
            //    Image = "hram.jpg",
            //    Price = 25,
            //    TravelAgentId = 1
            //});

            //this.dbContext.Attractions.Add(new Attraction
            //{
            //    Name = "Cele Kula, Muzej Nis",
            //    Image = new byte[0],
            //    Address = new Address
            //    {
            //        Street = "Bozidarska",
            //        StreetNumber = 4,
            //        City = "Nis",
            //        PostalCode = 18000
            //    }
            //});
            //this.dbContext.SaveChanges();
            //    Role = UserRole.TRAVELER
            //};
            //this.dbContext.Users.Add(user);
            //this.dbContext.SaveChanges();

            //foreach (User user1 in this.dbContext.Users)
            //{
            //    Trace.WriteLine(user1.FirstName);
            //}
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            var page = frame.Content as Homepage;
            if (page != null)
            {
                if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.S)
                {
                    page.searchBox.Focus();
                }
                else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.F)
                {
                    if (page.DataContext is HomepageViewModel vm)
                    {
                        vm.ExpandFilters = !vm.ExpandFilters;
                    }
                }
            }  
        }
    }
}
