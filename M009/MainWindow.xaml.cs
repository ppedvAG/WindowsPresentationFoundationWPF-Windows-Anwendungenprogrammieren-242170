using System.ComponentModel;
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

namespace M009;

public partial class MainWindow : Window, IDataErrorInfo
{
	public int Counter { get; set; } = 10000;

	private string vorname;

	public string Vorname
	{
		get => vorname;
		set
		{
			//Hier wird die Validierung durchgeführt
			if (!value.All(char.IsLetter))
				throw new Exception("Alle Zeichen müssen Buchstaben sein!"); //Fehlermeldung in der Exception wird im ErrorTemplate angezeigt

			vorname = value;
		}
	}

	public string Nachname { get; set; }

	public MainWindow()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{

	}


	//////////////////////////////////////////////////////////////////////

	//IDataErrorInfo

	/// <summary>
	/// Kann ignoriert werden
	/// </summary>
	public string Error => throw new NotImplementedException();

	/// <summary>
	/// Indexer
	/// 
	/// Wird normalerweise für [] bei Listentypen verwendet (z.B. List, Array, Dictionary, ...)
	/// Hier wird der Indexer für Validierung verwendet
	/// 
	/// Wenn ein Case null zurückgibt, wird dieses als Fehlerfrei behandelt
	/// </summary>
	public string this[string propertyName]
	{
		get
		{
			switch (propertyName)
			{
				case nameof(Counter):
					if (Counter < 0 || Counter > 100)
						return "Die Zahl muss zwischen 0 und 100 liegen!";
					return null; //Kein Fehler

				case nameof(Vorname):
					if (!Vorname.All(char.IsLetter))
						return "Alle Zeichen müssen Buchstaben sein!";
					return null; //Kein Fehler

				case nameof(Nachname):
					if (Nachname != null)
						if (!Nachname.All(char.IsLetter))
							return "Alle Zeichen müssen Buchstaben sein! (Von IDataErrorInfo)";
					return null; //Kein Fehler
			}

			//Für alle anderen Felder, welche nicht Validiert werden
			return null;
		}
	}
}