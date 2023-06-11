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
        private int tourId;

        public OpenTourDetailsCommand(HomepageViewModel homepageViewModel, int tourId)
        {
            this.homepageViewModel = homepageViewModel;
            this.tourId = tourId;
        }

        public override void Execute(object? parameter)
        {
            ApplicationHelper.TourId = tourId;
            TripDetailsPage detailsPage = new TripDetailsPage();
            ApplicationHelper.NavigationService.Navigate(detailsPage);
        }
    }
}
