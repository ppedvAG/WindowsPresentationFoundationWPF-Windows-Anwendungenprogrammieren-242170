using System.ComponentModel;
using System.Windows;

namespace M013;

public partial class MainWindow : Window, INotifyPropertyChanged
{
	public ExitCommand Exit { get; set; } = new();

	public CustomCommand CounterCommand { get; set; }

	public int Counter { get; set; }

	public MainWindow()
	{
		CounterCommand = new CustomCommand(CounterMethod, (o) => true);
		InitializeComponent();
	}

	public void CounterMethod(object o)
	{
		Counter++;
		Notify(nameof(Counter));
	}

	/////////////////////////////////////////////////////

	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}