using HCI_main_project.ViewModel;
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
    public class PriceValidationRule : ValidationRule
    {
        public HomepageViewModel homepageViewModel { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                if (value is string stringRep)
                {     

                    if (string.IsNullOrEmpty(stringRep))
                    {
                        //this.homepageViewModel.PriceHasCustomErrors = false;
                        return ValidationResult.ValidResult;

                    }

                    if (!Regex.IsMatch(stringRep, "^(0|([1-9][0-9]*))(\\.[0-9]+)?$"))
                    {
                        return new ValidationResult(false, "Invalid characters. Only number formats are allowed!");
                        //this.homepageViewModel.PriceHasCustomErrors = true;
                    }

                    double inputValue = Double.Parse(stringRep);

                    if (inputValue < 0 || inputValue > 10000)
                    {
                        return new ValidationResult(false, "Price field can't be less than 0 or greater than 10.000!");
                        //this.homepageViewModel.PriceHasCustomErrors = true;
                    }
                }
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
                //this.homepageViewModel.PriceHasCustomErrors = true;
            }

            //this.homepageViewModel.PriceHasCustomErrors = false;

            return ValidationResult.ValidResult;
        }
    }
}
