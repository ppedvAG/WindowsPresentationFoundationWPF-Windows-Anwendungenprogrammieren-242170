using System.Globalization;
using System.Windows.Controls;

namespace M000.Validation;

public class LetterValidation : ValidationRule
{
	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		string s = (string)value;
		if (!s.All(char.IsLetter))
			return new ValidationResult(false, "Die Eingabe darf nur Buchstaben enthalten!");
		return ValidationResult.ValidResult;
	}
}