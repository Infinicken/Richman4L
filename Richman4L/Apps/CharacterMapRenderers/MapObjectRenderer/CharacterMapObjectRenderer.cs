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
using System . Collections;
using System . Linq;
using WenceyWang . Richman4L . Maps;
using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . Apps . CharacterMapRenderers .MapObjectRenderer
{

	public abstract class CharacterMapObjectRenderer <T> : ICharacterMapObjectRenderer , IMapObjectRenderer <T>
		where T : MapObject
	{

		MapObject IMapObjectRenderer . Target => Target ;

		public T Target { get ; protected set ; }

		public virtual ConsoleChar [ , ] CurrentView { get ; protected set ; }

		public ConsoleSize Unit { get ; protected set ; }

		public virtual void StartUp ( )
		{
			CurrentView = new ConsoleChar[ Unit . Width, Unit . Height ] ;
			for ( int y = 0 ; y < Unit . Height ; y++ )
			{
				for ( int x = 0 ; x < Unit . Width ; x++ )
				{
					CurrentView [ x , y ] = new ConsoleChar ( ' ' , ConsoleColor . White , ConsoleColor . DarkGreen ) ;
				}
			}

			Update ( ) ;
		}

		public abstract void Update ( ) ;

		public virtual void SetUnit ( ConsoleSize unit ) { Unit = unit ; }

		MapObject ICharacterMapObjectRenderer . Target => Target ;

		public void SetTarget ( MapObject target )
		{
			if ( target == null )
			{
				throw new ArgumentNullException ( nameof ( target ) ) ;
			}

			T targetArgument = target as T ;
			if ( targetArgument != null )
			{
				SetTarget ( targetArgument ) ;
			}
			else
			{
				throw new ArgumentException ( $"{nameof ( target )} is not {typeof ( T ) . Name}" ) ;
			}
		}

		public virtual void SetTarget ( [NotNull] T target )
		{
			if ( Target == null )
			{
				Target = target ;
			}
			else
			{
				throw new InvalidOperationException ( ) ;
			}
		}

	}

}
