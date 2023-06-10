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

        public DetailsCardContent(Attraction attraction)
        {
            this.Name = attraction.Name;
            this.Description = attraction.Address.AddressStr();
        }

        public DetailsCardContent(Accommodation accommodation)
        {
            this.Name = accommodation.Name;
            this.Description = accommodation.Address.AddressStr();
        }

        public DetailsCardContent(Restaurant restaurant)
        {
            this.Name = restaurant.Name;
            this.Description = restaurant.Address.AddressStr();
        }

        public DetailsCardContent(Tour tour)
        {
            this.Name = tour.Name;
            this.Description = "from " + tour.From.ToString("dd.MM.yyyy.") + " to " + tour.To.ToString("dd.MM.yyyy.");
        }
    }
}
