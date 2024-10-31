using System.Windows.Input;

namespace M013;

/// <summary>
/// Problem: Jedes Click-Event benötigt eine eigene Klasse
/// Lösung: Generische Klasse (CustomCommand), welche die Logik per Parameter empfängt
/// </summary>
public class CustomCommand : ICommand
{
	public event EventHandler? CanExecuteChanged;

	private Action<object> _execute;

	private Func<object, bool> _canExecute;

	/// <summary>
	/// Action: Behälter für einen Methodenzeiger, welcher void zurückgibt, und beliebig viele Parameter hat
	/// Action<object>: Methodenzeiger, welcher void zurückgibt, und einen Parameter vom Typ object hat
	/// Func<object, bool>: Methodenzeiger, welcher bool zurückgibt, und einen Parameter vom Typ object hat
	/// </summary>
    public CustomCommand(Action<object> a, Func<object, bool> f)
    {
		_execute = a;
		_canExecute = f;
    }

    public void Execute(object? parameter)
	{
		_execute.Invoke(parameter); //Invoke: Führe die Methode hinter dem Methodenzeiger aus
	}

	public bool CanExecute(object? parameter)
	{
		return _canExecute.Invoke(parameter);
	}
}