using HCI_main_project.Models;
using HCI_main_project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HCI_main_project.Commands.ConfirmDialog
{
    internal class DeleteReservationCommandHistory : CommandBase
    {
        private ConfirmDialogViewModel confirmDialogViewModel;
        private TripagoContext dbContext;
        private HomepageViewModel homepageViewModel;

        public DeleteReservationCommandHistory(ConfirmDialogViewModel confirmDialogViewModel, TripagoContext dbContext, HomepageViewModel homepageViewModel)
        {
            this.confirmDialogViewModel = confirmDialogViewModel;
            this.dbContext = dbContext;
            this.homepageViewModel = homepageViewModel;
        }

        public override void Execute(object? parameter)
        {
            TourTraveler tourTraveler;
            tourTraveler = dbContext.TourTravelers.FirstOrDefault(c => c.TravelerId == ApplicationHelper.User.Id && c.TourId == ((Tour)confirmDialogViewModel.Item).Id);

            if (tourTraveler != null) 
            {
                dbContext.TourTravelers.Remove(tourTraveler);
                dbContext.SaveChanges();
                this.homepageViewModel.Objects.Remove((Tour)confirmDialogViewModel.Item);
            }
            this.confirmDialogViewModel.IsDone = true;
            
        }
    }

}
