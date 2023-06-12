using HCI_main_project.ViewModel;
using HCI_main_project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCI_main_project.Pages;
using HCI_main_project.Models;
using Microsoft.Extensions.DependencyInjection;

namespace HCI_main_project.Commands.Homepages
{
    public class AddTourButtonCommand : CommandBase
    {
        private Tour tour; 

        public AddTourButtonCommand(Tour tour = null)
        {
            this.tour = tour;
        }

        public override void Execute(object? parameter)
        {
            if (this.tour != null)
            {
                AddEditTourPage page = new AddEditTourPage(this.tour);
                ApplicationHelper.NavigationService.Navigate(page);
            } else
            {
                AddEditTourPage page = new AddEditTourPage();
                ApplicationHelper.NavigationService.Navigate(page);
            }
        }
    }
}
