using HCI_main_project.Commands;
using HCI_main_project.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace HCI_main_project.ViewModel
{
    public class HomepageViewModel: ViewModelBase
    {
        private ObservableCollection<object> objects;
        public ObservableCollection<object> Objects
        {
            get { return objects; }
            set
            {
                objects = value;
                OnPropertyChanged(nameof(Objects));
            }
        }

        private TripagoContext dbContext;

        public ICommand navItemSelectedCommand { get; }

        public HomepageViewModel()
        {
            this.navItemSelectedCommand = new NavItemSelectedCommand(this);
            var app = (App)Application.Current;
            this.dbContext = app.serviceProvider.GetService<TripagoContext>();
            SetTours();
        }

        public void SetTours()
        {
            this.Objects = new ObservableCollection<object>(dbContext.Tours.ToList());
        }

        public void SetAttractions()
        {
            this.Objects = new ObservableCollection<object>(dbContext.Attractions.ToList());
        }

        public void SetAccommodation()
        {
            this.Objects = new ObservableCollection<object>(dbContext.Accommodations.ToList());
        }

        public void SetRestaurants()
        {
            this.Objects = new ObservableCollection<object>(dbContext.Restaurants.ToList());
        }

    }
}
