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
    public class Attraction
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

        public Attraction() { }

        public Attraction(string name, string image, Address address)
        {
            Name = name;
            Image = image;
            Address = address;
        }

        public Attraction(AttractionDTO attractionDTO)
        {
            Name = attractionDTO.Name;
            Image = attractionDTO.Image;
            Address = new Address(attractionDTO.Address);
            Latitude = attractionDTO.Latitude;
            Longitude = attractionDTO.Longitude;
        }
    }
}
