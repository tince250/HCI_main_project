using HCI_main_project.Commands;
using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCI_main_project.ViewModel
{
    internal class HistoryCardViewModel : ViewModelBase
    {
        private Tour tour;

        public Tour Tour
        {
            get { return tour; }
            set { tour = value; }
        }

        private bool isBooked;

        public bool IsBooked
        {
            get { return isBooked; }
            set { isBooked = value; }
        }

        private bool isCancelable;

        public bool IsCancelable
        {
            get { return isCancelable; }
            set { isCancelable = value; }
        }

        private string clearText;

        public string ClearText
        {
            get { return clearText; }
            set { clearText = value; }
        }

        private string userRole;

        public string LoggedUserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }

        private int noReservations;

        public int NoReservations
        {
            get { return noReservations; }
            set { noReservations = value; }
        }
        
        private int noBookings;

        public int NoBookings
        {
            get { return noBookings; }
            set { noBookings = value; }
        }

        

        public ICommand openTourDetailsCommand { get; }
        public ICommand cancelReservationCommand { get; }

        public HistoryCardViewModel(Tour tour)
        {
            this.Tour = tour;
            this.LoggedUserRole = ApplicationHelper.User.Role == UserRole.AGENT ? "agent" : "traveler";

            if (this.LoggedUserRole == "traveler")
            {
                this.isBooked = tour.TourTravelers.Where(t => t.TravelerId == ApplicationHelper.User.Id).First().BookingStatus == BookingStatus.BOOKING;
                this.isCancelable = tour.From > DateTime.Now;
                if (isBooked && IsCancelable)
                {
                    ClearText = "Cancel booking";
                }
                else if (IsCancelable && !isBooked)
                {
                    ClearText = "Cancel reservation";
                }
            } 
            else
            {
                setStatistics();
            }

            
            
            this.openTourDetailsCommand = new OpenTourDetailsCommand(ApplicationHelper.HomePageVm, this.Tour.Id);
        }

        private void setStatistics()
        {
            this.NoReservations = tour.TourTravelers.Where(tt => tt.BookingStatus == BookingStatus.RESERVATION).ToList().Count;
            this.NoBookings = tour.TourTravelers.Where(tt => tt.BookingStatus == BookingStatus.BOOKING).ToList().Count;
        }
    }
}
