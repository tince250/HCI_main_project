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
    public class AddRestaurantButtonCommand : CommandBase
    {

        private int id;

        public AddRestaurantButtonCommand(int id = -1)
        {
            this.id = id;
        }

        public override void Execute(object? parameter)
        {
            if (this.id != -1)
            {
                Restaurant a = App.serviceProvider.GetService<TripagoContext>().Restaurants.FirstOrDefault(t => t.Id == this.id);
                AddEditRestaurantPage page = new AddEditRestaurantPage(a);
                ApplicationHelper.NavigationService.Navigate(page);
            }
            else
            {
                AddEditRestaurantPage page = new AddEditRestaurantPage();
                ApplicationHelper.NavigationService.Navigate(page);
            }
        }
    }
}
