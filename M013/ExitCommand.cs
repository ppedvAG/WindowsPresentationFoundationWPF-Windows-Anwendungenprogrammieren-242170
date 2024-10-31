using System.Windows.Input;

namespace M013;

/// <summary>
/// ICommand gibt 3 Member vor:
/// - CanExecuteChanged: Event, welches auf Änderungen der Ausführbarkeit des Commands reagiert
/// - Execute: Der Code, der bei Ausführung des Command ausgeführt wird
/// - CanExecute: Beschreibt, ob das Command jetzt gerade ausgeführt werden könnte
/// </summary>
public class ExitCommand : ICommand
{
	public event EventHandler? CanExecuteChanged;

	public void Execute(object? parameter)
	{
		Environment.Exit(0); //Programm beenden
	}

	public bool CanExecute(object? parameter)
	{
		return true; //Wenn CanExecute false zurückgibt, ist der Button deaktiviert
	}
}