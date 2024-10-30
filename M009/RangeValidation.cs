using System.Globalization;
using System.Windows.Controls;

namespace M009;

public class RangeValidation : ValidationRule
{
	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		string s = (string) value;
		if (!int.TryParse(s, out int x))
			return new ValidationResult(false, "Die Eingabe muss eine Zahl sein!"); //Fehler 1

		if (x < 0 || x > 100)
			return new ValidationResult(false, "Die Zahl muss zwischen 0 und 100 liegen!"); //Fehler 2

		return ValidationResult.ValidResult; //Alles OK
	}
}