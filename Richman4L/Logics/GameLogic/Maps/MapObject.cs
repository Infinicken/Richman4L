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
using System . Threading . Tasks;
using System . Xml . Linq;

using WenceyWang . Richman4L . Maps . Roads;

namespace WenceyWang . Richman4L . Maps
{
	/// <summary>
	/// 代表地图上的元素
	/// </summary>
	public abstract class MapObject : GameObject
	{

		/// <summary>
		/// 元素的起始X值
		/// </summary>
		public virtual int X { get; protected set; }

		/// <summary>
		/// 元素的起始Y值
		/// </summary>
		public virtual int Y { get; protected set; }

		/// <summary>
		/// 元素的尺寸
		/// </summary>
		public abstract MapSize Size { get; }

		/// <summary>
		/// 要求地图元素的视图更新
		/// </summary>
		public void UpdateView ( ) { UpdateViewEvent?.Invoke ( this , new EventArgs ( ) ); }

		public event EventHandler UpdateViewEvent;

		protected override void Dispose ( bool disposing )
		{
			if ( !DisposedValue )
			{
				if ( disposing )
				{
					Map . Currnet . Objects . Remove ( this );
				}
			}
			base . Dispose ( disposing );
		}

		public static List<MapObjectType> MapObjectTypes { get; private set; } = new List<MapObjectType> ( );

		public static void LoadMapObjects ( )
		{
			//Todo:Load All internal type
			RegisMapObjectType ( nameof ( AreaRoad ) , typeof ( AreaRoad ) );
		}

		public static MapObjectType RegisMapObjectType ( XName name , Type entryType )
		{

			#region Check Argument

			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) );
			}
			if ( entryType == null )
			{
				throw new ArgumentNullException ( nameof ( entryType ) );
			}
			if ( MapObjectTypes . Any ( ( type ) => type . Name == name ) )
			{
				throw new ArgumentException ( $"{nameof ( name )} have been registed" );
			}
			if ( entryType . GetCustomAttributes ( typeof ( MapObjectAttribute ) , false ) . FirstOrDefault ( ) == null )
			{
				throw new ArgumentException ( $"{nameof ( entryType )} should have atribute {nameof ( MapObjectAttribute )}" ,
					nameof ( entryType ) );
			}

			#endregion

			MapObjectType mapObjectType = new MapObjectType ( name . ToString ( ) , entryType );

			MapObjectTypes . Add ( mapObjectType );

			return mapObjectType;

		}

		/// <summary>
		/// 基于地图资源创建MapObject
		/// </summary>
		/// <param name="resource"></param>
		public MapObject ( XElement resource ) : this ( )
		{
			try
			{
				X = Convert . ToInt32 ( resource . Attribute ( nameof ( X ) ) . Value );
				Y = Convert . ToInt32 ( resource . Attribute ( nameof ( Y ) ) . Value );
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof ( resource )} has wrong data or lack of data" , e );
			}
		}


		public MapObject ( ) : base ( )
		{

		}
	}
}
