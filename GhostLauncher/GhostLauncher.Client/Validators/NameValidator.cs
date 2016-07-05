using System.Globalization;
using System.Windows.Controls;

namespace GhostLauncher.Client.Validators
{
    public class NameValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return value == null ? new ValidationResult(false, "Name must be filled in!") : ValidationResult.ValidResult;
        }
    }
}
