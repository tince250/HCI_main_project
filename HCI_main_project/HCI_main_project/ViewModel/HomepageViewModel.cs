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


        private TripagoContext dbContext;

        public ICommand navItemSelectedCommand { get; }
        public ICommand toggleFilterPaneCommand { get; }
        public ICommand openTourDetailsCommand { get; }

        public HomepageViewModel()
        {
            this.navItemSelectedCommand = new NavItemSelectedCommand(this);
            this.toggleFilterPaneCommand = new ToggleFilterPaneCommand(this);
            this.openTourDetailsCommand = new OpenTourDetailsCommand(this);
            //var app = (App)Application.Current;
            this.dbContext = App.serviceProvider.GetService<TripagoContext>();
            SetTours();
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
            this.SortOptions = new ObservableCollection<string>
            {
                "All attractions"
            };
            this.SelectedOption = this.SortOptions[0];
            this.SelectedType = "attractions";
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
            this.SelectedOption = this.SortOptions[0];
            this.SelectedType = "accommodation";
        }

        public void SetRestaurants()
        {
            
            this.Objects = new ObservableCollection<object>(dbContext.Restaurants.ToList());
            this.SortOptions = new ObservableCollection<string>
            {
                "All restaurants"
            };
            this.SelectedOption = this.SortOptions[0];
            this.SelectedType = "restaurants";
        }

        public void Sort(string criteria)
        {
            if (Objects.OfType<Tour>().Any())
            {
                SortTours(criteria);
            } 
            else if (Objects.OfType<Attraction>().Any())
            {
                SortAttractions(criteria);
            } 
            else if (Objects.OfType<Accommodation>().Any())
            {
                SortAccommodation(criteria);
            } 
            else if (Objects.OfType<Restaurant>().Any())
            {
                SortRestaurants(criteria);
            }
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
        public void SortAccommodation(string criteria)
        {
            if (criteria.Contains("All"))
            {
                this.Objects = new ObservableCollection<object>(dbContext.Accommodations.ToList());
            }
            else if (criteria.Equals("Most popular"))
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
        }

        public void SortAttractions(string criteria)
        {
            if (criteria.Contains("All"))
            {
                this.Objects = new ObservableCollection<object>(dbContext.Attractions.ToList());
            }
            else if (criteria.Equals("Most popular"))
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
        }
        
        public void SortRestaurants(string criteria)
        {
            if (criteria.Contains("All"))
            {
                this.Objects = new ObservableCollection<object>(dbContext.Restaurants.ToList());
            }
            else if (criteria.Equals("Most popular"))
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
        }
    }
}
