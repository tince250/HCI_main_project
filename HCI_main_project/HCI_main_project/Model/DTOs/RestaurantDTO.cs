using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Model.DTOs
{
    public class RestaurantDTO
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public Address Address { get; set; }

    }
}
