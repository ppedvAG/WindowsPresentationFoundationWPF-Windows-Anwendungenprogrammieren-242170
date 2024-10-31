using System.Globalization;
using System.Windows.Data;

namespace M012;

public class HobbiesUnpackConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		List<string> str = (List<string>) value;

		string gesamt = "";
		foreach (string s in str)
		{
			gesamt += s + ", ";
		}
		gesamt = gesamt.TrimEnd(',', ' ');
		return gesamt;

		//return string.Join(", ", str);
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}