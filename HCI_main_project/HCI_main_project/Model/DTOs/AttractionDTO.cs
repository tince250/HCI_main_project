using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Model.DTOs
{
    public class AttractionDTO
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public AddressDTO Address { get; set; }

        public AttractionDTO(string name, string image, AddressDTO address)
        {
            Name = name;
            Image = image;
            Address = address;
        }
    }
}
