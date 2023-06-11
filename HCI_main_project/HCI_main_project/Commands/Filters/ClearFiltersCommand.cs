using HCI_main_project.Models;
using HCI_main_project.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Commands
{
    public class ClearFiltersCommand : CommandBase
    {
        private HomepageViewModel homepageViewModel;

        public ClearFiltersCommand(HomepageViewModel homepageViewModel)
        {
            this.homepageViewModel = homepageViewModel;
        }
        public override void Execute(object? parameter)
        {
            ObservableCollection<object> Objects = this.homepageViewModel.Objects;

            if (this.homepageViewModel.SelectedType.Equals("tours"))
            {
                this.homepageViewModel.Objects = this.homepageViewModel.SortTours(this.homepageViewModel.SelectedOption, new ObservableCollection<object>(this.homepageViewModel.dbContext.Tours.ToList()));
                this.homepageViewModel.MinPrice = null;
                this.homepageViewModel.MaxPrice = null;
                this.homepageViewModel.DateFrom = null;
                this.homepageViewModel.DateTo = null;
            }
            else if (this.homepageViewModel.SelectedType.Equals("attractions"))
            {
                this.homepageViewModel.Objects = new ObservableCollection<object>(this.homepageViewModel.dbContext.Attractions.ToList());
                this.homepageViewModel.SelectedLocation = null;
            }
            else if (this.homepageViewModel.SelectedType.Equals("accommodation"))
            {
                this.homepageViewModel.Objects = new ObservableCollection<object>(this.homepageViewModel.dbContext.Accommodations.ToList());
                this.homepageViewModel.SelectedLocation = null;
            }
            else if (this.homepageViewModel.SelectedType.Equals("restaurants"))
            {
                this.homepageViewModel.Objects = new ObservableCollection<object>(this.homepageViewModel.dbContext.Restaurants.ToList());
                this.homepageViewModel.SelectedLocation = null;
            }
        }
    }
}
