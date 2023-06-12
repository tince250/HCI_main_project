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
using HCI_main_project.Help;
using HCI_main_project.ViewModels;

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

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            var page = Frame.Content as Homepage;
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
            var addEditRestaurantPage = Frame.Content as AddEditRestaurantPage;
            if (addEditRestaurantPage != null)
            {
               if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.U)
                {
                    var vm = addEditRestaurantPage.nameAndPhotoFormControl.DataContext as NameAndPhotoFormViewModel;
                    if (vm.UploadImageCommand.CanExecute(null) && (addEditRestaurantPage.DataContext as AddRestaurantPageViewModel).NameAndPhotoFormControl.Visibility == Visibility.Visible)
                        vm.UploadImageCommand.Execute(null);
                }
                if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D2)
                {
                    var vm = addEditRestaurantPage.DataContext as AddRestaurantPageViewModel;
                    if (vm.FillAddressButtonRestaurantCommand.CanExecute(null))
                        vm.FillAddressButtonRestaurantCommand.Execute(null);
                }
                if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D1)
                {
                    var vm = addEditRestaurantPage.DataContext as AddRestaurantPageViewModel;
                    if (vm.BackButtonRestaurantCommand.CanExecute(null))
                        vm.BackButtonRestaurantCommand.Execute(null);
                }
            }
            var addEditAttractionsPage = Frame.Content as AddEditAttractionPage;
            if (addEditAttractionsPage != null)
            {
                if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.U)
                {
                    var vm = addEditAttractionsPage.nameAndPhotoFormControl.DataContext as NameAndPhotoFormViewModel;
                    if (vm.UploadImageCommand.CanExecute(null) && (addEditAttractionsPage.DataContext as AddAttractionPageViewModel).NameAndPhotoFormControl.Visibility == Visibility.Visible)
                        vm.UploadImageCommand.Execute(null);
                }
                if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D2)
                {
                    var vm = addEditAttractionsPage.DataContext as AddAttractionPageViewModel;
                    if (vm.FillAddressButtonAttractionCommand.CanExecute(null))
                        vm.FillAddressButtonAttractionCommand.Execute(null);
                }
                if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D1)
                {
                    var vm = addEditAttractionsPage.DataContext as AddAttractionPageViewModel;
                    if (vm.BackButtonAttractionCommand.CanExecute(null))
                        vm.BackButtonAttractionCommand.Execute(null);
                }
            }
            var addEditAccommodationPage = Frame.Content as AddEditAccommodationPage;
            if (addEditAccommodationPage != null)
            {
                if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.U)
                {
                    var vm = addEditAccommodationPage.nameAndPhotoFormControl.DataContext as NameAndPhotoFormViewModel;
                    if (vm.UploadImageCommand.CanExecute(null) && (addEditAccommodationPage.DataContext as AddAccommodationPageViewModel).NameAndPhotoFormControl.Visibility == Visibility.Visible)
                        vm.UploadImageCommand.Execute(null);
                }
                if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D3)
                {
                    var vm = addEditAccommodationPage.DataContext as AddAccommodationPageViewModel;
                    if (vm.FillAddressButtonAccommodationCommand.CanExecute(null))
                        vm.FillAddressButtonAccommodationCommand.Execute(null);
                }
                if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D2)
                {
                    var vm = addEditAccommodationPage.DataContext as AddAccommodationPageViewModel;
                    if (vm.FillGeneralInfoButtonAccommodationCommand.CanExecute(null))
                        vm.FillGeneralInfoButtonAccommodationCommand.Execute(null);
                }
                if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D1)
                {
                    var vm = addEditAccommodationPage.DataContext as AddAccommodationPageViewModel;
                    if (vm.BackToAccommodationTypeButtonAccommodationCommand.CanExecute(null))
                        vm.BackToAccommodationTypeButtonAccommodationCommand.Execute(null);
                }
            }
            var addEditTourPage = Frame.Content as AddEditTourPage;
            if (addEditTourPage != null)
            {
                if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.U)
                {
                    var vm = addEditTourPage.nameAndPhotoFormControl.DataContext as NameAndPhotoFormViewModel;
                    if (vm.UploadImageCommand.CanExecute(null))
                        vm.UploadImageCommand.Execute(null);
                }
                if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D5)
                {
                    var vm = addEditTourPage.DataContext as AddTourPageViewModel;
                    if (vm.FillRestaurantsButtonTourCommand.CanExecute(null))
                        vm.FillRestaurantsButtonTourCommand.Execute(null);
                }
                if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D4)
                {
                    var vm = addEditTourPage.DataContext as AddTourPageViewModel;
                    if (vm.FillAccommodationsButtonTourCommand.CanExecute(null))
                        vm.FillAccommodationsButtonTourCommand.Execute(null);
                }
                if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D3)
                {
                    var vm = addEditTourPage.DataContext as AddTourPageViewModel;
                    if (vm.FillAttractionsButtonTourCommand.CanExecute(null))
                        vm.FillAttractionsButtonTourCommand.Execute(null);
                }
                if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D2)
                {
                    var vm = addEditTourPage.DataContext as AddTourPageViewModel;
                    if (vm.FillDetailsButtonTourCommand.CanExecute(null))
                        vm.FillDetailsButtonTourCommand.Execute(null);
                }
                if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D1)
                {
                    var vm = addEditTourPage.DataContext as AddTourPageViewModel;
                    if (vm.BackToGeneralInfoButtonTourCommand.CanExecute(null))
                        vm.BackToGeneralInfoButtonTourCommand.Execute(null);
                }
            }
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
                if (Frame.Content is Homepage home)
                {
                    if (isAgent()) 
                        HelpProvider.SetHelpKey((DependencyObject)focusedControl, "Homepage_Tours_Agent");   
                    else
                        HelpProvider.SetHelpKey((DependencyObject)focusedControl, "Homepage_Tours_Traveler");
                }
                else if (frame.Content is TripDetailsPage detailsT && ApplicationHelper.User.Role == UserRole.TRAVELER)
                {
                    HelpProvider.SetHelpKey((DependencyObject)focusedControl, "DetailsHelpTraveler");
                }
                else if (frame.Content is TripDetailsPage detailsA && ApplicationHelper.User.Role == UserRole.AGENT)
                {
                    HelpProvider.SetHelpKey((DependencyObject)focusedControl, "DetailsHelpAgent");
                }
                else if (frame.Content is LoginPage login)
                {
                    HelpProvider.SetHelpKey((DependencyObject)focusedControl, "LoginHelp");
                }
                else if (frame.Content is RegisterPage register)
                {
                    HelpProvider.SetHelpKey((DependencyObject)focusedControl, "RegisterHelp");
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
