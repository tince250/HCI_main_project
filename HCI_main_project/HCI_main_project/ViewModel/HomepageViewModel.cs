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

        public TripagoContext dbContext;

        public ICommand navItemSelectedCommand { get; }
        public ICommand toggleFilterPaneCommand { get; }
        public ICommand logoutCommand { get; }
        public ICommand applyFiltersCommand { get; }

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

        public HomepageViewModel(Grid mainGrid, TextBox minPriceTextBox, TextBox maxPriceTextBox, DatePicker dateFromPicker, DatePicker dateToPicker)
        {
            this.minPriceTextBox = minPriceTextBox;
            this.maxPriceTextBox = maxPriceTextBox;
            this.dateFromPicker = dateFromPicker;
            this.dateToPicker = dateToPicker;

            this.mainGrid = mainGrid;

            ApplicationHelper.HomePageVm = this;

            this.navItemSelectedCommand = new NavItemSelectedCommand(this);
            this.toggleFilterPaneCommand = new ToggleFilterPaneCommand(this);
            this.logoutCommand = new LogoutCommand(this);
            this.applyFiltersCommand = new ApplyFiltersCommand(this);
            this.clearFiltersCommand = new ClearFiltersCommand(this);
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
                    "Most recent"
                };
                this.SelectedOption = this.SortOptions[0];
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
                this.SelectedType = "restaurants";
                this.ExpandFilters = false;
                loadLocations();
            }
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
