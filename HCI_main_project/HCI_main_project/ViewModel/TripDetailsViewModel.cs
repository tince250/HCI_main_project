using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.ViewModel
{
    class TripDetailsViewModel : ViewModelBase
    {
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

        public TripDetailsViewModel()
        {
            ObservableCollection < object > o = new ObservableCollection<object>();
            o.Add(new Attraction { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24}, Name = "Sava's Monestry" });
            o.Add(new Attraction { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Kalemegdan" });
            o.Add(new Attraction { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Marakana" });

            Attractions = o;

            ObservableCollection<object> o2 = new ObservableCollection<object>();
            o2.Add(new Accommodation { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Hotel Moscow" });
            Accommodations = o2;

            ObservableCollection<object> o3 = new ObservableCollection<object>();
            o3.Add(new Accommodation { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Banjalucki cevapi" });
            o3.Add(new Accommodation { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Sushi bar" });

            Restaurants = o3;
        }

    }
}
