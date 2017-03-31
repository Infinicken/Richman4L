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
	///     The actual Application.
	///     It contains a <code>RootControl</code> in which all other <code>Control</code> instances are stored in a
	///     tree-format.
	///     It also manages userinput and drawing.
	/// </summary>
	public class Application
	{

		private FocusManager _focusManager ;

		/// <summary>
		///     Enables some debugging options, such as drawing panels with background and displaying pressed keys
		/// </summary>
		public bool DebugMode { get ; set ; } = false ;

		public bool DebugLog { get ; set ; } = false ;

		/// <summary>
		///     The root of the Control-Tree
		/// </summary>
		public Frame ViewRoot { get ; }

		private static ILogger Logger { get ; } = LoggerFactory . CreateLogger <Application> ( ) ;

		/// <summary>
		///     Used as the boundary for the ViewRoot if the terminal-size can't determined
		/// </summary>
		public static Size StandardRootBoundary { get ; } = new Size ( 80 , 24 ) ;


		/// <summary>
		///     Responsible for focus-changes, for example when the user presses the TAB-key
		/// </summary>
		public FocusManager FocusManager
		{
			get { return _focusManager ; }
			set
			{
				if ( IsRunning )
				{
					throw new InvalidOperationException ( "The FocusManager can't be changed once the Application has been started." ) ;
				}

				_focusManager = value ;
			}
		}

		/// <summary>
		///     The name of this application
		/// </summary>
		public string Name { get ; set ; }

		public bool IsRunning { get ; set ; }

		public Size WindowSize
		{
			get
			{
				// Size dedection will work on windows and on most unix-systems
				// mono uses the same values for Window- and Buffer-Properties,
				// so it doesn't matter which values are used.
				return new Size ( Console . WindowWidth , Console . WindowHeight ) ;
			}
			set
			{
				Console . SetWindowSize ( value . Width , value . Height ) ;
				ViewRoot . Size = value ;
			}
		}


		/// <summary>
		///     Creates a new Application
		/// </summary>
		/// <param name="viewRoot">A <code>Container</code> which is at the root of the </param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="viewRoot" /> is null.</exception>
		/// <exception cref="ArgumentException">Thrown when the Container-Property of <paramref name="viewRoot" /> is set.</exception>
		public Application ( Frame viewRoot = null )
		{
			if ( Current != null )
			{
				throw new Exception ( ) ;
			}

			viewRoot = viewRoot ?? new Frame ( ) ;
			if ( viewRoot . Container != null )
			{
				throw new ArgumentException ( "The root-container can't have the Container-Property set." , nameof ( viewRoot ) ) ;
			}

			Current = this ;
			ViewRoot = viewRoot ;
			FocusManager = new FocusManager ( ViewRoot ) ;
		}

		public static ILoggerFactory LoggerFactory = new LoggerFactory ( ) . AddConsole ( ) . AddDebug ( ) ;

		public static Application Current ;

		/// <summary>
		///     Starts this <code>Application</code>.
		/// </summary>
		public void Run ( )
		{
			Console . CursorVisible = false ;
			if ( Name != null )
			{
				Console . Title = Name ;
			}
			Console . Clear ( ) ;

			Console . SetWindowSize ( ViewRoot . Width , ViewRoot . Height ) ;

			ViewRoot . Measure ( WindowSize ) ;
			ViewRoot . Arrange ( new Rectangle ( WindowSize ) ) ;
			ViewRoot . Draw ( ) ;

			KeyWatcher . KeyPressed += KeyWatcherOnKeyPressed ;
			KeyWatcher . Start ( ) ;

			IsRunning = true ;
		}

		/// <summary>
		///     Stops this <code>Application</code>.
		/// </summary>
		public void Stop ( )
		{
			KeyWatcher . KeyPressed -= KeyWatcherOnKeyPressed ;
			KeyWatcher . Stop ( ) ;
			IsRunning = false ;
		}


		private void KeyWatcherOnKeyPressed ( object sender , KeyPressedEventArgs eventArgs )
		{
			if ( DebugLog )
			{
				Logger . LogDebug ( $"Key pressed: {eventArgs . KeyInfo . Key}" ) ;
			}

			Control currentControl = FocusManager ? . FocusedControl ;
			while ( currentControl != null )
			{
				currentControl ? . KeyPressed ( eventArgs ) ;
				if ( ! eventArgs . Handled )
				{
					currentControl = currentControl ? . Container ;
				}
				else
				{
					return ;
				}
			}

			if ( FocusManager != null )
			{
				FocusManager . HandleKeyInput ( eventArgs ) ;
				if ( DebugLog )
				{
					Logger . LogDebug ( $"Focused: {FocusManager . FocusedControl . Name}" ) ;
				}
			}
		}

	}

}
