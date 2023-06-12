using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Model.DTOs
{
    public class AddressDTO
    {
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }

        public AddressDTO(string city, int postalCode, string street, string streetNumber)
        {
            City = city;
            PostalCode = postalCode;
            Street = street;
            StreetNumber = streetNumber;
        }
    }
}
