using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_main_project.ValidationRules
{
    public class DateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {

                if (value == null || !(value is DateTime?))
                {
                    return ValidationResult.ValidResult;
                }

                DateTime? selectedDate = (DateTime?)value;

                // Check if the selectedDate is null or DateTime.MinValue
                if (!selectedDate.HasValue || selectedDate.Value == DateTime.MinValue)
                {
                    return ValidationResult.ValidResult;
                }

                if (selectedDate < DateTime.Now)
                {
                    return new ValidationResult(false, "You cannot browse past trips.");
                }
                }
                catch (Exception ex)
                {
                    return new ValidationResult(false, "Date field is not valid.");
                }

                return ValidationResult.ValidResult;
        }
    }
}
