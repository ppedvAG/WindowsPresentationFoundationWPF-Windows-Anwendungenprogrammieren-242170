using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M012;

public partial class MainWindow : Window
{
	public ObservableCollection<Person> Personen { get; set; }

	public MainWindow()
	{
		string json = File.ReadAllText("Personen.json");
		Personen = JsonSerializer.Deserialize<ObservableCollection<Person>>(json);

		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		//Hier kann der DataContext von Sender verwendet werden, um die entsprechende Person zu finden
		Button b = (Button) sender;
		Person p = (Person) b.DataContext;
		Personen.Remove(p);
	}
}

///////////////////////////////////////////////////////////////////////////////

[DebuggerDisplay("Person - ID: {ID}, Vorname: {Vorname}, Nachname: {Nachname}, GebDat: {Geburtsdatum.ToString(\"yyyy.MM.dd\")}, Alter: {Alter}, " +
	"Jobtitel: {Job.Titel}, Gehalt: {Job.Gehalt}, Einstellungsdatum: {Job.Einstellungsdatum.ToString(\"yyyy.MM.dd\")}")]
public record Person(int ID, string Vorname, string Nachname, DateTime Geburtsdatum, int Alter, Beruf Job, List<string> Hobbies);

public record Beruf(string Titel, int Gehalt, DateTime Einstellungsdatum);

///////////////////////////////////////////////////////////////////////////////