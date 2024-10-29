using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace M005;

public partial class MainWindow : Window, INotifyPropertyChanged
{
	private int counter;

	//WICHTIG: Variablen die in der GUI angezeigt werden sollen, müssen Properties sein
	public int Counter
	{
		get => counter;
		set
		{
			counter = value;
			Notify(); //Bei jeder Änderung von Counter wird jetzt Benachrichtigt
		}
	}

	public Fahrzeug Fzg {  get; set; }

	public ObservableCollection<Fahrzeug> Fahrzeuge { get; set; } = new ObservableCollection<Fahrzeug>
	{
		new Fahrzeug(251, FahrzeugMarke.BMW),
		new Fahrzeug(274, FahrzeugMarke.BMW),
		new Fahrzeug(146, FahrzeugMarke.BMW),
		new Fahrzeug(208, FahrzeugMarke.Audi),
		new Fahrzeug(189, FahrzeugMarke.Audi),
		new Fahrzeug(133, FahrzeugMarke.VW),
		new Fahrzeug(253, FahrzeugMarke.VW),
		new Fahrzeug(304, FahrzeugMarke.BMW),
		new Fahrzeug(151, FahrzeugMarke.VW),
		new Fahrzeug(250, FahrzeugMarke.VW),
		new Fahrzeug(217, FahrzeugMarke.Audi),
		new Fahrzeug(125, FahrzeugMarke.Audi)
	};

	public MainWindow()
	{
		InitializeComponent();
		//DataContext im Backend setzen
		//this.DataContext = this;
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Counter++;

		//Benachrichtigung an die GUI senden
		//Notify("Counter");

		//Ohne ObservableCollection wird die GUI nicht Benachrichtigt
		Fahrzeuge.Add(new Fahrzeug(0, FahrzeugMarke.VW));
	}

	/////////////////////////////////////////////////////////////////////////////

	public event PropertyChangedEventHandler? PropertyChanged;

	//CallerMemberName: Fügt automatisch den Namen des aufrufenden Properties hier ein
	//Benötigt ab jetzt keinen Parameter mehr
	public void Notify([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}