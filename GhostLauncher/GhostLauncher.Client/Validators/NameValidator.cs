using System.Globalization;
using System.Windows.Controls;

namespace GhostLauncher.Client.Validators
{
    public class NameValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Name must be filled in!");
            }
            return ValidationResult.ValidResult;
        }
    }
}
