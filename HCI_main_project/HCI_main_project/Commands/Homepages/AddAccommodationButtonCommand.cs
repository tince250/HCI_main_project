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
    public class AddAccommodationButtonCommand : CommandBase
    {
        private int id;

        public AddAccommodationButtonCommand(int id = -1)
        {
            this.id = id;
        }

        public override void Execute(object? parameter)
        {
            if (this.id != -1)
            {
                Accommodation a = App.serviceProvider.GetService<TripagoContext>().Accommodations.FirstOrDefault(t => t.Id == this.id);
                AddEditAccommodationPage page = new AddEditAccommodationPage(a);
                ApplicationHelper.NavigationService.Navigate(page);
            } else
            {
                AddEditAccommodationPage page = new AddEditAccommodationPage();
                ApplicationHelper.NavigationService.Navigate(page);
            }
        }
    }
}



