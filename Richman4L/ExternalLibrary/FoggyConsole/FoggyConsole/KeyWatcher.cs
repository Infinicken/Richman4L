/*
* This file is part of FoggyConsole.
* 
* FoggyConsole is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as
* published by the Free Software Foundation, either version 3 of
* the License, or (at your option) any later version.
* 
* FoogyConsole is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Lesser General Public License for more details.
* 
* You should have received a copy of the GNU Lesser General Public License
* along with FoggyConsole.  If not, see <http://www.gnu.org/licenses/lgpl.html>.
*/

using System ;
using System . Threading ;

namespace WenceyWang .FoggyConsole
{

	/// <summary>
	///     Watches out of userinput using <code>Console.KeyAvailable</code> and <code>Code.ReadKey</code>
	/// </summary>
	internal static class KeyWatcher
	{

		public static bool IsRunning { get ; private set ; }

		public static Thread WatcherThread { get ; private set ; }

		/// <summary>
		///     Is fired when a user presses an key
		/// </summary>
		public static event EventHandler < KeyPressedEventArgs > KeyPressed ;

		public static void Start ( )
		{
			if ( ! IsRunning )
			{
				WatcherThread = new Thread ( WatchOut ) { Name = "KeyWatcher" } ;
				IsRunning = true ;
				WatcherThread . Start ( ) ;
			}
		}

		private static void WatchOut ( )
		{
			while ( IsRunning )
			{
				ConsoleKeyInfo keyInfo = Console . ReadKey ( true ) ;

				KeyPressed ? . Invoke ( null , new KeyPressedEventArgs ( keyInfo ) ) ;
			}
		}

		/// <summary>
		///     Stops the internal watcher-thread
		/// </summary>
		public static void Stop ( )
		{
			IsRunning = false ;
			WatcherThread . Abort ( ) ;
		}

	}

}
