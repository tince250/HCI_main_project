using HCI_main_project.Commands;
using HCI_main_project.Models;
using HCI_main_project.User_Controls;
using HCI_main_project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HCI_main_project.ViewModel
{
    public class TourCardViewModel : ViewModelBase
    {
        private HomepageViewModel homepageViewModel;

        private Tour tour;

        public Tour Tour
        {
            get { return tour; }
            set { tour = value; }
        }

        private string loggedUserRole;

        public string LoggedUserRole
        {
            get { return loggedUserRole; }
            set { loggedUserRole = value; }
        }


        public ICommand openTourDetailsCommand { get; }
        public ICommand openDeleteTourDialogCommand { get; }


        public TourCardViewModel(HomepageViewModel homepageViewModel, Tour tour)
        {
            this.homepageViewModel = homepageViewModel;
            this.Tour = tour;
            this.LoggedUserRole = ApplicationHelper.HomePageVm.LoggedUserRole;

            this.openTourDetailsCommand = new OpenTourDetailsCommand(homepageViewModel, Tour.Id);
            this.openDeleteTourDialogCommand = new OpenDeleteTourDialogCommand(Tour.Id);
        }

        
    }
}
