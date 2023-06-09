using HCI_main_project.Model.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }

        public Address()
        {

        }
        public Address(string city, int postalCode, string street, int streetNumber)
        {
            City = city;
            PostalCode = postalCode;
            Street = street;
            StreetNumber = streetNumber;
        }

        public Address(AddressDTO addressDTO)
        {
            City = addressDTO.City;
            PostalCode = 21400;
            Street = addressDTO.Street;
            StreetNumber = addressDTO.StreetNumber;
        }
    }
}
