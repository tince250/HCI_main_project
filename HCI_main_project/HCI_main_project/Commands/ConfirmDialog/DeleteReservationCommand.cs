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
    internal class DeleteReservationCommand : CommandBase
    {
        private ConfirmDialogViewModel confirmDialogViewModel;
        private TripDetailsViewModel tripDetailsViewModel;
        private TripagoContext dbContext;
        public DeleteReservationCommand(ConfirmDialogViewModel confirmDialogViewModel, TripagoContext dbContext, TripDetailsViewModel tripDetailsViewModel)
        {
            this.confirmDialogViewModel = confirmDialogViewModel;
            this.dbContext = dbContext;
            this.tripDetailsViewModel = tripDetailsViewModel;
        }

        public override void Execute(object? parameter)
        {
            TourTraveler tourTraveler;
            tourTraveler = dbContext.TourTravelers.FirstOrDefault(c => c.TravelerId == ApplicationHelper.User.Id && c.TourId == ((Tour)confirmDialogViewModel.Item).Id);

            if (tourTraveler != null) 
            {
                dbContext.TourTravelers.Remove(tourTraveler);
                dbContext.SaveChanges();
            }
            this.confirmDialogViewModel.IsDone = true;
            tripDetailsViewModel.SetButtons();
            Thread.Sleep(3000);
            this.confirmDialogViewModel.Visibility = System.Windows.Visibility.Collapsed;
        }
    }

}
