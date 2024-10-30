using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace M011;

public partial class ColorSlider : UserControl
{
	public string Text
	{
		get => (string) GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

	public static readonly DependencyProperty TextProperty =
		DependencyProperty.Register
		(
			nameof(Text), //Name des Properties hinter dem DependencyProperty
			typeof(string), //Typ des Properties
			typeof(ColorSlider), //Typ, welcher das DependencyProperty enthält
			new PropertyMetadata("") //Konfigurieren des DependencyProperty (u.a. Standardwert) 
		);

	////////////////////////////////////////////////////////////////////////

	public Brush TextColor
	{
		get => (Brush) GetValue(TextColorProperty);
		set => SetValue(TextColorProperty, value);
	}

	public static readonly DependencyProperty TextColorProperty =
		DependencyProperty.Register
		(
			nameof(TextColor),
			typeof(Brush),
			typeof(ColorSlider),
			new PropertyMetadata(new SolidColorBrush(Colors.Black))
		);

	////////////////////////////////////////////////////////////////////////

	public double SliderValue
	{
		get => (double) GetValue(SliderValueProperty);
		set => SetValue(SliderValueProperty, value);
	}

	public static readonly DependencyProperty SliderValueProperty =
		DependencyProperty.Register
		(
			nameof(SliderValue),
			typeof(double),
			typeof(ColorSlider),
			new PropertyMetadata(0d)
		);

	public ColorSlider() => InitializeComponent();
}