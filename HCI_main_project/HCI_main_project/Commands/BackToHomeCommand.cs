using HCI_main_project.Pages;
using HCI_main_project.View;
using HCI_main_project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Commands
{
    class BackToHomeCommand : CommandBase
    {
        private TripDetailsViewModel tripDetailsViewModel;

        public BackToHomeCommand(TripDetailsViewModel tripDetailsViewModel)
        {
            this.tripDetailsViewModel = tripDetailsViewModel;
        }

        public override void Execute(object? parameter)
        {
            //ApplicationHelper.User = null;
            Homepage homePage = new Homepage();
            ApplicationHelper.NavigationService.Navigate(homePage);
        }
    }
}
