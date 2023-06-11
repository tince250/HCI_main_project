using HCI_main_project.Models;
using HCI_main_project.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCI_main_project.Commands
{
    public class ApplyFiltersCommand : CommandBase
    {
        private HomepageViewModel homepageViewModel;

        public ApplyFiltersCommand(HomepageViewModel homepageViewModel)
        {
            this.homepageViewModel = homepageViewModel;
            this.homepageViewModel.PropertyChanged += ViewModel_PropertyChanged;
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

            var minPrice = this.homepageViewModel.MinPrice;
            var maxPrice = this.homepageViewModel.MaxPrice;

            if (this.homepageViewModel.MinPrice != null || this.homepageViewModel.MaxPrice != null)
            {
                applyPriceFilter = true;
                if (this.homepageViewModel.MinPrice == null)
                    minPrice = 0;
                else if (this.homepageViewModel.MaxPrice == null)
                    maxPrice = 100000;
            }

            var dateFrom = this.homepageViewModel.DateFrom;
            var dateTo = this.homepageViewModel.DateTo;

            if (this.homepageViewModel.DateFrom != null || this.homepageViewModel.DateTo != null)
            {
                applyDateFilter = true;
                if (this.homepageViewModel.DateFrom == null)
                    dateFrom = DateTime.Now;
                else if (this.homepageViewModel.DateTo == null)
                    dateTo = DateTime.MaxValue;
            }

            applyAllTourFiltersAndSort(applyPriceFilter, applyDateFilter, minPrice, maxPrice, dateFrom, dateTo);
        }

        private void applyAllTourFiltersAndSort(bool applyPriceFilter, bool applyDateFilter, double? minPrice, double? maxPrice, DateTime? dateFrom, DateTime? dateTo)
        {
            var objects = new ObservableCollection<object>();
            if (applyPriceFilter && !applyDateFilter)
            {
                objects = new ObservableCollection<object>(this.homepageViewModel.Objects.OfType<Tour>().Where(t => t.Price <= maxPrice && t.Price >= minPrice).ToList());
            }
            else if (!applyPriceFilter && applyDateFilter)
            {
                objects = new ObservableCollection<object>(this.homepageViewModel.Objects.OfType<Tour>().Where(t => t.From >= dateFrom && t.To <= dateTo).ToList());
            } else if (applyPriceFilter && applyDateFilter)
            {
                objects = new ObservableCollection<object>(this.homepageViewModel.Objects.OfType<Tour>().Where(t => (t.Price <= maxPrice && t.Price >= minPrice) && (t.From >= dateFrom && t.To <= dateTo)).ToList());
            }

            if (this.homepageViewModel.SearchText != "")
                objects = new ObservableCollection<object>(objects.OfType<Tour>().Where(t => t.Name.Contains(this.homepageViewModel.SearchText, StringComparison.OrdinalIgnoreCase)).ToList());
            
            if (this.homepageViewModel.SelectedOption != null)
            {
                objects = this.homepageViewModel.SortTours(this.homepageViewModel.SelectedOption, objects);
            }
            this.homepageViewModel.Objects = objects;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(homepageViewModel.MinPrice)
                || e.PropertyName == nameof(homepageViewModel.MaxPrice)
                || e.PropertyName == nameof(homepageViewModel.DateFrom)
                || e.PropertyName == nameof(homepageViewModel.DateTo)
                || e.PropertyName == nameof(homepageViewModel.SelectedType))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            if (homepageViewModel.SelectedType != null && homepageViewModel.SelectedType.Equals("tours"))
                return homepageViewModel.AreFiltersValid();
            else
                return true;
        }
    }
}
