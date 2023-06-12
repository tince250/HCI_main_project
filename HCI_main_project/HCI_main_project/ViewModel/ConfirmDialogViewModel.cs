using HCI_main_project.Commands;
using HCI_main_project.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HCI_main_project.ViewModel
{
    public enum DialogType
    {
        RESERVE_TOUR,
        BOOK_TOUR,
        DELETE_TOUR,
        DELETE_ACCOMMODATION,
        DELETE_ATTRACTION,
        DELETE_RESTAURANT,
        GO_BACK_CRUD
    }
    class ConfirmDialogViewModel : ViewModelBaseS
    {
        private bool _done;
        public bool IsDone
        {
            get => _done;
            set
            {
                SetProperty(ref _done, value);
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

        private string _titleText;
        public string TitleText
        {
            get => _titleText;
            set
            {
                SetProperty(ref _titleText, value);
            }
        }

        private string _titleStartText;
        public string TitleStartText
        {
            get => _titleStartText;
            set
            {
                SetProperty(ref _titleStartText, value);
            }
        }

        private string _titleMiddleText;
        public string TitleMiddleText
        {
            get => _titleMiddleText;
            set
            {
                SetProperty(ref _titleMiddleText, value);
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
        public ICommand confirmCommand { get; }
        public object confirmCommandParameter { get; }
        public string SuccessMessage { get;  }

        public ConfirmDialogViewModel(DialogType type)
        {
            this.IsDone = false;
            this.dbContex = App.serviceProvider.GetService<TripagoContext>();
            switch (type)
            {
                case DialogType.BOOK_TOUR:
                    this.Item = this.dbContex.Tours.First(c => c.Id == ApplicationHelper.TourId);
                    this.Cards = new ObservableCollection<object>() { this.Item };
                    this.confirmCommand = new BookTourCommand(this, dbContex);
                    this.TitleText = "book";
                    this.TitleStartText = " You are about to ";
                    this.TitleMiddleText = " your spot for ";
                    this.TypeText = "tour.";
                    this.ButtonText = "Confirm booking";
                    this.DescriptionText = "By booking a tour, your spot is secured and payment is processed now.\r\nPlease review tour details before finalizing your booking:";
                    this.SuccessMessage = "Tour booked successfully!";
                    break;
                case DialogType.RESERVE_TOUR:
                    this.Item = this.dbContex.Tours.First(c => c.Id == ApplicationHelper.TourId);
                    this.Cards = new ObservableCollection<object>() { this.Item };
                    this.confirmCommand = new ReserveTourCommand(this, dbContex);
                    this.ButtonText = "Confirm reservation";
                    this.TitleText = "reserve";
                    this.TitleStartText = "You are about to ";
                    this.TitleMiddleText = " your spot for ";
                    this.TypeText = "tour.";
                    this.DescriptionText = "By reserving a tour, your spot is secured and you can pay uppon arrival.\r\nPlease review tour details before finalizing your reservation:";
                    this.SuccessMessage = "Tour reserved successfully!";
                    break;
                case DialogType.DELETE_TOUR:
                    this.Item = this.dbContex.Tours.First(c => c.Id == ApplicationHelper.ToDeleteId);
                    this.Cards = new ObservableCollection<object>() { this.Item };
                    this.TitleText = "delete";
                    this.TitleStartText = "Are you sure you want to ";
                    this.TitleMiddleText = "";
                    this.ButtonText = "Delete tour";
                    this.TypeText = "tour?";
                    this.DescriptionText = "Deleting is a permanent action, you won’t be able to undo it.\r\nPlease make sure this is the tour you want to delete:";
                    this.confirmCommand = new DeleteEntityCommand(this, dbContex);
                    this.confirmCommandParameter = this.Item;
                    this.SuccessMessage = "Tour deleted successfully!";
                    break;
                case DialogType.DELETE_ACCOMMODATION:
                    this.Item = this.dbContex.Accommodations.First(c => c.Id == ApplicationHelper.ToDeleteId);
                    this.Cards = new ObservableCollection<object>() { this.Item };
                    this.TitleText = "delete";
                    this.TitleStartText = "Are you sure you want to ";
                    this.TitleMiddleText = "";
                    this.ButtonText = "Delete accommodation";
                    this.TypeText = "accomodation?";
                    this.DescriptionText = "Deleting is a permanent action, you won’t be able to undo it.\r\nPlease make sure this is the accommodation you want to delete:";
                    this.confirmCommand = new DeleteEntityCommand(this, dbContex);
                    this.confirmCommandParameter = this.Item;
                    this.SuccessMessage = "Accommodation deleted successfully!";
                    break;
                case DialogType.DELETE_ATTRACTION:
                    this.Item = this.dbContex.Attractions.First(c => c.Id == ApplicationHelper.ToDeleteId);
                    this.Cards = new ObservableCollection<object>() { this.Item };
                    this.TitleText = "delete";
                    this.TitleStartText = "Are you sure you want to ";
                    this.TitleMiddleText = "";
                    this.ButtonText = "Delete attraction";
                    this.TypeText = "attraction?";
                    this.DescriptionText = "Deleting is a permanent action, you won’t be able to undo it.\r\nPlease make sure this is the attraction you want to delete:";
                    this.confirmCommand = new DeleteEntityCommand(this, dbContex);
                    this.confirmCommandParameter = this.Item;
                    this.SuccessMessage = "Attraction deleted successfully!";
                    break;
                case DialogType.DELETE_RESTAURANT:
                    this.Item = this.dbContex.Restaurants.First(c => c.Id == ApplicationHelper.ToDeleteId);
                    this.Cards = new ObservableCollection<object>() { this.Item };
                    this.TitleText = "delete";
                    this.TitleStartText = "Are you sure you want to ";
                    this.TitleMiddleText = "";
                    this.ButtonText = "Delete restaurant";
                    this.TypeText = "restaurant?";
                    this.DescriptionText = "Deleting is a permanent action, you won’t be able to undo it.\r\nPlease make sure this is the restaurant you want to delete:";
                    this.confirmCommand = new DeleteEntityCommand(this, dbContex);
                    this.confirmCommandParameter = this.Item;
                    this.SuccessMessage = "Restaurant deleted successfully!";
                    break;
                case DialogType.GO_BACK_CRUD:
                    //this.Item = this.dbContex.Restaurants.First(c => c.Id == ApplicationHelper.ToDeleteId);
                    //this.Cards = new ObservableCollection<object>() { this.Item };
                    this.TitleText = "go back";
                    this.TitleStartText = "Are you sure you want to ";
                    this.TitleMiddleText = "";
                    this.ButtonText = "Go back to homepage";
                    this.TypeText = "to homepage?";
                    this.DescriptionText = "Going back is a permanent action, you won’t be able to undo it.\r\nInput values will be lost.";
                    this.confirmCommand = new BackToHomeCommand(null);
                    //this.confirmCommandParameter = this.Item;
                    //this.SuccessMessage = "Restaurant deleted successfully!";
                    break;
            }
        }

    }
}
