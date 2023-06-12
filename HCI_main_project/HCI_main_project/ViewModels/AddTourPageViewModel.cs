using HCI_main_project.Commands;
using HCI_main_project.Commands.Tours;
using HCI_main_project.Models;
using HCI_main_project.UserControls;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;

namespace HCI_main_project.ViewModels
{
    public class AddTourPageViewModel : ViewModelBase
    {
        public NameAndPhotoFormViewModel NameAndPhotoFormViewModel { get; set; }
        public AddressFormViewModel AddressFormViewModel { get; set; }
        public TripDetailsControlViewModel TripDetailsControlViewModel { get; set; }

        public Tour SelectedTour { get; }

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

        private TripDetailsControl _tripDetailsControl;
        public TripDetailsControl TripDetailsControl
        {
            get { return _tripDetailsControl; }
            set
            {
                _tripDetailsControl = value;
                OnPropertyChanged(nameof(TripDetailsControl));
            }
        }

        private AttractionsDragAndDropControl _attractionsDragAndDropControl;
        public AttractionsDragAndDropControl AttractionsDragAndDropControl
        {
            get { return _attractionsDragAndDropControl; }
            set
            {
                _attractionsDragAndDropControl = value;
                OnPropertyChanged(nameof(AttractionsDragAndDropControl));
            }
        }

        private AccommodationsDragAndDropControl _accommodationsDragAndDropControl;
        public AccommodationsDragAndDropControl AccommodationsDragAndDropControl
        {
            get { return _accommodationsDragAndDropControl; }
            set
            {
                _accommodationsDragAndDropControl = value;
                OnPropertyChanged(nameof(AccommodationsDragAndDropControl));
            }
        }

        private RestaurantsDragAndDropControl _restaurantsDragAndDropControl;
        public RestaurantsDragAndDropControl RestaurantsDragAndDropControl
        {
            get { return _restaurantsDragAndDropControl; }
            set
            {
                _restaurantsDragAndDropControl = value;
                OnPropertyChanged(nameof(RestaurantsDragAndDropControl));
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

        private bool _isFillDetailsButtonClicked;
        public bool IsFillDetailsButtonClicked
        {
            get { return _isFillDetailsButtonClicked; }
            set
            {
                _isFillDetailsButtonClicked = value;
                OnPropertyChanged(nameof(IsFillDetailsButtonClicked));
            }
        }

        private bool _isFillAttractionsButtonClicked;
        public bool IsFillAttractionsButtonClicked
        {
            get { return _isFillAttractionsButtonClicked; }
            set
            {
                _isFillAttractionsButtonClicked = value;
                OnPropertyChanged(nameof(IsFillAttractionsButtonClicked));
            }
        }

        private bool _isFillAccommodationsButtonClicked;
        public bool IsFillAccommodationsButtonClicked
        {
            get { return _isFillAccommodationsButtonClicked; }
            set
            {
                _isFillAccommodationsButtonClicked = value;
                OnPropertyChanged(nameof(IsFillAccommodationsButtonClicked));
            }
        }

        private bool _isFillRestaurantsButtonClicked;
        public bool IsFillRestaurantsButtonClicked
        {
            get { return _isFillRestaurantsButtonClicked; }
            set
            {
                _isFillRestaurantsButtonClicked = value;
                OnPropertyChanged(nameof(IsFillRestaurantsButtonClicked));
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

        public ICommand BackToGeneralInfoButtonTourCommand { get; }
        /*public ICommand BackToDetailsButtonTourCommand { get; }
        public ICommand BackToAttractionsButtonTourCommand { get; }
        public ICommand BackToAccommodationsButtonTourCommand { get; }*/

        public ICommand FillDetailsButtonTourCommand { get; }
        public ICommand FillAttractionsButtonTourCommand { get; }
        public ICommand FillAccommodationsButtonTourCommand { get; }
        public ICommand FillRestaurantsButtonTourCommand { get; }

        public ICommand AddTourCommand { get; }
        public ICommand EditTourCommand { get; }
        public AddTourPageViewModel(NameAndPhotoFormControl nameAndPhotoFormControl, TripDetailsControl tripDetailsControl,
            AttractionsDragAndDropControl attractionsDragAndDropControl,
            AccommodationsDragAndDropControl accommodationsDragAndDropControl,
            RestaurantsDragAndDropControl  restaurantsDragAndDropControl,
            Snackbar snackBarPositive, Snackbar snackBarNegative,
            Tour selectedTour=null)
        {
            NameAndPhotoFormControl = nameAndPhotoFormControl;
            TripDetailsControl = tripDetailsControl;
            AccommodationsDragAndDropControl = accommodationsDragAndDropControl;
            AttractionsDragAndDropControl = attractionsDragAndDropControl;
            RestaurantsDragAndDropControl = restaurantsDragAndDropControl;
            IsPageForEdit = selectedTour == null ? false : true;
            SelectedTour = selectedTour;

            _snackBarPositive = snackBarPositive;
            _snackBarNegative = snackBarNegative;

            FillFieldsWithPreviousData(selectedTour);

            NameAndPhotoFormViewModel = new NameAndPhotoFormViewModel(nameAndPhotoFormControl.imageRectangle, nameAndPhotoFormControl.nameTextBox, selectedTour);
            NameAndPhotoFormViewModel.SetLabelContents("Tour");
            TripDetailsControlViewModel = new TripDetailsControlViewModel(tripDetailsControl.priceTextBox, tripDetailsControl.dateFrom, tripDetailsControl.dateTo, tripDetailsControl.descriptionTextArea, selectedTour);
            BackToGeneralInfoButtonTourCommand = new BackToGeneralInfoButtonTourCommand(this);
            FillDetailsButtonTourCommand = new FillDetailsButtonTourCommand(this);
            AddTourCommand = new AddTourCommand(this);
            EditTourCommand = new EditTourCommand(this);
            NextButtonText = "Fill details info";
            FillAttractionsButtonTourCommand = new FillAttractionsButtonTourCommand(this);
            FillAccommodationsButtonTourCommand = new FillAccommodationsButtonTourCommand(this);
            FillRestaurantsButtonTourCommand = new FillRestaurantsButtonTourCommand(this);
            IsFillGeneralInfoButtonClicked = true;
        }

        private void FillFieldsWithPreviousData(Tour selectedTour)
        {
            if (selectedTour == null)
            {
                AccommodationsDragAndDropControl.loadFromDb();
                AttractionsDragAndDropControl.loadFromDb();
                RestaurantsDragAndDropControl.loadFromDb();
            }
            else
            {
                AccommodationsDragAndDropControl.loadForEdit(selectedTour.TourAccommodations.Select(ta => ta.Accommodation).ToList());
                AttractionsDragAndDropControl.loadForEdit(selectedTour.TourAttractions.Select(ta => ta.Attraction).ToList());
                RestaurantsDragAndDropControl.loadForEdit(selectedTour.TourRestaurants.Select(ta => ta.Restaurant).ToList());
            }
        }



    }
}
