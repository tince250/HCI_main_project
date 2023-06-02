using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.ViewModels
{
    public class AddressFormViewModel : ViewModelBase
    {
        private string _street;
        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                OnPropertyChanged(nameof(Street));
            }
        }

        private string _streetNo;
        public string StreetNo
        {
            get { return _streetNo; }
            set
            {
                _streetNo = value;
                OnPropertyChanged(nameof(StreetNo));
            }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        public AddressFormViewModel(Restaurant selectedRestaurant)
        {
            FillFieldsWithPreviousData(selectedRestaurant);
        }

        private void FillFieldsWithPreviousData(Restaurant restaurant)
        {
            if (restaurant == null)
                return;
            City = restaurant.Address.City;
        }
    }
}
