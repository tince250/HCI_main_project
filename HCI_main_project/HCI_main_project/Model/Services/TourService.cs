using HCI_main_project.Model.DTOs;
using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Model.Services
{
    public class TourService : ITourService
    {
        private TripagoContext _context;

        public TourService(TripagoContext context)
        {
            _context = context;
        }

        public User GetTravelAgent()
        {
            return _context.Users.FirstOrDefault(e => e.Role == 0);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Edit(Tour tour)
        {
            _context.SaveChanges();
        }

        public void Add(Tour tour)
        {
            _context.Tours.Add(tour);
            _context.SaveChanges();
        }
    }
}
