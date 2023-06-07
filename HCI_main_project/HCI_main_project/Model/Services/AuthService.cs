using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Model.Services
{
    public class AuthService : IAuthService
    {
        private TripagoContext _context;

        public AuthService(TripagoContext context)
        {

            _context = context;

        }

        public void Register(User user)
        {
            User existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null) { throw new Exception("User with given email already exists."); }
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User Login(string email, string password)
        {
            User ?user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null || user.Password != password) 
            {
                throw new Exception("Bad credentials.");
            }
            return user;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
