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
    public class AddAttractionsButtonCommand : CommandBase
    {
        private int id;

        public AddAttractionsButtonCommand(int id = -1)
        {
            this.id = id;
        }

        public override void Execute(object? parameter)
        {
            if (this.id != -1)
            {
                Attraction a = App.serviceProvider.GetService<TripagoContext>().Attractions.FirstOrDefault(t => t.Id == this.id);
                AddEditAttractionPage page = new AddEditAttractionPage(a);
                ApplicationHelper.NavigationService.Navigate(page);
            } else
            {
                AddEditAttractionPage page = new AddEditAttractionPage();
                ApplicationHelper.NavigationService.Navigate(page);
            }
        }
    }
}