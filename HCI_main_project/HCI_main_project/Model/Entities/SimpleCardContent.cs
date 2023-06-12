using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Model.Entities
{
    public class SimpleCardContent
    {
        public SimpleCardContent(Attraction attraction)
        {
            this.Id = attraction.Id;
            this.Name = attraction.Name;
            this.Image = attraction.Image;
            this.Address = attraction.Address;
        }
        public SimpleCardContent(Accommodation accommodation)
        {
            this.Id = accommodation.Id;
            this.Name = accommodation.Name;
            this.Image = accommodation.Image;
            this.Address = accommodation.Address;
            this.AccommodationType = accommodation.Type;
        }
        public SimpleCardContent(Restaurant restaurant)
        {
            this.Id = restaurant.Id;
            this.Name = restaurant.Name;
            this.Image = restaurant.Image;
            this.Address = restaurant.Address;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public AccommodationType? AccommodationType { get; set; }
        public Address Address { get; set; }
    }
}
