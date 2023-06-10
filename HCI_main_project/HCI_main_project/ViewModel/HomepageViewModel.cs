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

namespace HCI_main_project.ViewModel
{
    public class HomepageViewModel: ViewModelBase
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

        private double minPrice;

        public double MinPrice
        {
            get { return minPrice; }
            set { minPrice = value; }
        }
        
        private double maxPrice;

        public double MaxPrice
        {
            get { return maxPrice; }
            set { maxPrice = value; }
        }

        private DateTime dateFrom;

        public DateTime DateFrom
        {
            get { return dateFrom; }
            set { dateFrom = value; }
        }
        
        private DateTime dateTo;

        public DateTime DateTo
        {
            get { return dateTo; }
            set { dateTo = value; }
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

        private string selectedLocation;

        public string SelectedLocation
        {
            get { return selectedLocation; }
            set { selectedLocation = value; }
        }


        public TripagoContext dbContext;

        public ICommand navItemSelectedCommand { get; }
        public ICommand toggleFilterPaneCommand { get; }
        public ICommand openTourDetailsCommand { get; }
        public ICommand logoutCommand { get; }
        public ICommand applyFiltersCommand { get; }
        public ICommand clearFiltersCommand { get; }

        public HomepageViewModel()
        {
            this.navItemSelectedCommand = new NavItemSelectedCommand(this);
            this.toggleFilterPaneCommand = new ToggleFilterPaneCommand(this);
            this.openTourDetailsCommand = new OpenTourDetailsCommand(this);
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
            this.SortOptions = new ObservableCollection<string>
            {
                "Most popular",
                "Price lowest",
                "Price highest",
                "Most recent"
            };
            this.SelectedOption = this.SortOptions[0];
            this.SelectedType = "tours";
        }

        public void SetAttractions()
        {
            
            this.Objects = new ObservableCollection<object>(dbContext.Attractions.Include(r => r.Address).ToList());
            this.SelectedType = "attractions";
            loadLocations();
        }

        public void SetAccommodation()
        {
           
            this.Objects = new ObservableCollection<object>(dbContext.Accommodations.ToList());
            this.SortOptions = new ObservableCollection<string>
            {
                "All accommodation",
                "Appartments",
                "Hotels"
            };
            this.SelectedType = "accommodation";
            loadLocations();
        }

        public void SetRestaurants()
        {
            
            this.Objects = new ObservableCollection<object>(dbContext.Restaurants.ToList());
            this.SelectedType = "restaurants";
            loadLocations();
        }

        public void Sort(string criteria)
        {
            SortTours(criteria);
        }

        public void SortTours(string criteria)
        {
            if (criteria.Equals("Most popular"))
            {
                this.Objects = new ObservableCollection<object>(dbContext.Tours.OrderByDescending(t => t.TourTravelers.Count));
            }
            else if (criteria.Equals("Price lowest"))
            {
                this.Objects = new ObservableCollection<object>(dbContext.Tours.OrderBy(t => t.Price));

            }
            else if (criteria.Equals("Price highest"))
            {
                this.Objects = new ObservableCollection<object>(dbContext.Tours.OrderByDescending(t => t.Price));
            }
            else if (criteria.Equals("Most recent"))
            {
                this.Objects = new ObservableCollection<object>(dbContext.Tours.OrderBy(t => t.From));
            }
        }
    }
}
