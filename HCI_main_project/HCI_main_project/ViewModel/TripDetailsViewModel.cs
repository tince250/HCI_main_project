using HCI_main_project.Models;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.ViewModel
{
    class TripDetailsViewModel : ViewModelBaseS
    {
        private Location _location;
        public Location Location
        {
            get { return _location; }
            set
            {
                SetProperty(ref _location, value);
            }
        }

        private ObservableCollection<object> _attractions;
        public ObservableCollection<object> Attractions
        {
            get { return _attractions; }
            set
            {
                SetProperty(ref _attractions, value);
            }
        }

        private ObservableCollection<object> _accommodations;
        public ObservableCollection<object> Accommodations
        {
            get { return _accommodations; }
            set
            {
                SetProperty(ref _accommodations, value);
            }
        }

        private ObservableCollection<object> _restaurants;
        public ObservableCollection<object> Restaurants
        {
            get { return _restaurants; }
            set
            {
                SetProperty(ref _restaurants, value);
            }
        }

        private Tour _tour;
        public Tour Tour
        {
            get { return _tour; }
            set
            {
                SetProperty(ref _tour, value);
            }
        }

        private TripagoContext _dbContext;

        public TripDetailsViewModel(TripagoContext dbContext)
        {
            _dbContext = dbContext;
            SetTour(1);
            SetAttractions();
            SetAccommodations();
            SetRestaurants();
        }

        private void SetTour(int tourId)
        {
            this.Tour = _dbContext.Tours.First(c => c.Id == tourId);
            this.Location = new Location(this.Tour.Latitude, this.Tour.Longitude);
        }

        private void SetAttractions()
        {
            this.Attractions = new ObservableCollection<object>(this.Tour.TourAttractions.Select(tourAttraction => tourAttraction.Attraction).ToList());
        }

        private void SetAccommodations()
        {
            this.Accommodations = new ObservableCollection<object>(this.Tour.TourAccommodations.Select(tourAccommodation=> tourAccommodation.Accommodation).ToList());
        }

        private void SetRestaurants()
        {
            this.Restaurants = new ObservableCollection<object>(this.Tour.TourRestaurants.Select(tourRestaurants=> tourRestaurants.Restaurant).ToList());
        }

        private void setMockUp()
        {
            ObservableCollection<object> o = new ObservableCollection<object>();
            o.Add(new Attraction { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Sava's Monestry" });
            o.Add(new Attraction { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Kalemegdan" });
            o.Add(new Attraction { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Marakana" });

            Attractions = o;

            ObservableCollection<object> o2 = new ObservableCollection<object>();
            o2.Add(new Accommodation { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Hotel Moscow" });
            Accommodations = o2;

            ObservableCollection<object> o3 = new ObservableCollection<object>();
            o3.Add(new Restaurant { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Banjalucki cevapi" });
            o3.Add(new Restaurant { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Sushi bar" });

            Restaurants = o3;
        }

    }
}
