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
    public class CityValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string inputValue = value as string;

                if (string.IsNullOrEmpty(inputValue))
                {
                    return new ValidationResult(false, "City field can not be empty!");
                }
                else if (inputValue.Trim().Length != inputValue.Length)
                {
                    return new ValidationResult(false, "There should be no white spaces at the start or end!");
                }
                else if (!Regex.IsMatch(inputValue, "^[a-zA-ZćčđšžČĆŽĐŠ ]+$"))
                {
                    return new ValidationResult(false, "Invalid characters. Only letters are allowed!");
                }
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, "City field is not valid!");
            }

            return ValidationResult.ValidResult;
        }
    }
}
