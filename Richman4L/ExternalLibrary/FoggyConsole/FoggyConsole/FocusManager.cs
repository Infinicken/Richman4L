/*
This file is part of FoggyConsole.

FoggyConsole is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as
published by the Free Software Foundation, either version 3 of
the License, or (at your option) any later version.

FoogyConsole is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with FoggyConsole.  If not, see <http://www.gnu.org/licenses/lgpl.html>.
*/

using System ;
using System . Collections . Generic ;
using System . Linq ;

using Microsoft . Extensions . Logging ;

using WenceyWang . FoggyConsole . Controls ;

namespace WenceyWang .FoggyConsole
{

	/// <summary>
	///     Basic <code>IFocusManager</code> which just cycles through all controls when the user presses TAB
	/// </summary>
	public class FocusManager : IFocusManager
	{

		private Control _focusedControl ;

		private Frame Root { get ; }


		public ILogger CurrentLoger { get ; } = Application . LoggerFactory . CreateLogger <FocusManager> ( ) ;

		/// <summary>
		///     Creates a new FocusManager
		/// </summary>
		/// <param name="root">The control which represents</param>
		/// <exception cref="ArgumentException">Is thrown if <paramref name="root" /> has an container</exception>
		public FocusManager ( Frame root )
		{
			if ( root == null )
			{
				throw new ArgumentNullException ( nameof ( root ) ) ;
			}

			Root = root ;
		}

		/// <summary>
		///     The currently focused control
		/// </summary>
		public Control FocusedControl
		{
			get { return _focusedControl ; }
			private set
			{
				if ( _focusedControl != null )
				{
					_focusedControl . IsFocused = false ;
				}
				_focusedControl = value ;
				if ( _focusedControl != null )
				{
					_focusedControl . IsFocused = true ;
				}
			}
		}

		public void ControlTreeChanged ( ) { }

		/// <summary>
		///     Handles the key user input which is given in <paramref name="args" />
		/// </summary>
		/// <returns>true if the key-press was handled, otherwise false</returns>
		/// <param name="args">The key-press to handle</param>
		public void HandleKeyInput ( KeyPressedEventArgs args )
		{
			List <Control> controlList = Root . GetAllItem ( ) . Where (
				control =>
				{
					if ( control == null )
					{
						CurrentLoger . LogWarning ( $"{nameof ( controlList )} of {Root . Name} contains null" ) ;
						return false ;
					}

					return control . CanFocus ;
				} ) . ToList ( ) ;
			if ( controlList . Count == 0 )
			{
				return ;
			}

			switch ( args . KeyInfo . Key )
			{
				case ConsoleKey . RightArrow :
				case ConsoleKey . DownArrow :
				case ConsoleKey . Tab :
				{
					args . Handled = true ;
					FocusedControl =
						controlList [ ( Math . Max ( controlList . IndexOf ( FocusedControl ) , 0 ) + 1 ) % controlList . Count ] ;
					break ;
				}
				case ConsoleKey . UpArrow :
				case ConsoleKey . LeftArrow :
				{
					args . Handled = true ;
					FocusedControl =
						controlList [
							( Math . Max ( controlList . IndexOf ( FocusedControl ) , 0 ) + controlList . Count - 1 ) % controlList . Count ] ;
					break ;
				}

				//{
				//	bool up = args . KeyInfo . Key == ConsoleKey . UpArrow;
				//	bool down = args . KeyInfo . Key == ConsoleKey . DownArrow;
				//	bool left = args . KeyInfo . Key == ConsoleKey . LeftArrow;
				//	bool right = args . KeyInfo . Key == ConsoleKey . RightArrow;

				//	bool upDown = up || down;
				//	bool leftRight = left || right;


				//	//int [ ] controls = GetNearbyControls ( FocusedControl ,
				//	//										leftRight ,
				//	//										upDown )
				//	//	. OrderBy (
				//	//		i => upDown ? _controls [ i ] . Renderer . Boundary . Top : _controls [ i ] . Renderer . Boundary . Left * - 1 ) .
				//	//	ToArray ( ) ;

				//	//if ( controls . Length == 0 )
				//	//{
				//	//	return true ;
				//	//}

				//	//for ( int i = 0 ; i < controls . Length ; i++ )
				//	//{
				//	//	if ( controls [ i ] == _focusedIndex )
				//	//	{
				//	//		if ( ( up || right ) &&
				//	//			i != 0 )
				//	//		{
				//	//			SetFocusedIndex ( controls [ i - 1 ] ) ;
				//	//		}
				//	//		if ( ( down || left ) &&
				//	//			i != controls . Length - 1 )
				//	//		{
				//	//			SetFocusedIndex ( controls [ i + 1 ] ) ;
				//	//		}
				//	//		break ;
				//	//	}
				//	//}
				//	break;
				//}
			}
		}

	}

}
