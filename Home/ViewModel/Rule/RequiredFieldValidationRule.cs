using System.Globalization;
using System.Windows.Controls;

namespace Home.ViewModel.Rule
{
    public class RequiredFieldValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(false, App.GetTranslatedText("RequiredField"));
            }

            return ValidationResult.ValidResult;
        }
    }
}
