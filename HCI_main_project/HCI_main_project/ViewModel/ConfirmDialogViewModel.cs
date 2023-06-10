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
    public enum DialogType
    {
        RESERVE_TOUR,
        BOOK_TOUR,
        DELETE_TOUR,
        DELETE_ACCOMMODATION,
        DELETE_ATTRACTION,
        DELETE_RESTAURANT
    }
    class ConfirmDialogViewModel : ViewModelBaseS
    {
        private string _titleText;
        public string TitleText
        {
            get => _titleText;
            set
            {
                SetProperty(ref _titleText, value);
            }
        }

        private string _buttonText;
        public string ButtonText
        {
            get => _buttonText;
            set
            {
                SetProperty(ref _buttonText, value);
            }
        }

        private string _descriptionText;
        public string DescriptionText
        {
            get => _descriptionText;
            set
            {
                SetProperty(ref _descriptionText, value);
            }
        }

        private string _typeText;
        public string TypeText
        {
            get => _typeText;
            set
            {
                SetProperty(ref _typeText, value);
            }
        }

        private object _currItem;
        public object Item
        {
            get => _currItem;
            set
            {
                SetProperty(ref _currItem, value);
            }
        }

        private ObservableCollection<object> cards;
        public ObservableCollection<object> Cards
        {
            get { return cards; }
            set
            {
                SetProperty(ref cards, value);
            }
        }

        private TripagoContext dbContex;

        public ConfirmDialogViewModel(DialogType type)
        {
            ApplicationHelper.ToDeleteId = 1;
            this.dbContex = App.serviceProvider.GetService<TripagoContext>();
            switch (type)
            {
                case DialogType.BOOK_TOUR:
                    this.Item = this.dbContex.Tours.First(c => c.Id == ApplicationHelper.TourId);
                    this.Cards = new ObservableCollection<object>() { this.Item };
                    this.TitleText = "book";
                    this.TypeText = "tour.";
                    this.ButtonText = "Confirm booking";
                    this.DescriptionText = "By booking a tour, your spot is secured and payment is processed now.\r\nPlease review tour details before finalizing your booking:";
                    break;
                case DialogType.RESERVE_TOUR:
                    this.Item = this.dbContex.Tours.First(c => c.Id == ApplicationHelper.TourId);
                    this.Cards = new ObservableCollection<object>() { this.Item };
                    this.ButtonText = "Confirm reservation";
                    this.TitleText = "reserve";
                    this.TypeText = "tour.";
                    this.DescriptionText = "By reserving a tour, your spot is secured and you can pay uppon arrival.\r\nPlease review tour details before finalizing your reservation:";
                    break;
                case DialogType.DELETE_TOUR:
                    this.Item = this.dbContex.Tours.First(c => c.Id == ApplicationHelper.ToDeleteId);
                    this.Cards = new ObservableCollection<object>() { this.Item };
                    this.TitleText = "delete";
                    this.ButtonText = "Delete tour";
                    this.TypeText = "tour.";
                    this.DescriptionText = "Deleting is a permanent action, you won’t be able to undo it.\r\nPlease make sure this is the tour you want to delete:";
                    break;
                case DialogType.DELETE_ACCOMMODATION:
                    this.Item = this.dbContex.Accommodations.First(c => c.Id == ApplicationHelper.ToDeleteId);
                    this.Cards = new ObservableCollection<object>() { this.Item };
                    this.TitleText = "delete";
                    this.ButtonText = "Delete accommodation";
                    this.TypeText = "accomodation.";
                    this.DescriptionText = "Deleting is a permanent action, you won’t be able to undo it.\r\nPlease make sure this is the accommodation you want to delete:";
                    break;
                case DialogType.DELETE_ATTRACTION:
                    this.Item = this.dbContex.Attractions.First(c => c.Id == ApplicationHelper.ToDeleteId);
                    this.Cards = new ObservableCollection<object>() { this.Item };
                    this.TitleText = "delete";
                    this.ButtonText = "Delete attraction";
                    this.TypeText = "attraction.";
                    this.DescriptionText = "Deleting is a permanent action, you won’t be able to undo it.\r\nPlease make sure this is the attraction you want to delete:";
                    break;
                case DialogType.DELETE_RESTAURANT:
                    this.Item = this.dbContex.Restaurants.First(c => c.Id == ApplicationHelper.ToDeleteId);
                    this.Cards = new ObservableCollection<object>() { this.Item };
                    this.TitleText = "delete";
                    this.ButtonText = "Delete restaurant";
                    this.TypeText = "restaurant.";
                    this.DescriptionText = "Deleting is a permanent action, you won’t be able to undo it.\r\nPlease make sure this is the restaurant you want to delete:";
                    break;
            }
        }

    }
}
