using HCI_main_project.Models;
using HCI_main_project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Commands
{
    class DeleteEntityCommand : CommandBase
    {
        private ConfirmDialogViewModel confirmDialogVM;
        private TripagoContext dbContext;

        public DeleteEntityCommand(ConfirmDialogViewModel vm, TripagoContext context)
        {
            this.confirmDialogVM = vm;
            this.dbContext = context;
        }

        public override void Execute(object? parameter)
        {
            if (parameter is Tour tour)
            {
                deleteTour(tour); 
            } 
            else if (parameter is Accommodation accommodation)
            {
                deleteAccommodation(accommodation);
            }
            else if (parameter is Attraction attraction)
            {
                deleteAttraction(attraction);
            }
            else if (parameter is Restaurant restaurant)
            {
                deleteRestaurant(restaurant);
            }
        }

        private void deleteRestaurant(Restaurant restaurant)
        {
            this.dbContext.Restaurants.Remove(restaurant);
            this.dbContext.SaveChanges();
            ApplicationHelper.HomePageVm.Objects.Remove(restaurant);
            this.confirmDialogVM.IsDone = true;
        }

        private void deleteAttraction(Attraction attraction)
        {
            this.dbContext.Attractions.Remove(attraction);
            this.dbContext.SaveChanges();
            ApplicationHelper.HomePageVm.Objects.Remove(attraction);
            this.confirmDialogVM.IsDone = true;
        }

        private void deleteAccommodation(Accommodation accommodation)
        {
            this.dbContext.Accommodations.Remove(accommodation);
            this.dbContext.SaveChanges();
            ApplicationHelper.HomePageVm.Objects.Remove(accommodation);
            this.confirmDialogVM.IsDone = true;
        }

        private void deleteTour(Tour tour)
        {
            if (tour != null)
            {
                this.dbContext.Tours.Remove(tour);
                this.dbContext.SaveChanges();
                ApplicationHelper.HomePageVm.Objects.Remove(tour);
                this.confirmDialogVM.IsDone = true;
            }
        }
    }
}
