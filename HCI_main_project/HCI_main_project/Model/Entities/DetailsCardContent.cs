using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Model.Entities
{
    public class DetailsCardContent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public DetailsCardContent(Attraction attraction)
        {
            this.Name = attraction.Name;
            this.Description = attraction.Address.AddressStr();
            this.ImagePath = ApplicationHelper.ParseImagePath(attraction.Image, "attraction");
        }

        public DetailsCardContent(Accommodation accommodation)
        {
            this.Name = accommodation.Name;
            this.Description = accommodation.Address.AddressStr();
            this.ImagePath = ApplicationHelper.ParseImagePath(accommodation.Image, "accommodation");
        }

        public DetailsCardContent(Restaurant restaurant)
        {
            this.Name = restaurant.Name;
            this.Description = restaurant.Address.AddressStr();
            this.ImagePath = ApplicationHelper.ParseImagePath(restaurant.Image, "restaurant");
        }

        public DetailsCardContent(Tour tour)
        {
            this.Name = tour.Name;
            this.Description = "from " + tour.From.ToString("dd.MM.yyyy.") + " to " + tour.To.ToString("dd.MM.yyyy.");
            this.ImagePath = ApplicationHelper.ParseImagePath(tour.Image, "tour");
        }
    }
}
