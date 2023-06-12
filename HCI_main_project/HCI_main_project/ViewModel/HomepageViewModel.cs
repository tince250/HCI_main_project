using HCI_main_project.Commands;
using HCI_main_project.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Collections;
using System.Windows.Data;
using System.Windows.Controls;
using HCI_main_project.Commands.Homepages;
using MaterialDesignThemes.Wpf;

namespace HCI_main_project.ViewModel
{
    public class HomepageViewModel: ViewModelBase, INotifyDataErrorInfo
    {
        private ObservableCollection<object> objects;
        public ObservableCollection<object> Objects
        {
            get { return objects; }
            set
            {
                objects = value;
                OnPropertyChanged(nameof(Objects));
            }
        }

        private bool _isSearchInFocus = false;
        public bool IsSearchInFocus
        {
            get
            {
                return _isSearchInFocus;
            }
            set
            {
                _isSearchInFocus = value;
                OnPropertyChanged(nameof(_isSearchInFocus));
            }
        }

        private string selectedType;
        public string SelectedType
        {
            get { return selectedType; }
            set
            {
                if (selectedType != value)
                {
                    this.SearchText = "";
                }
                selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }

        private ObservableCollection<String> sortOptions;

        public ObservableCollection<String> SortOptions
        {
            get { return sortOptions; }
            set { 
                sortOptions = value;
                OnPropertyChanged(nameof(SortOptions));
            }
        }

        private bool expandFilters;

        public bool ExpandFilters
        {
            get { return expandFilters; }
            set { 
                expandFilters = value;
                OnPropertyChanged(nameof(ExpandFilters));
            }
        }


        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set { searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }


        private string selectedOption;
        public string SelectedOption
        {
            get { return selectedOption; }
            set
            {
                selectedOption = value;
                OnPropertyChanged(nameof(SelectedOption));
                if (value != null)
                    this.Sort(value);
            }
        }

        private double? minPrice;

        public double? MinPrice
        {
            get { return minPrice; }
            set {
                minPrice = value;
                ValidatePriceRange();
                OnPropertyChanged(nameof(MinPrice));
            }
        }
        
        private double? maxPrice;

        public double? MaxPrice
        {
            get { return maxPrice; }
            set { 
                maxPrice = value;
                ValidatePriceRange();
                OnPropertyChanged(nameof(MaxPrice));
            }
        }

        private DateTime? dateFrom;

        public DateTime? DateFrom
        {
            get { return dateFrom; }
            set { 
                dateFrom = value;
                ValidateDateRange();
                OnPropertyChanged(nameof(DateFrom));
            }
        }
        
        private DateTime? dateTo;

        public DateTime? DateTo
        {
            get { return dateTo; }
            set { 
                dateTo = value;
                ValidateDateRange();
                OnPropertyChanged(nameof(DateTo));
            }
        }

        private ObservableCollection<String> locations;

        public ObservableCollection<String> Locations
        {
            get { return locations; }
            set { 
                locations = value;
                OnPropertyChanged(nameof(Locations));
            }
        }

        private string? selectedLocation;

        public string? SelectedLocation
        {
            get { return selectedLocation; }
            set { 
                selectedLocation = value;
                OnPropertyChanged(nameof(SelectedLocation));
            }
        }

        private string userRole;

        public string LoggedUserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }

        private string entityType;

        public string EntityType
        {
            get { return entityType; }
            set { 
                entityType = value;
                OnPropertyChanged(nameof(EntityType));
            }
        }


        public TripagoContext dbContext;

        public ICommand navItemSelectedCommand { get; }
        public ICommand toggleFilterPaneCommand { get; }
        public ICommand logoutCommand { get; }
        public ICommand applyFiltersCommand { get; }

        public ICommand AddRestaurantButtonCommand { get; }
        public ICommand AddAttractionsButtonCommand { get; }
        public ICommand AddAccommodationButtonCommand { get; }
        public ICommand AddTourButtonCommand { get; }

        public ICommand setSearchToFocus { get; }

        private TextBox minPriceTextBox;
        private TextBox maxPriceTextBox;
        private DatePicker dateFromPicker;
        private DatePicker dateToPicker;

        public Grid mainGrid { get; }
        public TourCardViewModel TourCardViewModel { get; }

