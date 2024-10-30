using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace M000.Converter;

public class FourValueToBrushConverter : IMultiValueConverter
{
	//Input: 4 doubles (Slider)
	//Output: Brush
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		//objects -> doubles
		double[] d = new double[values.Length];
		for (int i = 0; i < values.Length; i++)
		{
			d[i] = (double) values[i];
		}

		//doubles -> bytes
		byte[] b = new byte[values.Length];
		for (int i = 0; i < values.Length; i++)
		{
			b[i] = (byte) d[i];
		}

		//bytes -> Color
		Color c = Color.FromArgb(b[3], b[0], b[1], b[2]);
		return new SolidColorBrush(c);

		///////////////////////////////////////////////////////
		
		//byte[] bytes = values.OfType<double>().Select(e => (byte) e).ToArray();
		//return new SolidColorBrush(Color.FromArgb(bytes[3], bytes[0], bytes[1], bytes[2]));
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}