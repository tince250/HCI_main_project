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
        public abstract void Add(Restaurant restaurant);

        public abstract void Edit();

        public abstract void Delete();
    }
}
 