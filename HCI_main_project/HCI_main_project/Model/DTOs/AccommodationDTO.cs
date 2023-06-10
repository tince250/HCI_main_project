using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Model.DTOs
{
    public class AccommodationDTO
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public AccommodationType Type { get; set; }
        public AddressDTO Address { get; set; }

        public AccommodationDTO(string name, string image, AccommodationType type, AddressDTO address)
        {
            Name = name;
            Image = image;
            Type = type;
            Address = address;
        }
    }
}
