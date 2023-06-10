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
    public class ApplyFiltersCommand : CommandBase
    {
        private HomepageViewModel homepageViewModel;

        public ApplyFiltersCommand(HomepageViewModel homepageViewModel)
        {
            this.homepageViewModel = homepageViewModel;
        }

        public override void Execute(object? parameter)
        {

            

            if (this.homepageViewModel.SelectedType.Equals("tours"))
                applyTourFilters();
            else
                applyAddressFilters();

        }

        private void applyAddressFilters()
        {
            string chosenCity = this.homepageViewModel.SelectedLocation;

            if (chosenCity == null)
            {
                return;
            }

            ObservableCollection<object> Objects = this.homepageViewModel.Objects;

            if (chosenCity.Contains("All"))
            {
                selectAll();
                return;
            }

            if (this.homepageViewModel.SelectedType.Equals("attractions"))
            {
                this.homepageViewModel.Objects = new ObservableCollection<object>(this.homepageViewModel.Objects.OfType<Attraction>().Where(a => a.Address.City.Equals(chosenCity)).ToList());
            }
            else if (this.homepageViewModel.SelectedType.Equals("accommodation"))
            {
                this.homepageViewModel.Objects = new ObservableCollection<object>(this.homepageViewModel.Objects.OfType<Accommodation>().Where(a => a.Address.City.Equals(chosenCity)).ToList());
            }
            else if (this.homepageViewModel.SelectedType.Equals("restaurants"))
            {
                this.homepageViewModel.Objects = new ObservableCollection<object>(this.homepageViewModel.Objects.OfType<Restaurant>().Where(r => r.Address.City.Equals(chosenCity)).ToList());
            }
        }

        private void selectAll()
        {
            if (this.homepageViewModel.SelectedType.Equals("attractions"))
            {
                this.homepageViewModel.Objects = new ObservableCollection<object>(this.homepageViewModel.dbContext.Attractions.ToList());
            }
            else if (this.homepageViewModel.SelectedType.Equals("accommodation"))
            {
                this.homepageViewModel.Objects = new ObservableCollection<object>(this.homepageViewModel.dbContext.Accommodations.ToList());
            }
            else if (this.homepageViewModel.SelectedType.Equals("restaurants"))
            {
                this.homepageViewModel.Objects = new ObservableCollection<object>(this.homepageViewModel.dbContext.Restaurants.ToList());
            }
        }

        private void applyTourFilters()
        {
            bool applyPriceFilter = false;
            bool applyDateFilter = false;

            if (this.homepageViewModel.MinPrice != null && this.homepageViewModel.MaxPrice != null)
            {
                applyPriceFilter = true;
            }

            if (this.homepageViewModel.DateFrom != null && this.homepageViewModel.DateTo != null)
            {
                applyDateFilter = true;
            }

            if (applyPriceFilter && !applyDateFilter)
            {
                this.homepageViewModel.Objects = new ObservableCollection<object>(this.homepageViewModel.Objects.OfType<Tour>().Where(t => t.Price <= this.homepageViewModel.MaxPrice && t.Price >= this.homepageViewModel.MinPrice).ToList());
            }

            if (!applyPriceFilter && applyDateFilter)
            {
                this.homepageViewModel.Objects = new ObservableCollection<object>(this.homepageViewModel.Objects.OfType<Tour>().Where(t => t.From >= this.homepageViewModel.DateFrom && t.To <= this.homepageViewModel.DateTo).ToList());

            }

            if (applyPriceFilter && applyDateFilter)
            {
                this.homepageViewModel.Objects = new ObservableCollection<object>(this.homepageViewModel.Objects.OfType<Tour>().Where(t => (t.Price <= this.homepageViewModel.MaxPrice && t.Price >= this.homepageViewModel.MinPrice) && (t.From >= this.homepageViewModel.DateFrom && t.To <= this.homepageViewModel.DateTo)).ToList());

            }
        }
    }
}