        public bool AreFiltersValid()
        {
            if (AreFiltersEmptyForReal())
                return false;

            return !Validation.GetHasError(minPriceTextBox) && !Validation.GetHasError(maxPriceTextBox) && !Validation.GetHasError(dateFromPicker) && !Validation.GetHasError(dateToPicker);
        }
        public bool AreFiltersEmptyForReal()
        {
            return minPriceTextBox.Text == "" && maxPriceTextBox.Text == "" && !dateFrom.HasValue  && !dateTo.HasValue;        }

        public ICommand clearFiltersCommand { get; }

        private Snackbar snackBar;
        public void ShowSnackBar(string message)
        {
            snackBar.FontSize = 24;
            snackBar.MessageQueue.Enqueue(message);
        }

        public HomepageViewModel(Grid mainGrid, TextBox minPriceTextBox, TextBox maxPriceTextBox, DatePicker dateFromPicker, DatePicker dateToPicker, Snackbar snackBar)
        {
            ApplicationHelper.User = new User();
            ApplicationHelper.User.Id = 211;
            ApplicationHelper.User.Role = UserRole.AGENT;

            this.snackBar = snackBar;

            this.LoggedUserRole = ApplicationHelper.User.Role == UserRole.AGENT ? "agent" : "traveler";

            this.minPriceTextBox = minPriceTextBox;
            this.maxPriceTextBox = maxPriceTextBox;
            this.dateFromPicker = dateFromPicker;
            this.dateToPicker = dateToPicker;

            AddRestaurantButtonCommand = new AddRestaurantButtonCommand();
            AddAttractionsButtonCommand = new AddAttractionsButtonCommand();
            AddAccommodationButtonCommand = new AddAccommodationButtonCommand();
            AddTourButtonCommand = new AddTourButtonCommand();

            this.mainGrid = mainGrid;

            ApplicationHelper.HomePageVm = this;

            this.navItemSelectedCommand = new NavItemSelectedCommand(this);
            this.toggleFilterPaneCommand = new ToggleFilterPaneCommand(this);
            this.logoutCommand = new LogoutCommand(this);
            this.applyFiltersCommand = new ApplyFiltersCommand(this);
            this.clearFiltersCommand = new ClearFiltersCommand(this);
            this.setSearchToFocus = new FocusSearchCommand(this);
            //var app = (App)Application.Current;
            this.dbContext = App.serviceProvider.GetService<TripagoContext>();
            SetTours();

            
        }



        private void loadLocations()
        {
            var cities = new ObservableCollection<string>(this.dbContext.Addresses.Select(a => a.City).Distinct().ToList());
            cities.Insert(0, "All locations");
            this.Locations = cities;
        }

        public void SetTours()
        {
            this.Objects = new ObservableCollection<object>(dbContext.Tours.ToList());
            if (this.SelectedType != "tours")
            {
                this.SortOptions = new ObservableCollection<string>
                {
                    "Most popular",
                    "Price lowest",
                    "Price highest",
                    "Date desc",
                    "Date asc"
                };
                this.SelectedOption = this.SortOptions[0];
                this.EntityType = "tour";
                this.SelectedType = "tours";
                this.ExpandFilters = false;
            }
            
        }

        public void SetAttractions()
        {
            
            this.Objects = new ObservableCollection<object>(dbContext.Attractions.Include(r => r.Address).ToList());
            if (this.SelectedType != "attractions")
            {
                this.SelectedType = "attractions";
                this.EntityType = "attraction";
                this.ExpandFilters = false;
                loadLocations();
            }
            
        }

        public void SetAccommodation()
        {
           
            this.Objects = new ObservableCollection<object>(dbContext.Accommodations.ToList());
            if (this.SelectedType != "accommodation")
            {
                this.SortOptions = new ObservableCollection<string>
                {
                    "All accommodation",
                    "Appartments",
                    "Hotels"
                };
                this.EntityType = "accommodation";
                this.SelectedType = "accommodation";
                this.ExpandFilters = false;
                loadLocations();
            }
        }

        public void SetRestaurants()
        {
            
            this.Objects = new ObservableCollection<object>(dbContext.Restaurants.ToList());
            if (this.SelectedType != "restaurants")
            {
                this.EntityType = "restaurant";
                this.SelectedType = "restaurants";
                this.ExpandFilters = false;
                loadLocations();
            }
        }

