using HCI_main_project.Model.Entities;
using HCI_main_project.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HCI_main_project.ViewModel
{
    internal class UsersInTourViewModel : ViewModelBaseS
    {
        private ObservableCollection<object> _cards;
        public ObservableCollection<object> Cards
        {
            get { return _cards; }
            set
            {
                SetProperty(ref _cards, value);
            }
        }

        private Visibility _visibility;
        public Visibility Visibility
        {
            get => _visibility;
            set
            {
                SetProperty(ref _visibility, value);
            }
        }

        private TripagoContext _dbContext;
        public Tour tour;

        public UsersInTourViewModel()
        {
            _dbContext = App.serviceProvider.GetService<TripagoContext>();
            tour = _dbContext.Tours.FirstOrDefault(c => c.Id == ApplicationHelper.TourId);
            SetCards();
        }

        private void SetCards()
        {
            this.Cards = new ObservableCollection<object>();
            List<User> users = this.tour.TourTravelers.Select(tourTravelers => tourTravelers.Traveler).ToList();
            for (int i = 0; i < users.Count; i++)
            {
                this.Cards.Add(new UserCardContent(users[i], this.tour.TourTravelers[i].BookingStatus));
            }
        }
    }
}
