using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Models
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [ForeignKey("TravelAgent")]
        public int TravelAgentId { get; set; }
        public virtual User TravelAgent { get; set; }

        public virtual List<TourAttraction> TourAttractions { get; set; }
        public virtual List<TourAccommodation> TourAccommodations { get; set; }
        public virtual List<TourRestaurant> TourRestaurants { get; set; }
        public virtual List<TourTraveler> TourTravelers { get; set; }

        public Tour() { }

        public void AddAttraction(Attraction attraction)
        {
            if (TourAttractions == null)
                TourAttractions = new List<TourAttraction>();

            TourAttraction tourAttraction = new TourAttraction
            {
                Tour = this,
                Attraction = attraction
            };

            TourAttractions.Add(tourAttraction);
        }

        public void AddAccommodation(Accommodation accommodation)
        {
            if (TourAccommodations == null)
                TourAccommodations = new List<TourAccommodation>();

            TourAccommodation tourAccommodation = new TourAccommodation
            {
                Tour = this,
                Accommodation = accommodation
            };

            TourAccommodations.Add(tourAccommodation);
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            if (TourRestaurants == null)
                TourRestaurants = new List<TourRestaurant>();

            TourRestaurant tourRestaurant = new TourRestaurant
            {
                Tour = this,
                Restaurant = restaurant
            };

            TourRestaurants.Add(tourRestaurant);
        }

    }
}
