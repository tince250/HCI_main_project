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
    public enum AccommodationType
    {
        HOTEL, APARTMENT
    }

    public class Accommodation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public AccommodationType Type { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Accommodation()
        {

        }
        public Accommodation(string name, string image, AccommodationType type, Address address)
        {
            Name = name;
            Image = image;
            Type = type;
            Address = address;
        }

        public Accommodation(AccommodationDTO accommodationDTO)
        {
            Name = accommodationDTO.Name;
            Image = accommodationDTO.Image;
            Type = accommodationDTO.Type;
            Address = new Address(accommodationDTO.Address);
            Latitude = accommodationDTO.Latitude;
            Longitude = accommodationDTO.Longitude;
        }
    }
}
