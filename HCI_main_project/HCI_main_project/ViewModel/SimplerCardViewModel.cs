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

        public SimplerCardViewModel(HomepageViewModel homePageVm, SimpleCardContent simpleCardContent, string type)
        {
            this.homePageVm = homePageVm;
            this.cardContent = simpleCardContent;
            this.entityType = type;
            this.ImagePath = ApplicationHelper.ParseImagePath(cardContent.Image, entityType);

            this.openDeleteEntityDialogCommand = new OpenDeleteSimplerDialogCommand(this.CardContent.Id, this.entityType);
        }

    }
}
