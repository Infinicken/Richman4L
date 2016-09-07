namespace FoggyConsole . Controls .Renderers
{

	/// <summary>
	///     Draws a textbox
	/// </summary>
	public class TextboxRenderer : TextualBaseRenderer < Textbox >
	{

		/// <summary>
		/// </summary>
		/// <param name="control"></param>
		public TextboxRenderer ( Textbox control )
			: base ( control , "{1}" , 0 ) { }

		/// <summary>
		///     Draws the textbox given in the Control-Property
		/// </summary>
		public override void Draw ( )
		{
			base . Draw ( ) ;
			string text = null ;

			//if ( ! Control . PasswordMode )
			//{
			//	text = Control . Text ;
			//}
			//else
			//{
			//	text = new string ( Control . PasswordChar , Control . Text . Length ) ;
			//}
            //Todo:Compelete the PasswordBox and it's renderer
			text = text . PadRight ( Control . Width ) ;

			base . Draw ( Control . ForegroundColor , Control . BackgroundColor , text ) ;

			if ( Control . IsFocused )
			{
				char cc ;
				if ( Control . CursorPosition < Control . Text . Length )
				{
					//if ( Control . PasswordMode )
					//{
					//	cc = Control . PasswordChar ;
					//}
					//else
					//{
					//	cc = Control . Text [ Control . CursorPosition ] ;
					//}
				}
				else
				{
					cc = ' ' ;
				}

				//FogConsole . Write ( Boundary . Left + Control . CursorPosition , Boundary . Top , cc , Boundary , Control . BackgroundColor , Control . ForegroundColor );
			}
		}

	}

}
