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
    public class AttractionService : IAttractionService
    {
        private TripagoContext _context;

        public AttractionService(TripagoContext context)
        {
            _context = context;
        }

        public void Add(AttractionDTO attractionDTO)
        {
            _context.Attractions.Add(new Attraction(attractionDTO));
            _context.SaveChanges();
        }

        public void Edit(int id, AttractionDTO attractionDTO)
        {
            Attraction attraction = _context.Attractions.Include(r => r.Address).FirstOrDefault(r => r.Id == 1);
            attraction.Address.City = attractionDTO.Address.City;
            attraction.Address.Street = attractionDTO.Address.Street;
            attraction.Address.PostalCode = attractionDTO.Address.PostalCode;
            attraction.Address.StreetNumber = attractionDTO.Address.StreetNumber;

            attraction.Name = attractionDTO.Name;
            attraction.Image = attractionDTO.Image;

            _context.SaveChanges();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
