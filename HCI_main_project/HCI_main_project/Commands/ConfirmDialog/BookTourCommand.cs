﻿using HCI_main_project.Models;
using HCI_main_project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HCI_main_project.Commands
{
    class BookTourCommand : CommandBase
    {
        private ConfirmDialogViewModel confirmDialogViewModel;
        private TripDetailsViewModel tripDetailsViewModel;
        private TripagoContext dbContext;
        public BookTourCommand(ConfirmDialogViewModel confirmDialovViewModel, TripagoContext dbContext, TripDetailsViewModel tripDetailsViewModel)
        {
            this.confirmDialogViewModel = confirmDialovViewModel;
            this.dbContext = dbContext;
            this.tripDetailsViewModel = tripDetailsViewModel;
        }

        public override void Execute(object? parameter)
        {
            TourTraveler tourTraveler;
            tourTraveler = dbContext.TourTravelers.FirstOrDefault(c => c.TravelerId == ApplicationHelper.User.Id && c.TourId == ((Tour)confirmDialogViewModel.Item).Id);

            if (tourTraveler == null)
            {
                tourTraveler = new TourTraveler
                {
                    BookingStatus = BookingStatus.BOOKING,
                    Tour = confirmDialogViewModel.Item as Tour,
                    TourId = ((Tour)confirmDialogViewModel.Item).Id,
                    Traveler = ApplicationHelper.User,
                    TravelerId = ApplicationHelper.User.Id
                };
                dbContext.TourTravelers.Add(tourTraveler);
                dbContext.SaveChanges();
            } else
            {
                tourTraveler.BookingStatus = BookingStatus.BOOKING;
                dbContext.SaveChanges();
            }
            this.confirmDialogViewModel.IsDone = true;
            //this.tripDetailsViewModel.SetButtons();
            //Thread.Sleep(3000);
            //this.confirmDialogViewModel.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
