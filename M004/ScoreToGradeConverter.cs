using System.Globalization;
using System.Windows.Data;

namespace M004;

public class ScoreToGradeConverter : IValueConverter
{
	/// <summary>
	/// Quelle -> Ziel
	/// Slider -> TextBlock
	/// Value -> Text
	/// double -> string
	/// </summary>
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		double d = (double) value;
		switch (d)
		{
			case >= 90: return "Sehr Gut";
			case >= 80: return "Gut";
			case >= 70: return "Befriedigend";
			case >= 60: return "Ausreichend";
			case >= 50: return "Mangelhaft";
			default: return "Ungenügend";
		}
	}

	/// <summary>
	/// Ziel -> Quelle
	/// TextBlock -> Slider
	/// Text -> Value
	/// string -> double
	/// 
	/// (wird hier nicht benötigt)
	/// </summary>
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}