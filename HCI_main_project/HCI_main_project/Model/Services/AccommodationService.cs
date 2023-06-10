using HCI_main_project.Model.DTOs;
using HCI_main_project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Model.Services
{
    public class AccommodationService : IAccommodationService
    {

        private TripagoContext _context;

        public AccommodationService(TripagoContext context)
        {
            _context = context;
        }

        public void Add(AccommodationDTO accommodationDTO)
        {
            _context.Accommodations.Add(new Accommodation(accommodationDTO));
            _context.SaveChanges();
        }

        public void Edit(int id, AccommodationDTO accommodationDTO)
        {
            Accommodation accommodation = _context.Accommodations.Include(r => r.Address).FirstOrDefault(r => r.Id == 1);
            accommodation.Address.City = accommodationDTO.Address.City;
            accommodation.Address.Street = accommodationDTO.Address.Street;
            accommodation.Address.PostalCode = accommodationDTO.Address.PostalCode;
            accommodation.Address.StreetNumber = accommodationDTO.Address.StreetNumber;

            accommodation.Name = accommodationDTO.Name;
            accommodation.Image = accommodationDTO.Image;

            _context.SaveChanges();
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
