using M014.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace M014.ViewModel;

public class DataViewViewModel
{
	public ObservableCollection<Person> Personen { get; set; }

	public CustomCommand DeletePersonCommand { get; set; }

	/// <summary>
	/// Konstruktoren im ViewModel werden genauso bei Start aufgerufen wie der normale Backendcode
	/// </summary>
    public DataViewViewModel()
    {
		string json = File.ReadAllText("Personen.json");
		Personen = JsonSerializer.Deserialize<ObservableCollection<Person>>(json);

		DeletePersonCommand = new CustomCommand(DeletePerson , (o) => true);
	}

	private void DeletePerson(object o)
	{
		Personen.Remove((Person) o);
	}
}