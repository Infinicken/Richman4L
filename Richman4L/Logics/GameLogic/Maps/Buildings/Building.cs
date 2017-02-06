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
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Maps . Buildings . Events ;
using WenceyWang . Richman4L . Players ;
using WenceyWang . Richman4L . Players . PayReasons ;

namespace WenceyWang . Richman4L . Maps .Buildings
{

	//Todo:完善事件
	//Todo:如何表现升级状态？
	/// <summary>
	///     表示建筑
	/// </summary>
	public abstract class Building : MapObject , IAsset
	{

		/// <summary>
		///     建筑的名称
		/// </summary>
		public virtual string Name { get ; set ; }

		/// <summary>
		///     建筑的位置
		/// </summary>
		public virtual Area Position { get ; protected set ; }

		/// <summary>
		///     指示建筑的完成度的10000倍
		/// </summary>
		public int CompletedDgree { get ; set ; }

		/// <summary>
		///     指示建筑的维护水平的10000倍
		/// </summary>
		public int MaintenanceDegree { get ; set ; }


		/// <summary>
		///     指示当前建筑所处的等级
		/// </summary>
		public virtual BuildingGrade Grade { get ; protected set ; }

		/// <summary>
		///     指示建筑类型
		/// </summary>
		public new BuildingType Type { get ; private set ; }

		/// <summary>
		///     指示建筑是否易于摧毁
		/// </summary>
		public abstract bool IsEasyToDestroy { get ; }

		/// <summary>
		///     指示建筑今天所需的维持费
		/// </summary>
		public abstract long MaintenanceFee { get ; }

		public static List <BuildingType> BuildingTypes { get ; private set ; } = new List <BuildingType> ( ) ;

		//Todo:complete this event arg


		protected Building ( )
		{
			CompletedDgree = 0 ;
			MaintenanceDegree = 0 ;
		}

		public WithAssetObject Owner { get ; private set ; }

		public virtual void Upgrade ( BuildingGrade targetGrade ) { }

		public virtual void Pass ( Player player ) { }

		public virtual void Stay ( Player player ) { }

		public abstract void Destoy ( BuildingDestroyReason reason ) ;

		public event EventHandler Destroied ;

		public static event EventHandler <BuildBuildingEventArgs> BuildBuildingEvent ;

		protected virtual void Build ( Area position , Player player )
		{
			Position = position ;
			Grade = Type . EntryGrade ;
			State = BuildingState . Building ;
			player . RequestPay ( player , Type . EntryGrade . StartUpgradeCost , new PayForBuildBuildingReason ( this ) ) ;
			UpgradeTo = null ;
			UpgradeProcess = null ;

			//Todo:完善这个
		}

		public static BuildingType RegisBuildingType ( Type entryType , XElement element )
		{
			#region Check Argument

			if ( entryType == null )
			{
				throw new ArgumentNullException ( nameof ( entryType ) ) ;
			}

			if ( ! typeof ( Building ) . GetTypeInfo ( ) . IsAssignableFrom ( entryType . GetTypeInfo ( ) ) )
			{
				throw new ArgumentException ( $"{nameof ( entryType )} should assignable from {nameof ( Building )}" ,
											nameof ( entryType ) ) ;
			}

			if (
				entryType . GetTypeInfo ( ) . GetCustomAttributes ( typeof ( BuildingAttribute ) , false ) . FirstOrDefault ( ) ==
				null )
			{
				throw new ArgumentException ( $"{nameof ( entryType )} should have atribute {nameof ( BuildingAttribute )}" ,
											nameof ( entryType ) ) ;
			}

			if ( element == null )
			{
				throw new ArgumentNullException ( nameof ( element ) ) ;
			}

			if ( element . Name != nameof ( BuildingType ) )
			{
				throw new ArgumentException ( $"{nameof ( element )} should perform a building type" , nameof ( element ) ) ;
			}

			if ( BuildingTypes . Any ( type => type . EntryType == entryType ) )
			{
				throw new InvalidOperationException ( $"{nameof ( entryType )} have regised" ) ;
			}

			#endregion

			BuildingType buildingType = new BuildingType ( entryType , element ) ;

			BuildingTypes . Add ( buildingType ) ;
			RegisMapObjectType ( buildingType ) ;

			return buildingType ;
		}

		[Startup ( nameof ( LoadBuildingTypes ) )]
		public static void LoadBuildingTypes ( )
		{
			lock ( BuildingTypes )
			{
				BuildingTypes = new List <BuildingType> ( ) ;

				//Todo:Regis all internal Building
			}
		}

		public static void Build ( Area position , BuildingType buildingType , Player player )
		{
			#region Check Argument

			if ( position == null )
			{
				throw new ArgumentNullException ( nameof ( position ) ) ;
			}
			if ( buildingType == null )
			{
				throw new ArgumentNullException ( nameof ( buildingType ) ) ;
			}
			if ( ! BuildingTypes . Contains ( buildingType ) )
			{
				throw new ArgumentException ( $"{nameof ( buildingType )} have not being registered" , nameof ( buildingType ) ) ;
			}
			if ( ! position . IsBuildingAvailable ( buildingType ) )
			{
				throw new ArgumentException ( $"{nameof ( buildingType )} is not aviliable for {nameof ( position )}" ) ;
			}
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof ( player ) ) ;
			}
			if ( position . Owner != player )
			{
				throw new ArgumentException ( $"{nameof ( player )} should own the {nameof ( position )}" ) ;
			}

			#endregion

			Building building = ( Building ) Activator . CreateInstance ( buildingType . EntryType ) ;
			building . Type = buildingType ;
			building . Build ( position , player ) ;
			position . BuildBuildiing ( building ) ;

			BuildBuildingEvent ? . Invoke ( typeof ( Building ) ,
											new BuildBuildingEventArgs ( building , position , buildingType , player ) ) ;
		}

		#region State

		/// <summary>
		///     指示当前建筑的状态
		/// </summary>
		public BuildingState State { get ; protected set ; } = BuildingState . NotBuild ;

		#region	Upgrade

		/// <summary>
		///     指示建筑将会升级到的等级
		/// </summary>
		public virtual BuildingGrade UpgradeTo { get ; protected set ; }

		/// <summary>
		///     指示建筑的升级进程的10000倍
		/// </summary>
		public virtual int ? UpgradeProcess { get ; protected set ; }

		public decimal MinimumValue { get ; }

		public void GiveTo ( WithAssetObject newOwner ) { throw new NotImplementedException ( ) ; }

		#endregion

		#region

		#endregion

		#endregion
	}

}
