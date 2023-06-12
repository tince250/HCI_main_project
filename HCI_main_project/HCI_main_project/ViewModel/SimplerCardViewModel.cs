using HCI_main_project.Commands;
using HCI_main_project.Commands.Homepages;
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
        public string EntityType
        {
            get { return entityType; }
            set
            {
                entityType = value;
                OnPropertyChanged(nameof(EntityType));
            }
        }

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

        private string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        public ICommand openDeleteEntityDialogCommand { get; }
        public ICommand AddRestaurantButtonCommand { get; }
        public ICommand AddAttractionsButtonCommand { get; }
        public ICommand AddAccommodationButtonCommand { get; }

        public SimplerCardViewModel(HomepageViewModel homePageVm, SimpleCardContent simpleCardContent, string type)
        {
            this.homePageVm = homePageVm;
            this.cardContent = simpleCardContent;
            this.entityType = type;
            this.LoggedUserRole = ApplicationHelper.HomePageVm.LoggedUserRole;
            EntityType = type;
            this.ImagePath = ApplicationHelper.ParseImagePath(cardContent.Image, entityType);

            AddRestaurantButtonCommand = new AddRestaurantButtonCommand(cardContent.Id);
            AddAttractionsButtonCommand = new AddAttractionsButtonCommand(cardContent.Id);
            AddAccommodationButtonCommand = new AddAccommodationButtonCommand(cardContent.Id);
            this.openDeleteEntityDialogCommand = new OpenDeleteSimplerDialogCommand(this.CardContent.Id, this.entityType);
        }

    }
}
