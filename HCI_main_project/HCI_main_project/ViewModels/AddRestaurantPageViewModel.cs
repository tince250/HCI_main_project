using HCI_main_project.Commands;
using HCI_main_project.Models;
using HCI_main_project.UserControls;
using MaterialDesignThemes.Wpf;
using System.Windows.Input;

namespace HCI_main_project.ViewModels
{
    public class AddRestaurantPageViewModel : ViewModelBase
    {
        public NameAndPhotoFormViewModel NameAndPhotoFormViewModel { get; set; }
        public AddressFormViewModel AddressFormViewModel { get; set; }

        private Snackbar _snackBarPositive;
        private Snackbar _snackBarNegative;

        public Restaurant SelectedRestaurant { get; }

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

        private bool _isPageForEdit;
        public bool IsPageForEdit
        {
            get { return _isPageForEdit; }
            set
            {
                _isPageForEdit = value;
                OnPropertyChanged(nameof(IsPageForEdit));
            }
        }

        public void ShowPositiveSnackBar()
        {
            _snackBarPositive.FontSize = 24;
            _snackBarPositive.MessageQueue.Enqueue("You have successfully created restaurant!");
        }

        public void ShowNegativeSnackBar(string message)
        {
            _snackBarPositive.FontSize = 24;
            _snackBarNegative.MessageQueue.Enqueue(message);
        }

        public ICommand BackButtonRestaurantCommand { get; }
        public ICommand FillAddressButtonRestaurantCommand { get; }

        public ICommand AddRestaurantCommand { get;  }
        public ICommand EditRestaurantCommand { get;  }
        public AddRestaurantPageViewModel(NameAndPhotoFormControl nameAndPhotoFormControl, AddressFormControl addressFormControl, Snackbar snackBarPositive, Snackbar snackBarNegative, Restaurant selectedRestaurant = null)
        {
            _nameAndPhotoFormControl = nameAndPhotoFormControl;
            _addressFormControl = addressFormControl;
            _snackBarPositive = snackBarPositive;
            _snackBarNegative = snackBarNegative;
            NextButtonText = "Fill address info";
            SelectedRestaurant = selectedRestaurant;

            IsPageForEdit = selectedRestaurant == null ? false : true;

            NameAndPhotoFormViewModel = new NameAndPhotoFormViewModel(nameAndPhotoFormControl.imageRectangle, nameAndPhotoFormControl.nameTextBox, selectedRestaurant);
            NameAndPhotoFormViewModel.SetLabelContents("Restaurant");
            AddressFormViewModel = new AddressFormViewModel(selectedRestaurant, addressFormControl.streetTextBox, addressFormControl.streetNoTextBox, addressFormControl.cityTextBox);
            AddressFormViewModel.SetLabelContents("Restaurant");
            BackButtonRestaurantCommand = new BackButtonRestaurantCommand(this);
            FillAddressButtonRestaurantCommand = new FillAddressButtonRestaurantCommand(this);
            AddRestaurantCommand = new AddRestaurantCommand(this);
            EditRestaurantCommand = new EditRestaurantCommand(this);
        }
    }
}
