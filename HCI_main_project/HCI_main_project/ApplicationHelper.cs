using HCI_main_project.Models;
using HCI_main_project.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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

        private static int toDeleteId;

        public static int ToDeleteId
        {
            get { return toDeleteId; }
            set { toDeleteId = value; }
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

        private static HomepageViewModel? homePageVm;
        public static HomepageViewModel? HomePageVm
        {
            set
            {
                homePageVm = value;
            }
            get
            {
                return homePageVm;
            }

        }

        public static string ParseImagePath(string filename, string type)
        {
            string dir = "";
            if (type == "attraction")
            {
                dir = "Attractions";
            } else if (type == "restaurant")
            {
                dir = "Restaurants";
            } else if (type == "accommodation")
            {
                dir = "Accommodations";
            }
            else
            {
                dir = "Tours";
            }
            if (dir == "Restaurants")
            {
                var kk = System.IO.Path.Combine("..", "Resources", dir, filename);
            }
            var ss = System.IO.Path.Combine("..","Resources", dir, filename);
            return ss;
        }
    }
}
