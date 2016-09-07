namespace FoggyConsole . Controls .Renderers
{

	/// <summary>
	///     Draws a RadioButton
	/// </summary>
	public class RadioButtonRenderer : CheckableBaseRenderer < RadioButton >
	{

		public RadioButtonRenderer ( RadioButton control )
			: base ( control , "({1}) {0}" ) { }

	}

}
