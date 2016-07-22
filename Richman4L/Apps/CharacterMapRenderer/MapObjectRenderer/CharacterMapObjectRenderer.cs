/*
* Richman4L: A free game with a rule like Richman4Fun.
* Copyright (C) 2010-2016 Wencey Wang
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Affero General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Affero General Public License for more details.
*
* You should have received a copy of the GNU Affero General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;

using WenceyWang . Richman4L . Maps;
using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . App . CharacterMapRenderer . MapObjectRenderer
{

	public abstract class CharacterMapObjectRenderer<T> : ICharacterMapObjectRenderer, IMapObjectRenderer<T>
		where T : MapObject
	{

		public virtual ConsoleChar [ , ] CurrentView { get; protected set; }

		public ConsoleSize Unit { get; protected set; }

		public T Target { get; protected set; }

		public virtual void StartUp ( )
		{
			CurrentView = new ConsoleChar [ Unit . Width , Unit . Height ];
			for ( int y = 0 ; y < Unit . Height ; y++ )
			{
				for ( int x = 0 ; x < Unit . Width ; x++ )
				{
					CurrentView [ x , y ] = new ConsoleChar ( ' ' , ConsoleColor . White , ConsoleColor . DarkGreen );
				}
			}
			Update ( );
		}
		public abstract void Update ( );

		public virtual void SetUnit ( ConsoleSize unit ) { Unit = unit; }

		MapObject ICharacterMapObjectRenderer.Target => Target;

		public virtual void SetTarget ( [NotNull] T target )
		{
			if ( Target == null )
			{
				Target = target;
			}
			else
			{
				throw new InvalidOperationException ( );
			}
		}
		public void SetTarget ( MapObject target )
		{
			if ( target == null )
			{
				throw new ArgumentNullException ( nameof ( target ) );
			}

			T targetArgument = target as T;
			if ( targetArgument != null )
			{
				SetTarget ( targetArgument );
			}
			else
			{
				throw new ArgumentException ( $"{nameof ( target )} is not {typeof ( T ) . Name}" );
			}
		}

		#region IDisposable Support

		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose ( bool disposing )
		{
			if ( !disposedValue )
			{
				if ( disposing )
				{
					// TODO: dispose managed state (managed objects).
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~CharacterMapObjectRenderer() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose ( )
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose ( true );

			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}

		#endregion
	}

}
