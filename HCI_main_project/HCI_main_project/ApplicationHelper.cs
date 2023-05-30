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
    }
}
