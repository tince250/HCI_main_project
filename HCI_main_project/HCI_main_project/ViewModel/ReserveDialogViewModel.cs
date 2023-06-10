using HCI_main_project.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.ViewModel
{
    class ReserveDialogViewModel : ViewModelBaseS
    {
        private string _isReservationTitle;
        public string IsReservationTitle
        {
            get => _isReservationTitle;
            set
            {
                SetProperty(ref _isReservationTitle, value);
            }
        }

        private string _isReservationButton;
        public string IsReservationButton
        {
            get => _isReservationButton;
            set
            {
                SetProperty(ref _isReservationButton, value);
            }
        }

        private Tour _tour;
        public Tour Tour
        {
            get => _tour;
            set
            {
                SetProperty(ref _tour, value);
            }
        }

        private ObservableCollection<object> tours;
        public ObservableCollection<object> Tours
        {
            get { return tours; }
            set
            {
                SetProperty(ref tours, value);
            }
        }

        private TripagoContext dbContex;

        public ReserveDialogViewModel(bool isReservation)
        {
            if (isReservation)
            {
                this.IsReservationButton = "Confirm reservation";
                this.IsReservationTitle = "reservation";
            }
            else
            {
                this.IsReservationTitle = "book";
                this.IsReservationButton = "Confirm booking";
            }
            this.dbContex = App.serviceProvider.GetService<TripagoContext>();
            this.Tour = this.dbContex.Tours.First(c => c.Id == ApplicationHelper.TourId);
            this.Tours = new ObservableCollection<object>() { this.Tour };
        }

    }
}
