using System.Windows;

namespace M008;

public partial class MainWindow : Window
{
	public DayOfWeek[] Wochentage { get; set; } = Enum.GetValues<DayOfWeek>();

	public int[] Zahlen { get; set; } = [1, 2, 3, 4, 5];

	public MainWindow()
	{
		InitializeComponent();
	}
}