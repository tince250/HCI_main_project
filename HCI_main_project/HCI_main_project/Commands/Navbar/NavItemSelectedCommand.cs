using HCI_main_project.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Commands
{
    public class NavItemSelectedCommand : CommandBase
    {
        private HomepageViewModel homepageViewModel;

        public NavItemSelectedCommand(HomepageViewModel homepageViewModel)
        {
            this.homepageViewModel = homepageViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (parameter is string radioButtonName)
            {
                if (radioButtonName == "ToursNavItem")
                {
                    Trace.WriteLine("ToursNavItem is checked");
                    homepageViewModel.SetTours();
                }
                else if (radioButtonName == "AttractionsNavItem")
                {
                    // Execute the desired action for AttractionsNavItem
                    Trace.WriteLine("AttractionsNavItem is checked");
                    homepageViewModel.SetAttractions();
                }
                else if (radioButtonName == "AccommodationNavItem")
                {
                    // Execute the desired action for AccommodationsNavItem
                    Trace.WriteLine("AccommodationsNavItem is checked");
                    homepageViewModel.SetAccommodation();
                }
                else if (radioButtonName == "RestaurantsNavItem")
                {
                    // Execute the desired action for RestaurantsNavItem
                    Trace.WriteLine("RestaurantsNavItem is checked");
                    homepageViewModel.SetRestaurants();
                }
            }
        }
    }
}
