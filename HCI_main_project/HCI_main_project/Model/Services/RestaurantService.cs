using HCI_main_project.Model.DTOs;
using HCI_main_project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Model.Services
{
    public class RestaurantService : IRestaurantService
    {
        private TripagoContext _context;

        public RestaurantService(TripagoContext context)
        {
            _context = context;
        }

        public void Add(RestaurantDTO restaurantDTO)
        {
            var r = new Restaurant(restaurantDTO);
            _context.Restaurants.Add(r);
            _context.SaveChanges();
        }

        public void Edit(int id, RestaurantDTO restaurantDTO)
        {
            Restaurant restaurant = _context.Restaurants.Include(r => r.Address).FirstOrDefault(r => r.Id == id);
            restaurant.Address.City = restaurantDTO.Address.City;
            restaurant.Address.Street = restaurantDTO.Address.Street;
            restaurant.Address.PostalCode = restaurantDTO.Address.PostalCode;
            restaurant.Address.StreetNumber = restaurantDTO.Address.StreetNumber;

            restaurant.Name = restaurantDTO.Name;
            restaurant.Image = restaurantDTO.Image;

            _context.SaveChanges();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

       
    }
}
