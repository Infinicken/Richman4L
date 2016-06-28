/*
* Richman4L: A free game with a rule like Richman4Fun.
* Copyright (C) 2010-2016 Wencey Wang
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Collections;
using System . Reflection;
using System . Xml . Linq;
using System . Xml . Serialization;
using System . Runtime . Serialization;
using System . Runtime;
using System . Threading . Tasks;

namespace WenceyWang . Richman4L
{
	public abstract class GameObject : IDisposable
	{

		//Todo:如果没有别的用，删除这个。
		public static List<GameObject> GameObjectList { get; private set; } = new List<GameObject> ( );

		public long Index { get; set; }

		public abstract void EndToday ( );

		public abstract void StartDay ( Calendars . GameDate nextDate );

		public GameObject ( )
		{
			Index = GetHashCode ( );
			GameObjectList . Add ( this );
		}

		/// <summary>
		/// 检查这个GameObject是否已经被销毁
		/// </summary>
		protected void CheckDisposed ( )
		{
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) );
			}
		}

		protected bool IsSaving = false;

		#region IDisposable Support

		protected bool DisposedValue = false; // To detect redundant calls

		protected virtual void Dispose ( bool disposing )
		{
			if ( !DisposedValue )
			{
				if ( disposing )
				{
					GameObjectList . Remove ( this );
				}


				// TODO: set large fields to null.

				DisposedValue = true;
			}
		}

		~GameObject ( ) { Dispose ( false ); }

		public void Dispose ( ) { Dispose ( true ); }

		#endregion
	}
}
