using HCI_main_project.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Model.Services
{
    public interface IAccommodationService
    {
        public abstract void Add(AccommodationDTO accommodationDTO);

        public abstract void Edit(int id, AccommodationDTO accommodationDTO);

        public abstract void Delete();
    }
}
