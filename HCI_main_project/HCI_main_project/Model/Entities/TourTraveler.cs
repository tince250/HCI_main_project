using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Models
{
    public enum BookingStatus
    {
        RESERVATION, BOOKING
    }

    public class TourTraveler
    {
        [ForeignKey("Tour")]
        public int TourId { get; set; }
        public virtual Tour Tour { get; set; }

        [ForeignKey("User")]
        public int TravelerId { get; set; }
        public virtual User Traveler { get; set; }

        public BookingStatus BookingStatus { get; set; }
    }
}
