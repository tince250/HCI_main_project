using HCI_main_project.Commands;
using HCI_main_project.Models;
using HCI_main_project.UserControls;
using System.Windows.Input;

namespace HCI_main_project.ViewModels
{
    public class AddRestaurantPageViewModel : ViewModelBase
    {
        public NameAndPhotoFormViewModel NameAndPhotoFormViewModel { get; set; }
        public AddressFormViewModel AddressFormViewModel { get; set; }

        private NameAndPhotoFormControl _nameAndPhotoFormControl;
        public NameAndPhotoFormControl NameAndPhotoFormControl
        {
            get { return _nameAndPhotoFormControl; }
            set
            {
                _nameAndPhotoFormControl = value;
                OnPropertyChanged(nameof(NameAndPhotoFormControl));
            }
        }

        private AddressFormControl _addressFormControl;
        public AddressFormControl AddressFormControl
        {
            get { return _addressFormControl; }
            set
            {
                _addressFormControl = value;
                OnPropertyChanged(nameof(AddressFormControl));
            }
        }

        private bool _isFillAddressButtonClicked;
        public bool IsFillAddressButtonClicked
        {
            get { return _isFillAddressButtonClicked; }
            set
            {
                _isFillAddressButtonClicked = value;
                OnPropertyChanged(nameof(IsFillAddressButtonClicked));
            }
        }

        private string _nextButtonText;

        public string NextButtonText
        {
            get { return _nextButtonText; }
            set
            {
                _nextButtonText = value;
                OnPropertyChanged(nameof(NextButtonText));
            }
        }

        public ICommand BackButtonRestaurantCommand { get; }
        public ICommand FillAddressButtonRestaurantCommand { get; }

        public ICommand AddRestaurantCommand { get;  }

        public AddRestaurantPageViewModel(NameAndPhotoFormControl nameAndPhotoFormControl, AddressFormControl addressFormControl, Restaurant selectedRestaurant = null)
        {
            _nameAndPhotoFormControl = nameAndPhotoFormControl;
            _addressFormControl = addressFormControl;
            NameAndPhotoFormViewModel = new NameAndPhotoFormViewModel(nameAndPhotoFormControl.imageRectangle, selectedRestaurant);
            AddressFormViewModel = new AddressFormViewModel(selectedRestaurant);
            NextButtonText = "Fill address";
            BackButtonRestaurantCommand = new BackButtonRestaurantCommand(this);
            FillAddressButtonRestaurantCommand = new FillAddressButtonRestaurantCommand(this);
            AddRestaurantCommand = new AddRestaurantCommand(this);
        }
    }
}
