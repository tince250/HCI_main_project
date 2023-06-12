using HCI_main_project.Model.DTOs;
using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Model.Services
{
    public interface IRestaurantService
    {
        public abstract void Add(RestaurantDTO restaurantDto);

        public abstract void Edit(int id, RestaurantDTO restaurantDTO);

        public abstract void Delete();
    }
}
 