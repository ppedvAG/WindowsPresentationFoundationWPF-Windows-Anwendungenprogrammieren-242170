using System.Globalization;
using System.Windows.Controls;

namespace M000.Validation;

public class LengthValidation : ValidationRule
{
	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		string s = (string) value;
		if (s.Length < 3 || s.Length > 15)
			return new ValidationResult(false, "Die Eingabe darf nur zwischen 3 und 15 Buchstaben enthalten!");
		return ValidationResult.ValidResult;
	}
}