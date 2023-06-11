using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HCI_main_project.ViewModels
{
    public class TripDetailsControlViewModel : ViewModelBase
    {

        private bool _isDatePickerToFocused;

        public bool IsDatePickerToFocused
        {
            get { return _isDatePickerToFocused; }
            set
            {
                _isDatePickerToFocused = value;
                OnPropertyChanged(nameof(IsDatePickerToFocused));
            }
        }

        public void DatePickerTo_GotFocus(object sender, RoutedEventArgs e)
        {
            IsDatePickerToFocused = true;
        }

        public void DatePickerTo_LostFocus(object sender, RoutedEventArgs e)
        {
            IsDatePickerToFocused = false;
        }

        private bool _isDatePickerFromFocused;

        public bool IsDatePickerFromFocused
        {
            get { return _isDatePickerFromFocused; }
            set
            {
                _isDatePickerFromFocused = value;
                OnPropertyChanged(nameof(IsDatePickerFromFocused));
            }
        }

        public void DatePickerFrom_GotKeyboardFocus(object sender, RoutedEventArgs e)
        {
            IsDatePickerFromFocused = true;
        }

        public void DatePickerFrom_LostFocus(object sender, RoutedEventArgs e)
        {
            IsDatePickerFromFocused = false;
        }

        private double? _price;

        public double? Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private DateTime? dateFrom;

        public DateTime? DateFrom
        {
            get { return dateFrom; }
            set
            {
                dateFrom = value;
                ValidateDateRange();
                OnPropertyChanged(nameof(DateFrom));
            }
        }

        private DateTime? dateTo;

        public DateTime? DateTo
        {
            get { return dateTo; }
            set
            {
                dateTo = value;
                ValidateDateRange();
                OnPropertyChanged(nameof(DateTo));
            }
        }

        private TextBox _priceTextBox;
        private DatePicker _dateFrom, _dateTo;

        public bool IsFormValid()
        {
            return !Validation.GetHasError(_priceTextBox) && Price != 0 && Price != null
                && !Validation.GetHasError(_dateFrom) && DateFrom != null
                && !Validation.GetHasError(_dateTo) && DateTo != null;
        }

        public TripDetailsControlViewModel(TextBox priceTextBox, DatePicker dateFrom, DatePicker dateTo, Tour selectedTour = null)
        {
            _priceTextBox = priceTextBox;
            _dateFrom = dateFrom;
            _dateTo = dateTo;
            FillFieldsWithPreviousData(selectedTour);
        }

        private void FillFieldsWithPreviousData(Tour selectedTour)
        {
            if (selectedTour == null)
                return;
            Price = selectedTour.Price;
            DateFrom = selectedTour.From;
            DateTo = selectedTour.To;
        }

        private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        public bool HasErrors => errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void ValidateDateRange()
        {
            if (DateFrom > DateTo)
            {
                AddValidationError(nameof(DateFrom), "'Date from' cannot be greater than the 'Date to' field.");
            }
            else
            {
                RemoveValidationError(nameof(DateFrom));
            }
        }

        private void AddValidationError(string propertyName, string errorMessage)
        {
            if (!errors.ContainsKey(propertyName))
            {
                errors[propertyName] = new List<string>();
            }

            if (!errors[propertyName].Contains(errorMessage))
            {
                errors[propertyName].Add(errorMessage);
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        private void RemoveValidationError(string propertyName)
        {
            if (errors.ContainsKey(propertyName))
            {
                errors.Remove(propertyName);
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

    }
}
