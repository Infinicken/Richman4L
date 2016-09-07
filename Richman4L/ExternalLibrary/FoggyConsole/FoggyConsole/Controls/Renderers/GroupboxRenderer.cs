namespace FoggyConsole . Controls .Renderers
{

	/// <summary>
	///     Draws a Groupbox
	/// </summary>
	public class GroupboxRenderer : ControlRenderer < Groupbox >
	{

		/// <summary>
		///     The LineStyle which is used to draw this Groupbox
		/// </summary>
		public LineStyle BoarderStyle { get ; set ; } = LineStyle . SingleLinesSet;

		/// <summary>
		/// </summary>
		/// <param name="control"></param>
		public GroupboxRenderer ( Groupbox control ) : base ( control )
		{
			
		}


		/// <summary>
		///     Draws the Groupbox given in the Control-Property
		/// </summary>
		public override void Draw ( )
		{
			base . Draw ( ) ;


		}

	}

}
