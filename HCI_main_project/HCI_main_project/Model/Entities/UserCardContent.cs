using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Model.Entities
{
    public class UserCardContent
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }

        public UserCardContent(User user, BookingStatus status)
        {
            Name = user.FirstName + " " + user.LastName;
            Email = user.Email;
            if (status == BookingStatus.BOOKING)
                this.Status = "BOOKED";
            else
                this.Status = "RESERVED";
        }
    }
}
