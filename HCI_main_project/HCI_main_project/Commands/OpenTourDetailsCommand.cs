using HCI_main_project.ViewModel;
using HCI_main_project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Commands
{
    public class OpenTourDetailsCommand : CommandBase
    {
        private HomepageViewModel homepageViewModel;

        public OpenTourDetailsCommand(HomepageViewModel homepageViewModel)
        {
            this.homepageViewModel = homepageViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (parameter is int id)
            {
                ApplicationHelper.TourId = id;
                TripDetailsPage detailsPage = new TripDetailsPage();
                ApplicationHelper.NavigationService.Navigate(detailsPage);
            }
        }
    }
}
