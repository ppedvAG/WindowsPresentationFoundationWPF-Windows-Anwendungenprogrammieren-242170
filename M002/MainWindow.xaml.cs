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

namespace M002;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();

		CB.ItemsSource = new int[] { 1, 2, 3, 4, 5 };
		LB.ItemsSource = new int[] { 1, 2, 3, 4, 5 };
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Output.Text = Input.Text;
	}

	private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		SliderValue.Text = e.NewValue.ToString();
	}
}