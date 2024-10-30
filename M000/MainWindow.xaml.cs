using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M000;

public partial class MainWindow : Window
{
	public Person DiePerson { get; set; } = new Person();

	public string[] Colors { get; set; }

	public MainWindow()
	{
		Type c = typeof(Colors); //Typ der Colors Klasse entnehmen
		PropertyInfo[] p = c.GetProperties(); //Array mit allen Properties der Klasse erzeugen
		//Color[] colors = new Color[p.Length];
		//for (int i = 0; i < p.Length; i++)
		//{
		//	colors[i] = (Color) p[i].GetValue(null); //Aus dem jetztigen Property die Farbe entnehmen
		//}
		string[] names = new string[p.Length];
		for (int i = 0; i < p.Length; i++)
		{
			names[i] = p[i].Name;
		}
		Colors = names;
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{

	}
}