using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace M014.ViewModel;

public partial class MVVMToolkitViewModel : ObservableObject
{
	[ObservableProperty]
	private int counter;

	[RelayCommand]
	public void CounterIncrement(object o) => Counter++;
}