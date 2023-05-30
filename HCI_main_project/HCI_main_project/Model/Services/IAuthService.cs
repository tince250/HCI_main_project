using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Model.Services
{
    public interface IAuthService
    {
        public void Register(User user);
        public User Login(string email, string password);

        public User GetByEmail(string email);
    }
}
