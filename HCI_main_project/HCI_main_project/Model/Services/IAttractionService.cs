using HCI_main_project.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Model.Services
{
    public interface IAttractionService
    {
        public abstract void Add(AttractionDTO attractionDTO);

        public abstract void Edit(int id, AttractionDTO attractionDTO);

        public abstract void Delete();
    }
}