        public void SetHistory()
        {
            if (this.LoggedUserRole == "agent")
                this.Objects = new ObservableCollection<object>(dbContext.Tours.OrderByDescending(t => t.From).ToList());
            else
                this.Objects = new ObservableCollection<object>(dbContext.Tours.Where(t => t.TourTravelers.Where(tt => tt.TravelerId == ApplicationHelper.User.Id).ToList().Count > 0).OrderByDescending(t => t.From).ToList());
            
            if (this.SelectedType != "history")
            {
                this.SelectedType = "history";
                this.ExpandFilters = false;
                this.SortOptions = new ObservableCollection<string>
                {
                    "Most popular",
                    "Price lowest",
                    "Price highest",
                    "Date desc",
                    "Date asc"
                };
                this.SelectedOption = this.SortOptions[0];
                this.setStatistics();
            }
        }

        private string totalIncome;

        public string TotalIncome
        {
            get { return totalIncome; }
            set { 
                totalIncome = value;
                OnPropertyChanged(nameof(TotalIncome));
            }
        }

        private int totalReservations;

        public int TotalReservations
        {
            get { return totalReservations; }
            set { 
                totalReservations = value;
                OnPropertyChanged(nameof(TotalReservations));
            }
        }

        private int totalBookings;

        public int TotalBookings
        {
            get { return totalBookings; }
            set { 
                totalBookings = value;
                OnPropertyChanged(nameof(TotalBookings));

            }
        }


        private void setStatistics()
        {
            var totalInc = 0.0;
            var totalBook = 0;
            var totalRes = 0;

            foreach (var tour in this.dbContext.Tours)
            {
                //if (tour.From < DateTime.Now)
                //    totalInc += tour.Price * tour.TourTravelers.Count;
                //else
                //    totalInc += tour.Price * tour.TourTravelers.Where(tt => tt.BookingStatus == BookingStatus.BOOKING).ToList().Count;

                totalInc += tour.Price * tour.TourTravelers.Count;

                totalBook += tour.TourTravelers.Where(tt => tt.BookingStatus == BookingStatus.BOOKING).ToList().Count;
                totalRes += tour.TourTravelers.Where(tt => tt.BookingStatus == BookingStatus.RESERVATION).ToList().Count;

            }

            this.TotalIncome = totalInc + "e";
            this.TotalBookings = totalBook;
            this.TotalReservations = totalRes;
        }

        public void Sort(string criteria)
        {
            this.Objects = SortTours(criteria, this.Objects);
        }

        public ObservableCollection<object> SortTours(string criteria, ObservableCollection<object> objects)
        {

            if (criteria.Equals("Most popular"))
            {
                return new ObservableCollection<object>(objects.OfType<Tour>().OrderByDescending(t => t.TourTravelers.Count));
            }
            else if (criteria.Equals("Price lowest"))
            {
                return  new ObservableCollection<object>(objects.OfType<Tour>().OrderBy(t => t.Price));

            }
            else if (criteria.Equals("Price highest"))
            {
                return new ObservableCollection<object>(objects.OfType<Tour>().OrderByDescending(t => t.Price));
            }
            else if (criteria.Equals("Most recent"))
            {
                return new ObservableCollection<object>(objects.OfType<Tour>().OrderByDescending(t => t.From));
            }
            else if (criteria.Equals("Date desc"))
            {
                return new ObservableCollection<object>(objects.OfType<Tour>().OrderByDescending(t => t.From));
            }
            else if (criteria.Equals("Date asc"))
            {
                return new ObservableCollection<object>(objects.OfType<Tour>().OrderBy(t => t.From));
            }

            return null;
        }

        private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        public bool HasErrors => errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public IEnumerable GetErrors(string? propertyName)
        {
            if (errors.ContainsKey(propertyName))
            {
                return errors[propertyName];
            }

            return null;
        }

        private void ValidateDateRange()
        {
            if (DateFrom > DateTo)
            {
                AddValidationError(nameof(MinPrice), "'Date from' cannot be greater than the 'Date to' field.");
            }
            else
            {
                RemoveValidationError(nameof(MinPrice));
            }
        }

        public bool PriceHasCustomErrors { get; set; }

        private void ValidatePriceRange()
        {
            if (MinPrice > MaxPrice)
            {
                AddValidationError(nameof(MinPrice), "Minimum price cannot be greater than the maximum price.");
            }
            else
            {
                RemoveValidationError(nameof(MinPrice));
            }
        }

        private void AddValidationError(string propertyName, string errorMessage)
        {
            if (!errors.ContainsKey(propertyName))
            {
                errors[propertyName] = new List<string>();
            }

            if (!errors[propertyName].Contains(errorMessage))
            {
                errors[propertyName].Add(errorMessage);
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        private void RemoveValidationError(string propertyName)
        {
            if (errors.ContainsKey(propertyName))
            {
                errors.Remove(propertyName);
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }
    }
}
