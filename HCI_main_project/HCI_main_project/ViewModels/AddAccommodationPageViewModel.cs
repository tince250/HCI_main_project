using HCI_main_project.Commands;
using HCI_main_project.Commands.Accommodations;
using HCI_main_project.Models;
using HCI_main_project.UserControls;
using MaterialDesignThemes.Wpf;
using System.Windows.Input;

namespace HCI_main_project.ViewModels
{
    public class AddAccommodationPageViewModel : ViewModelBase
    {
        public NameAndPhotoFormViewModel NameAndPhotoFormViewModel { get; set; }
        public AddressFormViewModel AddressFormViewModel { get; set; }
        public AccommodationTypeViewModel AccommodationTypeViewModel { get; set; }
       
        public Accommodation SelectedAccommodation { get; }

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

        public AccommodationTypeControl _accommodationTypeControl;
        public AccommodationTypeControl AccommodationTypeControl
        {
            get { return _accommodationTypeControl; }
            set
            {
                _accommodationTypeControl = value;
                OnPropertyChanged(nameof(AccommodationTypeControl));
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

        private bool _isFillGeneralInfoButtonClicked;
        public bool IsFillGeneralInfoButtonClicked
        {
            get { return _isFillGeneralInfoButtonClicked; }
            set
            {
                _isFillGeneralInfoButtonClicked = value;
                OnPropertyChanged(nameof(IsFillGeneralInfoButtonClicked));
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

        private string _backButtonText;
        public string BackButtonText
        {
            get { return _backButtonText; }
            set
            {
                _backButtonText = value;
                OnPropertyChanged(nameof(BackButtonText));
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

        public ICommand BackButtonAccommodationCommand { get; }
        public ICommand FillAddressButtonAccommodationCommand { get; }
        public ICommand FillGeneralInfoButtonAccommodationCommand { get; }

        public ICommand BackToGeneralInfoButtonAccommodationCommand { get; }
        public ICommand BackToAccommodationTypeButtonAccommodationCommand { get; }

        public ICommand AddAccommodationCommand { get; }
        public ICommand EditAccommodationCommand { get; }
        public AddAccommodationPageViewModel(AccommodationTypeControl accommodationTypeControl,NameAndPhotoFormControl nameAndPhotoFormControl, AddressFormControl addressFormControl, Accommodation selectedAccommodation = null)
        {
            _nameAndPhotoFormControl = nameAndPhotoFormControl;
            _addressFormControl = addressFormControl;
            _accommodationTypeControl = accommodationTypeControl;
            NextButtonText = "Fill general info";
            SelectedAccommodation = selectedAccommodation;

            IsPageForEdit = selectedAccommodation == null ? false : true;

            NameAndPhotoFormViewModel = new NameAndPhotoFormViewModel(nameAndPhotoFormControl.imageRectangle, nameAndPhotoFormControl.nameTextBox, selectedAccommodation);
            NameAndPhotoFormViewModel.SetLabelContents("Accommodation");

            AddressFormViewModel = new AddressFormViewModel(selectedAccommodation, addressFormControl.streetTextBox, addressFormControl.streetNoTextBox, addressFormControl.cityTextBox);
            AddressFormViewModel.SetLabelContents("Accommodation");

            AccommodationTypeViewModel = new AccommodationTypeViewModel(selectedAccommodation);

            FillGeneralInfoButtonAccommodationCommand = new FillGeneralInfoButtonAccommodationCommand(this);
            FillAddressButtonAccommodationCommand = new FillAddressButtonAccommodationCommand(this);
            BackToGeneralInfoButtonAccommodationCommand = new BackToGeneralInfoButtonAccommodationCommand(this);
            BackToAccommodationTypeButtonAccommodationCommand = new BackToAccommodationTypeButtonAccommodationCommand(this);
            //BackButtonAccommodationCommand = new BackButtonAccommodationCommand(this);
            //FillAddressButtonAccommodationCommand = new FillAddressButtonAccommodationCommand(this);
            AddAccommodationCommand = new AddAccommodationCommand(this);
            EditAccommodationCommand = new EditAccommodationCommand(this);
        }
    }
}
