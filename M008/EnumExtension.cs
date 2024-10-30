using System.Windows.Markup;

namespace M008;

public class EnumExtension : MarkupExtension
{
	/// <summary>
	/// Properties in einer MarkupExtension können im XAML gesetzt werden (wie Binding Path, Binding ElementName, ...)
	/// </summary>
	public Type EnumType { get; set; }

	/// <summary>
	/// Wenn die GUI den Wert benötigt, wird diese Methode ausgeführt, und der Rückgabewert wird in die GUI eingetragen
	/// 
	/// Beispiel: ComboBox
	/// Wenn die ComboBox geöffnet wird, werden die Items erzeugt
	/// Dabei wird ProvideValue ausgeführt, um die Items zu bekommen
	/// </summary>
	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		if (EnumType == null || !EnumType.IsEnum)
			throw new ArgumentException("EnumType ist kein Enum Typ");

		return Enum.GetValues(EnumType);
	}
}