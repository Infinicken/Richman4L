﻿/*
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
using System . Linq ;
using System . Reflection ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;

namespace WenceyWang . Richman4L . Maps
{

	/// <summary>
	///     代表地图上的元素
	/// </summary>
	public abstract class MapObject : NeedRegisTypeBase <MapObjectType , MapObjectAttribute , MapObject>
	{

		/// <summary>
		///     元素的起始X值
		/// </summary>
		public virtual int X { get ; protected set ; }

		/// <summary>
		///     元素的起始Y值
		/// </summary>
		public virtual int Y { get ; protected set ; }

		/// <summary>
		///     元素的尺寸
		/// </summary>
		public abstract MapSize Size { get ; }

		private static bool Loaded { get ; set ; }

		/// <summary>
		///     基于地图资源创建MapObject
		/// </summary>
		/// <param name="resource"></param>
		public MapObject ( [NotNull] XElement resource ) : this ( )
		{
			if ( resource == null )
			{
				throw new ArgumentNullException ( nameof(resource) ) ;
			}

			try
			{
				X = ReadNecessaryValue <int> ( resource , nameof(X) ) ;
				Y = ReadNecessaryValue <int> ( resource , nameof(Y) ) ;
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof(resource)} has wrong data or lack of data" , e ) ;
			}
		}

		public MapObject ( ) { }

		/// <summary>
		///     要求地图元素的视图更新
		/// </summary>
		public void UpdateView ( )
		{
			UpdateViewEvent ? . Invoke ( this , EventArgs . Empty ) ;
		}

		[NotNull]
		public event EventHandler UpdateViewEvent ;


		public event EventHandler DisposeEvent ;


		[Startup ( nameof(LoadMapObjects) )]
		public static void LoadMapObjects ( )
		{
			lock ( Locker )
			{
				if ( Loaded )
				{
					return ;
				}

				//Todo:Load All internal type
				foreach (
					TypeInfo type in
					typeof ( Game ) . GetTypeInfo ( ) .
									Assembly . DefinedTypes .
									Where ( type => type . GetCustomAttributes ( typeof ( MapObjectAttribute ) , false ) . Any ( ) &&
													typeof ( MapObject ) . GetTypeInfo ( ) . IsAssignableFrom ( type ) ) )
				{
					RegisMapObjectType ( type . AsType ( ) ) ;
				}

				Loaded = true ;
			}
		}


		/// <summary>
		///     注册一个MapObject类型
		///     这个方法应当在加载程序集的时候被调用，加载的程序集应当注册所有的MapObject
		/// </summary>
		/// <param name="name">用于从地图资源文件中识别的名称</param>
		/// <param name="entryType">要注册的类型类型</param>
		/// <returns>生成的类型</returns>
		[NotNull]
		public static MapObjectType RegisMapObjectType ( [NotNull] Type entryType )
		{
			lock ( Locker )
			{
				#region Check Argument

				if ( entryType == null )
				{
					throw new ArgumentNullException ( nameof(entryType) ) ;
				}

				#endregion

				#region Check Attributes

				MapObjectAttribute attribute = entryType . GetTypeInfo ( ) .
															GetCustomAttributes ( typeof ( MapObjectAttribute ) , false ) .
															FirstOrDefault ( ) as MapObjectAttribute ;

				if ( attribute == null )
				{
					throw new ArgumentException ( $"{nameof(entryType)} should have attribute {nameof(MapObjectAttribute)}" ,
												nameof(entryType) ) ;
				}

				#endregion

				if ( TypeList . Any ( type => type . Guid == entryType . GetTypeInfo ( ) . GUID ) )
				{
					return TypeList . Single ( type => type . Guid == entryType . GetTypeInfo ( ) . GUID ) ;
				}

				MapObjectType mapObjectType = new MapObjectType ( entryType , attribute . Name , attribute . Introduction ) ;

				TypeList . Add ( mapObjectType ) ;

				return mapObjectType ;
			}
		}


		[NotNull]
		public override string ToString ( )
		{
			return $"{GetType ( ) . Name} at {X},{Y}" ;
		}

	}

}
