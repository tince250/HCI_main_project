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

                if (streetNumber.Length < 1 || streetNumber.Length > 10)
                {

                }

                if (!Regex.IsMatch(streetNumber, @"^[0-9,/-a-zA-Z]+$"))
                {
                    return new ValidationResult(false, "Invalid characters. Digits and letters are allowed!");
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
