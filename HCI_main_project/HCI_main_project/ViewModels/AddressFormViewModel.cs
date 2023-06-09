using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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

        private TextBox _streetTextBox, _streetNoTextBox, _cityTextBox;
        public bool IsFormValid()
        {
            return !Validation.GetHasError(_streetTextBox) && Street != "" && Street != null
                && !Validation.GetHasError(_streetNoTextBox) && StreetNo != "" && StreetNo != null 
                && !Validation.GetHasError(_cityTextBox) && City != "" && City != null;
        }

        public AddressFormViewModel(Restaurant selectedRestaurant, TextBox streetTextBox, TextBox streetNoTextBox, TextBox cityTextBox)
        {
            FillFieldsWithPreviousData(selectedRestaurant);
            _streetTextBox = streetTextBox;
            _streetNoTextBox = streetNoTextBox; 
            _cityTextBox = cityTextBox;
        }

        private void FillFieldsWithPreviousData(Restaurant restaurant)
        {
            if (restaurant == null)
                return;
            City = restaurant.Address.City;
            StreetNo = restaurant.Address.StreetNumber.ToString();
            Street = restaurant.Address.Street;
        }
    }
}
