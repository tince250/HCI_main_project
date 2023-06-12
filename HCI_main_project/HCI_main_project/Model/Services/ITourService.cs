using HCI_main_project.Model.DTOs;
using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Model.Services
{
    public interface ITourService
    {
        public abstract User GetTravelAgent();
        public abstract void Add(Tour tour);

        public abstract void Edit(Tour tour);

        public abstract void Delete();
    }
}
