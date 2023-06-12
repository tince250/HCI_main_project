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
    public class NameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string inputValue = value as string;

                if (string.IsNullOrEmpty(inputValue)) {
                    return new ValidationResult(false, "Name field can not be empty!");
                }
                else if (inputValue.Trim().Length != inputValue.Length) { 
                    return new ValidationResult(false, "There should be no white spaces at the start or end!");
                } else if (!Regex.IsMatch(inputValue, "^[a-zA-Z0-9 ]+$")){
                    return new ValidationResult(false, "Invalid characters. Only letters and digits are allowed!");
                }
            } catch (Exception ex)
            {
                return new ValidationResult(false, "Name field is not valid!");
            }

            return ValidationResult.ValidResult;
        }
    }
}
