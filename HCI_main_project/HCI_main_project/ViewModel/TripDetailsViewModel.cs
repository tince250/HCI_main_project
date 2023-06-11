using HCI_main_project.Commands;
using HCI_main_project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HCI_main_project.ViewModel
{
    public class TripDetailsViewModel : ViewModelBaseS
    {
        private Visibility _cancelBtnVisbility;
        public Visibility CancelBtnVisibility
        {
            get { return _cancelBtnVisbility; }
            set
            {
                SetProperty(ref _cancelBtnVisbility, value);
            }
        }

        private Visibility _reserveBtnVisbility;
        public Visibility ReserveBtnVisibility
        {
            get { return _reserveBtnVisbility; }
            set
            {
                SetProperty(ref _reserveBtnVisbility, value);
            }
        }

        private Visibility _bookBtnVisbility;
        public Visibility BookBtnVisibility
        {
            get { return _bookBtnVisbility; }
            set
            {
                SetProperty(ref _bookBtnVisbility, value);
            }
        }

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
        public ICommand backCommand { get; }


        public TripDetailsViewModel(TripagoContext dbContext)
        {
            _dbContext = dbContext;
            this.backCommand = new BackToHomeCommand(this);
            SetTour(ApplicationHelper.TourId);
            SetAttractions();
            SetAccommodations();
            SetRestaurants();
            SetButtons();
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

        public void SetButtons()
        {
            TourTraveler tourTraveler = _dbContext.TourTravelers.FirstOrDefault(c => c.TravelerId == ApplicationHelper.User.Id && c.TourId == this.Tour.Id);
            if (tourTraveler == null)
            {
                CancelBtnVisibility = Visibility.Collapsed;
                ReserveBtnVisibility = Visibility.Visible;
                BookBtnVisibility = Visibility.Visible;
            }
            else
            {
                if (tourTraveler.BookingStatus == BookingStatus.RESERVATION)
                {
                    CancelBtnVisibility = Visibility.Visible;
                    ReserveBtnVisibility = Visibility.Collapsed;
                    BookBtnVisibility = Visibility.Visible;
                }
                else
                {
                    CancelBtnVisibility = Visibility.Visible;
                    ReserveBtnVisibility = Visibility.Collapsed;
                    BookBtnVisibility = Visibility.Collapsed;
                }
            }
        }

    }
}
