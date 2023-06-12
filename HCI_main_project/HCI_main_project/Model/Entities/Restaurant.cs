using HCI_main_project.Model.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Restaurant()
        {

        }
        public Restaurant(string name, string image, Address address)
        {
            Name = name;
            Image = image;
            Address = address;
        }

        public Restaurant(RestaurantDTO restaurantDTO)
        {
            Name = restaurantDTO.Name;
            Image = restaurantDTO.Image;
            Address = new Address(restaurantDTO.Address);
            Latitude = restaurantDTO.Latitude;
            Longitude = restaurantDTO.Longitude;
        }
    }
}
