namespace FoggyConsole . Controls .Renderers
{

	/// <summary>
	///     Draws a <code>Checkbox</code>-Control
	/// </summary>
	public class CheckboxRenderer : CheckableBaseRenderer < Checkbox >
	{

		/// <summary>
		/// </summary>
		/// <param name="control"></param>
		public CheckboxRenderer ( Checkbox control = null )
			: base ( control , "[{1}] {0}" ) { }

	}

}
