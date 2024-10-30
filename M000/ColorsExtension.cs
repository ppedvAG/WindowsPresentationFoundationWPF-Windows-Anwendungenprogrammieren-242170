using System.Reflection;
using System.Windows.Markup;
using System.Windows.Media;

namespace M000;

public class ColorsExtension : MarkupExtension
{
	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		Type c = typeof(Colors); //Typ der Colors Klasse entnehmen
		PropertyInfo[] p = c.GetProperties(); //Array mit allen Properties der Klasse erzeugen

		//Color[] colors = new Color[p.Length];
		//for (int i = 0; i < p.Length; i++)
		//{
		//	colors[i] = (Color) p[i].GetValue(null); //Aus dem jetztigen Property die Farbe entnehmen
		//}

		//SolidColorBrush[] brushes = new SolidColorBrush[colors.Length];
		//for (int i = 0; i < colors.Length; i++)
		//{
		//	brushes[i] = new SolidColorBrush(colors[i]);
		//}

		NamedColor[] nc = new NamedColor[p.Length];
		for (int i = 0; i < p.Length; i++)
		{
			nc[i] = new NamedColor() { Name = p[i].Name, Color = (Color) p[i].GetValue(null) };
		}

		return nc;
	}
}

public class NamedColor
{
	public string Name { get; set; }

	public string HexCode => Color.ToString();

	public Color Color { get; set; }

	public Brush Brush => new SolidColorBrush(Color);
}