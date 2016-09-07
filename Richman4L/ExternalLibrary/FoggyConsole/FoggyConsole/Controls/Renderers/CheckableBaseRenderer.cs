using System ;

namespace FoggyConsole . Controls .Renderers
{

	/// <summary>
	///     Base class for <code>RadioButtonRenderer</code> and <code>CheckboxRenderer</code>
	/// </summary>
	public class CheckableBaseRenderer < T > : TextualBaseRenderer < T > where T : CheckableBase
	{

		public CheckableBaseRenderer ( T control , string format )
			: base ( control , format , 4 ) { }

		/// <summary>
		///     Draws the checkbox given in the Control-Property
		/// </summary>
		public override void Draw ( )
		{
			base . Draw ( ) ;

			char checkChar ;
			switch ( Control . State )
			{
				case CheckState . Checked :
				{
					checkChar = 'X' ;
					break ;
				}
				case CheckState . Unchecked :
				{
					checkChar = ' ' ;
					break ;
				}
				case CheckState . Indeterminate :
				{
					checkChar = '?' ;
					break ;
				}
				default :
					throw new ArgumentOutOfRangeException ( ) ;
			}

			base . Draw ( Control . IsFocused ? Control . BackgroundColor : Control . ForegroundColor ,
						Control . IsFocused ? Control . ForegroundColor : Control . BackgroundColor ,
						checkChar ) ;

			//if ( _control . State == CheckState . Indeterminate )
			//{
			//	// overwrites the character which indicates the checked-state of the checkbox,
			//	// to have an inverted background-color
			//	FogConsole . Write ( Boundary . Left + 1 , Boundary . Top ,
			//						checkChar . ToString ( ) , Boundary ,
			//						backgroundColor: Control . IsFocused ? ConsoleColor . Black : ConsoleColor . Gray );
			//}
		}

	}

}
