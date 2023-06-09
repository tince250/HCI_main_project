using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace HCI_main_project
{
    public static class ApplicationHelper
    {
        private static NavigationService navigator;

        
        private static User user { get; set; }

        private static int tourId;

        public static int TourId
        {
            get { return tourId; }
            set { tourId = value; }
        }


        public static NavigationService NavigationService
        {
            set
            {
                navigator = value;
            }
            get
            {
                return navigator;
            }

        }

        public static User? User
        {
            set
            {
                user = value;
            }
            get
            {
                return user;
            }

        }
    }
}
