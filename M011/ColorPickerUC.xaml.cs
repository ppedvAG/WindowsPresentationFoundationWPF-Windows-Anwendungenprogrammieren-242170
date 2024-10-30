using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace M011;

public partial class ColorPickerUC : UserControl
{
	public Color PickedColor
	{
		get => (Color) GetValue(PickedColorProperty);
		set => SetValue(PickedColorProperty, value);
	}

	public static readonly DependencyProperty PickedColorProperty =
		DependencyProperty.Register
		(
			nameof(PickedColor),
			typeof(Color),
			typeof(ColorPickerUC),
			new PropertyMetadata(Color.FromArgb(0, 0, 0, 0), PickedColorChanged)
		);

	/////////////////////////////////////////////////////////////////

	public double RSliderValue
	{
		get => (double) GetValue(RSliderValueProperty);
		set => SetValue(RSliderValueProperty, value);
	}

	public static readonly DependencyProperty RSliderValueProperty =
		DependencyProperty.Register
		(
			nameof(RSliderValue),
			typeof(double),
			typeof(ColorPickerUC),
			new PropertyMetadata(0d, SliderValueChanged)
		);

	/////////////////////////////////////////////////////////////////

	public double GSliderValue
	{
		get => (double) GetValue(GSliderValueProperty);
		set => SetValue(GSliderValueProperty, value);
	}

	public static readonly DependencyProperty GSliderValueProperty =
		DependencyProperty.Register
		(
			nameof(GSliderValue),
			typeof(double),
			typeof(ColorPickerUC),
			new PropertyMetadata(0d, SliderValueChanged)
		);

	/////////////////////////////////////////////////////////////////

	public double BSliderValue
	{
		get => (double) GetValue(BSliderValueProperty);
		set => SetValue(BSliderValueProperty, value);
	}

	public static readonly DependencyProperty BSliderValueProperty =
		DependencyProperty.Register
		(
			nameof(BSliderValue),
			typeof(double),
			typeof(ColorPickerUC),
			new PropertyMetadata(0d, SliderValueChanged)
		);

	/////////////////////////////////////////////////////////////////

	public double ASliderValue
	{
		get => (double) GetValue(ASliderValueProperty);
		set => SetValue(ASliderValueProperty, value);
	}

	public static readonly DependencyProperty ASliderValueProperty =
		DependencyProperty.Register
		(
			nameof(ASliderValue),
			typeof(double),
			typeof(ColorPickerUC),
			new PropertyMetadata(255d, SliderValueChanged)
		);

	//Wenn sich einer der Slider verändert, muss die Gesamtfarbe neu berechnet werden
	//Diese Methode wird bei jedem Slider angehängt und ausgeführt, wenn sich der Slider verändert
	public static void SliderValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//Die 4 einzelnen Sliderwerte holen
		double r = (double) d.GetValue(RSliderValueProperty);
		double g = (double) d.GetValue(GSliderValueProperty);
		double b = (double) d.GetValue(BSliderValueProperty);
		double a = (double) d.GetValue(ASliderValueProperty);
		
		//Gesamtfarbe berechnen
		Color c = Color.FromArgb((byte) a, (byte) r, (byte) g, (byte) b);

		Color current = (Color) d.GetValue(PickedColorProperty);

		//Gesamtfarbe in PickedColor schreiben
		if (c != current)
			d.SetValue(PickedColorProperty, c);
	}

	//Wenn eine Gesamtfarbe per Binding kommt, müssen die Slider angepasst werden
	//Diese Methode wird bei PickedColorProperty angehängt, und ausgeführt wenn sich die Farbe allgemein verändert (z.B. über Binding)
	public static void PickedColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//Die Farbe holen
		Color c = (Color) e.NewValue;

		double r = (double) d.GetValue(RSliderValueProperty);
		double g = (double) d.GetValue(GSliderValueProperty);
		double b = (double) d.GetValue(BSliderValueProperty);
		double a = (double) d.GetValue(ASliderValueProperty);

		//Die einzelnen Farbteile in die Slider schreiben
		if (r != c.R)
			d.SetValue(RSliderValueProperty, (double) c.R);
		if (g != c.G)
			d.SetValue(GSliderValueProperty, (double) c.G);
		if (b != c.B)
			d.SetValue(BSliderValueProperty, (double) c.B);
		if (a != c.A)
			d.SetValue(ASliderValueProperty, (double) c.A);
	}

	public ColorPickerUC()
	{
		InitializeComponent();
	}
}