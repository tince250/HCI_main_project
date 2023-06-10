using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace HCI_main_project.ValidationRules
{
    public class StreetNumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string streetNumber = value as string;

                if (string.IsNullOrEmpty(streetNumber))
                {
                    return new ValidationResult(false, "Street number field can not be empty!");
                }

                if (!int.TryParse(streetNumber, out int numericStreetNumber))
                {
                    return new ValidationResult(false, "Invalid characters. Only digits are allowed!");
                }

                if (numericStreetNumber < 1 || numericStreetNumber > 500)
                {
                    return new ValidationResult(false, "Street number must be between 1 and 500!");
                }

                if (streetNumber.Length < 1 || streetNumber.Length > 10)
                {

                }

                if (numericStreetNumber <= 0)
                {
                    return new ValidationResult(false, "Street number can not be less or equal to zero!");
                }

                if (!Regex.IsMatch(streetNumber, @"^[0-9]+$"))
                {
                    return new ValidationResult(false, "Invalid characters. Only digits are allowed!");
                }
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, "Street number field is not valid!");
            }

            return ValidationResult.ValidResult;
        }
    }
}
