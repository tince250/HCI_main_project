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

        private string _streetLabel;
        public string StreetLabel
        {
            get { return _streetLabel; }
            set
            {
                _streetLabel = value;
                OnPropertyChanged(nameof(StreetLabel));
            }
        }

        private string _streetNoLabel;
        public string StreetNoLabel
        {
            get { return _streetNoLabel; }
            set
            {
                _streetNoLabel = value;
                OnPropertyChanged(nameof(StreetNoLabel));
            }
        }

        private string _cityLabel;
        public string CityLabel
        {
            get { return _cityLabel; }
            set
            {
                _cityLabel = value;
                OnPropertyChanged(nameof(CityLabel));
            }
        }

        public void SetLabelContents(string type)
        {
            if (type == "Restaurant") {
                StreetLabel = "Restaurant street";
                StreetNoLabel = "Restaurant street number";
                CityLabel = "Restaurant city";
            }
            else if (type == "Attraction")
            {
                StreetLabel = "Attraction street";
                StreetNoLabel = "Attraction street number";
                CityLabel = "Attraction city";
            }
            else
            {
                StreetLabel = "Accommodation street";
                StreetNoLabel = "Accommodation street number";
                CityLabel = "Accommodation city";
            }
        }

        private TextBox _streetTextBox, _streetNoTextBox, _cityTextBox;
        public bool IsFormValid()
        {
            return !Validation.GetHasError(_streetTextBox) && Street != "" && Street != null
                && !Validation.GetHasError(_streetNoTextBox) && StreetNo != "" && StreetNo != null 
                && !Validation.GetHasError(_cityTextBox) && City != "" && City != null;
        }

        private object _objectForEdit;

        public AddressFormViewModel(object objectForEdit, TextBox streetTextBox, TextBox streetNoTextBox, TextBox cityTextBox)
        {
            _objectForEdit = objectForEdit;
            _streetTextBox = streetTextBox;
            _streetNoTextBox = streetNoTextBox; 
            _cityTextBox = cityTextBox;
            FillFieldsWithPreviousData();
        }

        private void FillFieldsWithPreviousData()
        {
            if (_objectForEdit == null)
                return;
            if (_objectForEdit is Restaurant)
            {
                City = ((Restaurant)_objectForEdit).Address.City;
                StreetNo = ((Restaurant)_objectForEdit).Address.StreetNumber.ToString();
                Street = ((Restaurant)_objectForEdit).Address.Street;
            } else if (_objectForEdit is Attraction)
            {
                City = ((Attraction)_objectForEdit).Address.City;
                StreetNo = ((Attraction)_objectForEdit).Address.StreetNumber.ToString();
                Street = ((Attraction)_objectForEdit).Address.Street;
            } else
            {
                City = ((Accommodation)_objectForEdit).Address.City;
                StreetNo = ((Accommodation)_objectForEdit).Address.StreetNumber.ToString();
                Street = ((Accommodation)_objectForEdit).Address.Street;
            }
            
        }
    }
}
