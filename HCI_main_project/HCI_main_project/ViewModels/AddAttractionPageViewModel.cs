using HCI_main_project.Commands;
using HCI_main_project.Commands.Attractions;
using HCI_main_project.Models;
using HCI_main_project.UserControls;
using MaterialDesignThemes.Wpf;
using System.Windows.Input;

namespace HCI_main_project.ViewModels
{
    public class AddAttractionPageViewModel : ViewModelBase
    {
        public NameAndPhotoFormViewModel NameAndPhotoFormViewModel { get; set; }
        public AddressFormViewModel AddressFormViewModel { get; set; }
        public Attraction SelectedAttraction { get; }

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
        private Snackbar _snackBarPositive;
        private Snackbar _snackBarNegative;
        public void ShowPositiveSnackBar(string message)
        {
            _snackBarPositive.FontSize = 24;
            _snackBarPositive.MessageQueue.Enqueue(message);
        }

        public void ShowNegativeSnackBar(string message)
        {
            _snackBarPositive.FontSize = 24;
            _snackBarNegative.MessageQueue.Enqueue(message);
        }

        public ICommand BackButtonAttractionCommand { get; }
        public ICommand FillAddressButtonAttractionCommand { get; }
        public ICommand BackCommand { get; }

        public ICommand AddAttractionCommand { get; }
        public ICommand EditAttractionCommand { get; }
        public AddAttractionPageViewModel(NameAndPhotoFormControl nameAndPhotoFormControl, AddressFormControl addressFormControl, Snackbar snackBarPositive, Snackbar snackBarNegative, Attraction selectedAttraction = null)
        {
            _nameAndPhotoFormControl = nameAndPhotoFormControl;
            _addressFormControl = addressFormControl;
            NextButtonText = "Fill address info";
            SelectedAttraction = selectedAttraction;
            BackCommand = new BackToHomeCommand(null);

            IsPageForEdit = selectedAttraction == null ? false : true;

            _snackBarPositive = snackBarPositive;
            _snackBarNegative = snackBarNegative;

            NameAndPhotoFormViewModel = new NameAndPhotoFormViewModel(nameAndPhotoFormControl.imageRectangle, nameAndPhotoFormControl.nameTextBox, selectedAttraction);
            NameAndPhotoFormViewModel.SetLabelContents("Attraction");
            AddressFormViewModel = new AddressFormViewModel(selectedAttraction, addressFormControl.streetTextBox, addressFormControl.streetNoTextBox, addressFormControl.cityTextBox);
            AddressFormViewModel.SetLabelContents("Attraction");
            BackButtonAttractionCommand = new BackButtonAttractionCommand(this);
            FillAddressButtonAttractionCommand = new FillAddressButtonAttractionCommand(this);
            AddAttractionCommand = new AddAttractionCommand(this);
            EditAttractionCommand = new EditAttractionCommand(this);
        }
    }
}
