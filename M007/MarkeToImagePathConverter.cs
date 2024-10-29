using System.Globalization;
using System.Windows.Data;

namespace M007;

public class MarkeToImagePathConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		FahrzeugMarke marke = (FahrzeugMarke)value;
		switch (marke)
		{
			case FahrzeugMarke.Audi: return @"C:\Users\lk3\source\repos\WPF_2024_10_28\M007\Images\audi.png";
			case FahrzeugMarke.BMW: return @"C:\Users\lk3\source\repos\WPF_2024_10_28\M007\Images\bmw.png";
			case FahrzeugMarke.VW: return @"C:\Users\lk3\source\repos\WPF_2024_10_28\M007\Images\vw.png";
			default: return "";
		}
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}