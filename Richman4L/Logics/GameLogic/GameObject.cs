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

using System ;
using System . Collections . Generic ;

using WenceyWang . Richman4L . Calendars ;

namespace WenceyWang .Richman4L
{

	public abstract class GameObject : IDisposable
	{

		protected bool IsSaving = false ;

		//Todo:如果没有别的用，删除这个。
		public static List < GameObject > GameObjectList { get ; } = new List < GameObject > ( ) ;

		public long Index { get ; set ; }

		public GameObject ( )
		{
			Index = GetHashCode ( ) ;
			GameObjectList . Add ( this ) ;
		}

		public abstract void EndToday ( ) ;

		public abstract void StartDay ( GameDate nextDate ) ;

		/// <summary>
		///     检查这个GameObject是否已经被销毁
		/// </summary>
		protected void CheckDisposed ( )
		{
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) ) ;
			}
		}

		#region IDisposable Support

		protected bool DisposedValue ; // To detect redundant calls

		protected virtual void Dispose ( bool disposing )
		{
			if ( ! DisposedValue )
			{
				if ( disposing )
				{
					GameObjectList . Remove ( this ) ;
				}


				// TODO: set large fields to null.

				DisposedValue = true ;
			}
		}

		~GameObject ( ) { Dispose ( false ) ; }

		public void Dispose ( ) { Dispose ( true ) ; }

		#endregion
	}

}
