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
using System . Collections . ObjectModel ;
using System . Linq ;
using System . Xml . Linq ;

namespace WenceyWang . Richman4L . Maps .Buildings
{

	/// <summary>
	///     指示建筑等级
	/// </summary>
	public sealed class BuildingGrade
	{

		private ReadOnlyCollection < BuildingGrade > _canUpgradeToCache ;

		/// <summary>
		///     建筑等级在建筑类型中的Id
		/// </summary>
		public int Id { get ; }

		/// <summary>
		///     隶属于的建筑类型
		/// </summary>
		public BuildingType BelongTo { get ; }

		/// <summary>
		///     建筑等级的等级
		/// </summary>
		public int Grade { get ; }

		/// <summary>
		///     建筑等级的名称
		/// </summary>
		public string Name { get ; }

		/// <summary>
		///     建筑等级的名称
		/// </summary>
		public string Introduction { get ; }

		/// <summary>
		///     从关闭状态切换到工作状态所需的时间
		/// </summary>
		public long RecoverTime { get ; }

		/// <summary>
		///     开始升级所需的资金
		/// </summary>
		public long StartUpgradeMoney { get ; }

		/// <summary>
		///     升级过程每天所需的资金
		/// </summary>
		public long NormalUpgradeMoney { get ; }

		/// <summary>
		///     升级过程所需的时间（天）
		/// </summary>
		public int UpgradeTime { get ; }

		/// <summary>
		///     维持建筑运作每天所需的维护费
		/// </summary>
		public long MaintenanceFee { get ; }

		private List < long > CanUpdateToId { get ; }

		private List < BuildingGrade > GetCanUpgradeTo
			=> BelongTo . Grades . Where ( grade => CanUpdateToId . Contains ( grade . Id ) ) . ToList ( ) ;

		/// <summary>
		///     指示能升级到的建筑等级
		/// </summary>
		public ReadOnlyCollection < BuildingGrade > CanUpgradeTo
			=> _canUpgradeToCache ?? ( _canUpgradeToCache = new ReadOnlyCollection < BuildingGrade > ( GetCanUpgradeTo ) ) ;

		public ReadOnlyCollection < BuildingAccessory > Accessories { get ; }

		internal BuildingGrade ( XElement element , BuildingType belongTo )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof ( element ) ) ;
			}
			if ( element . Name != nameof ( BuildingGrade ) )
			{
				throw new ArgumentException ( $"{nameof ( element )} do not perform a {nameof ( BuildingGrade )}" ,
											nameof ( element ) ) ;
			}
			if ( belongTo == null )
			{
				throw new ArgumentNullException ( nameof ( belongTo ) ) ;
			}

			BelongTo = belongTo ;
			try
			{
				Id = Convert . ToInt32 ( element . Attribute ( nameof ( Id ) ) . Value ) ;
				Grade = Convert . ToInt32 ( element . Attribute ( nameof ( Grade ) ) . Value ) ;
				Name = element . Attribute ( nameof ( Name ) ) . Value ;
				Introduction = element . Attribute ( nameof ( Introduction ) ) . Value ;
				RecoverTime = Convert . ToInt64 ( element . Attribute ( nameof ( RecoverTime ) ) . Value ) ;
				StartUpgradeMoney = Convert . ToInt64 ( element . Attribute ( nameof ( StartUpgradeMoney ) ) . Value ) ;
				NormalUpgradeMoney = Convert . ToInt64 ( element . Attribute ( nameof ( NormalUpgradeMoney ) ) . Value ) ;
				UpgradeTime = Convert . ToInt32 ( element . Attribute ( nameof ( UpgradeTime ) ) . Value ) ;
				MaintenanceFee = Convert . ToInt64 ( element . Attribute ( nameof ( MaintenanceFee ) ) . Value ) ;
				List < BuildingAccessory > accessories = new List < BuildingAccessory > ( ) ;
				Accessories = new ReadOnlyCollection < BuildingAccessory > ( accessories ) ;
				foreach ( XElement accessory in element . Element ( nameof ( Accessories ) ) . Elements ( ) )
				{
					if ( accessory . Name == nameof ( BuildingAccessory ) )
					{
						accessories . Add ( new BuildingAccessory ( accessory , this ) ) ;
					}
					else
					{
						throw new ArgumentException ( $"{nameof ( element )} has wrong data" , nameof ( element ) ) ;
					}
				}

				CanUpdateToId = new List < long > ( ) ;
				foreach ( XElement grade in element . Element ( nameof ( CanUpgradeTo ) ) . Elements ( ) )
				{
					if ( grade . Name == nameof ( BuildingGrade ) )
					{
						CanUpdateToId . Add ( Convert . ToInt64 ( grade . Attribute ( nameof ( Id ) ) . Value ) ) ;
					}
					else
					{
						throw new ArgumentException ( $"{nameof ( element )} has wrong data" , nameof ( element ) ) ;
					}
				}
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof ( element )} has wrong data or lack of data" , e ) ;
			}

			if ( belongTo . Grades . Any ( grade => grade . Id == Id ) )
			{
				throw new ArgumentException ( $"{nameof ( element )} has wrong {nameof ( Id )}" , nameof ( element ) ) ;
			}
		}

		public override string ToString ( ) => $"{Name}({Id}) in {BelongTo . Name}" ;

	}

}
