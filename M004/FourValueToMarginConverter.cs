using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace M004;

public class FourValueToMarginConverter : IMultiValueConverter
{
	//value ist hier ein Array (values)
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		//double[] d = new double[values.Length];
		//for (int i = 0; i < values.Length; i++)
		//{
		//	d[i] = (double) values[i];
		//}

		//OfType: Filterung nach einem Typen durchführen
		double[] d = values.OfType<double>().ToArray();
		return new Thickness(d[0], d[1], d[2], d[3]);
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}