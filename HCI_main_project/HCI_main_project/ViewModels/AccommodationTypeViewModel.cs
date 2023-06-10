using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.ViewModels
{
    public class AccommodationTypeViewModel : ViewModelBase
    {
        private bool _isHotelSelected;
        public bool IsHotelSelected
        {
            get { return _isHotelSelected; }
            set
            {
                _isHotelSelected = value;
                OnPropertyChanged(nameof(IsHotelSelected));
            }
        }

        private bool _isApartmentSelected;
        public bool IsApartmentSelected
        {
            get { return _isApartmentSelected; }
            set
            {
                _isApartmentSelected = value;
                OnPropertyChanged(nameof(IsApartmentSelected));
            }
        }

        public bool IsValid()
        {
            return IsApartmentSelected || IsHotelSelected;
        }

        public AccommodationTypeViewModel(Accommodation selectedAccommodation = null)
        {
            if (selectedAccommodation != null)
            {
                if (selectedAccommodation.Type == AccommodationType.HOTEL)
                    IsHotelSelected = true;
                else
                    IsApartmentSelected = true;
            }
        }

    }
}
