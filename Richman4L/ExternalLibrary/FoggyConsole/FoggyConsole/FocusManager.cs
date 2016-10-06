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

using FoggyConsole . Controls ;

namespace FoggyConsole
{

	/// <summary>
	///     Basic <code>IFocusManager</code> which just cycles through all controls when the user presses TAB
	/// </summary>
	public class FocusManager : IFocusManager
	{

		private readonly Container _root ;

		private Control [ ] _controls ;

		private int _focusedIndex ;

		/// <summary>
		///     Creates a new FocusManager
		/// </summary>
		/// <param name="root">The control which represents</param>
		/// <param name="startControl"></param>
		/// <exception cref="ArgumentNullException">
		///     Is thrown if <paramref name="startControl" /> or <paramref name="root" /> is
		///     null
		/// </exception>
		/// <exception cref="ArgumentException">Is thrown if <paramref name="startControl" /> has no container</exception>
		/// <exception cref="ArgumentException">Is thrown if <paramref name="startControl" /> is no IInputHandler</exception>
		/// <exception cref="ArgumentException">Is thrown if <paramref name="root" /> has an container</exception>
		/// <exception cref="ArgumentException">
		///     Is thrown if <paramref name="startControl" /> is not within
		///     <paramref name="root" />
		/// </exception>
		public FocusManager ( Container root , Control startControl )
		{
			if ( root == null )
			{
				throw new ArgumentNullException ( nameof ( root ) ) ;
			}
			if ( root . Container != null )
			{
				throw new ArgumentException ( $"{nameof ( root )} has an container!" , nameof ( root ) ) ;
			}

			if ( startControl == null )
			{
				throw new ArgumentNullException ( nameof ( startControl ) ) ;
			}
			if ( startControl . Container == null )
			{
				throw new ArgumentException ( $"{nameof ( startControl )} doesn't have an container!" , nameof ( startControl ) ) ;
			}


			_root = root ;

			CalculateList ( ) ;
			_focusedIndex = - 1 ;
			for ( int i = 0 ; i < _controls . Length ; i++ )
			{
				if ( _controls [ i ] == startControl )
				{
					_focusedIndex = i ;
					_controls [ i ] . IsFocused = true ;
				}
				else
				{
					_controls [ i ] . IsFocused = false ;
				}
			}

			if ( _focusedIndex == - 1 )
			{
				throw new ArgumentException ( "startControl is not within root" , nameof ( startControl ) ) ;
			}
		}

		/// <summary>
		///     The currently focused control
		/// </summary>
		public Control FocusedControl => _controls [ _focusedIndex ] ;

		/// <summary>
		///     Called if the control-tree has been changed
		/// </summary>
		public void ControlTreeChanged ( ) { CalculateList ( ) ; }

		/// <summary>
		///     Handles the key-userinput which is given in <paramref name="args" />
		/// </summary>
		/// <returns>true if the keypress was handled, otherwise false</returns>
		/// <param name="args">The keypress to handle</param>
		public void HandleKeyInput ( KeyPressedEventArgs args )
		{
			switch ( args . KeyInfo . Key )
			{
				case ConsoleKey . Tab :
				{
					if ( _focusedIndex == _controls . Length - 1 )
					{
						SetFocusedIndex ( 0 ) ;
					}
					else
					{
						SetFocusedIndex ( _focusedIndex + 1 ) ;
					}

					args . Handled = true ;
					break ;
				}
				case ConsoleKey . LeftArrow :
				case ConsoleKey . RightArrow :
				case ConsoleKey . UpArrow :
				case ConsoleKey . DownArrow :
				{
					bool up = args . KeyInfo . Key == ConsoleKey . UpArrow ;
					bool down = args . KeyInfo . Key == ConsoleKey . DownArrow ;
					bool left = args . KeyInfo . Key == ConsoleKey . LeftArrow ;
					bool right = args . KeyInfo . Key == ConsoleKey . RightArrow ;

					bool upDown = up || down ;
					bool leftRight = left || right ;

					//int [ ] controls = GetNearbyControls ( FocusedControl ,
					//										leftRight ,
					//										upDown )
					//	. OrderBy (
					//		i => upDown ? _controls [ i ] . Renderer . Boundary . Top : _controls [ i ] . Renderer . Boundary . Left * - 1 ) .
					//	ToArray ( ) ;

					//if ( controls . Length == 0 )
					//{
					//	return true ;
					//}

					//for ( int i = 0 ; i < controls . Length ; i++ )
					//{
					//	if ( controls [ i ] == _focusedIndex )
					//	{
					//		if ( ( up || right ) &&
					//			i != 0 )
					//		{
					//			SetFocusedIndex ( controls [ i - 1 ] ) ;
					//		}
					//		if ( ( down || left ) &&
					//			i != controls . Length - 1 )
					//		{
					//			SetFocusedIndex ( controls [ i + 1 ] ) ;
					//		}
					//		break ;
					//	}
					//}
					break ;
				}
			}
		}

		private void SetFocusedIndex ( int index )
		{
			_focusedIndex = index ;
			FocusedControl . IsFocused = true ;
		}

		/// <summary>
		///     Searches all controlls which are nearby <paramref name="control" />.
		///     Controls in the same row are searched if <paramref name="checkTop" /> is <code>true</code>.
		///     Controls in the same collumn are searched if <paramref name="checkLeft" /> is <code>true</code>.
		/// </summary>
		/// <param name="control"></param>
		/// <param name="checkTop"></param>
		/// <param name="checkLeft"></param>
		/// <returns>A list of controls nearby <paramref name="control" /></returns>
		private IEnumerable < int > GetNearbyControls ( Control control , bool checkTop = false , bool checkLeft = false )
		{
			if ( control . Renderer == null )
			{
				yield break ;
			}

			for ( int i = 0 ; i < _controls . Length ; i++ )
			{
				if ( _controls [ i ] . Renderer == null )
				{
				}
			}
		}

		/// <summary>
		///     Recalculates <code>FocusManager._controls</code>
		/// </summary>
		private void CalculateList ( ) { _controls = CalculateList ( _root ) . ToArray ( ) ; }

		/// <summary>
		///     Gets all <code>IInputHandler</code> controls within <paramref name="container" /> ordered by thier TabIndex
		/// </summary>
		/// <param name="container">The container to search in</param>
		/// <returns>A list of controls</returns>
		private IEnumerable < Control > CalculateList ( Container container )
		{
			List < Control > list = new List < Control > ( ) ;

			foreach ( Control control in container . Chrildren . OrderBy ( c => c . TabIndex ) )
			{
				if ( control is Container )
				{
					list . AddRange ( CalculateList ( ( Container ) control ) ) ;
				}
			}

			return list ;
		}

	}

}
