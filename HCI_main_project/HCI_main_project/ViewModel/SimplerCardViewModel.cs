using HCI_main_project.Commands;
using HCI_main_project.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCI_main_project.ViewModel
{

    internal class SimplerCardViewModel : ViewModelBase
    {
        private SimpleCardContent cardContent;
        private HomepageViewModel homePageVm;
        private string entityType;

        private string loggedUserRole;

        public string LoggedUserRole
        {
            get { return loggedUserRole; }
            set { loggedUserRole = value; }
        }


        public SimpleCardContent CardContent
        {
            get { return cardContent; }
            set { 
                cardContent = value;
                OnPropertyChanged(nameof(CardContent));
            }
        }

        public ICommand openDeleteEntityDialogCommand { get; }

        public SimplerCardViewModel(HomepageViewModel homePageVm, SimpleCardContent simpleCardContent, string type)
        {
            this.homePageVm = homePageVm;
            this.cardContent = simpleCardContent;
            this.entityType = type;
            this.LoggedUserRole = ApplicationHelper.HomePageVm.LoggedUserRole;

            this.openDeleteEntityDialogCommand = new OpenDeleteSimplerDialogCommand(this.CardContent.Id, this.entityType);
        }

    }
}
