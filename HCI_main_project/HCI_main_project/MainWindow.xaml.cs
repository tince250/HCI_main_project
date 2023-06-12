using HCI_main_project.Models;
using HCI_main_project.View;
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
using HCI_main_project.Help;

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
            //this.dbContext = tripagoContext;
            //this.dbContext.Database.EnsureCreated();

            InitializeComponent();
           

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

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            //if (focusedControl is DependencyObject)
            //{
            //    string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
            //    HelpProvider.ShowHelp(str, this);
            //}

            if (focusedControl != null)
            {
                if (frame.Content is Homepage home)
                {
                    if (isAgent()) 
                        HelpProvider.SetHelpKey((DependencyObject)focusedControl, "Homepage_Tours_Agent");   
                    else
                        HelpProvider.SetHelpKey((DependencyObject)focusedControl, "Homepage_Tours_Traveler");
                }

                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }

            
        }

        private bool isAgent()
        {
            return ApplicationHelper.User.Role == UserRole.AGENT;
        }
    }
}
