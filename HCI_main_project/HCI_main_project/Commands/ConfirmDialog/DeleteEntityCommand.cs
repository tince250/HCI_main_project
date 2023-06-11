using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Commands
{
    public class DeleteEntityCommand : CommandBase
    {
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
            ApplicationHelper.HomePageVm.dbContext.Restaurants.Remove(restaurant);
            ApplicationHelper.HomePageVm.dbContext.SaveChanges();
            ApplicationHelper.HomePageVm.Objects.Remove(restaurant);
        }

        private void deleteAttraction(Attraction attraction)
        {
            ApplicationHelper.HomePageVm.dbContext.Attractions.Remove(attraction);
            ApplicationHelper.HomePageVm.dbContext.SaveChanges();
            ApplicationHelper.HomePageVm.Objects.Remove(attraction);
        }

        private void deleteAccommodation(Accommodation accommodation)
        {
            ApplicationHelper.HomePageVm.dbContext.Accommodations.Remove(accommodation);
            ApplicationHelper.HomePageVm.dbContext.SaveChanges();
            ApplicationHelper.HomePageVm.Objects.Remove(accommodation);
        }

        private void deleteTour(Tour tour)
        {
            if (tour != null)
            {
                ApplicationHelper.HomePageVm.dbContext.Tours.Remove(tour);
                ApplicationHelper.HomePageVm.dbContext.SaveChanges();
                ApplicationHelper.HomePageVm.Objects.Remove(tour);
            }
        }
    }
}
