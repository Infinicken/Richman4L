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
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Calendars ;

namespace WenceyWang . Richman4L . Maps
{

	/// <summary>
	///     表示区块，区块会计算积水
	/// </summary>
	public abstract class Block : MapObject
	{

		public long Id => ( X + Y ) * ( X + Y + 1 ) / 2 + Y ;

		/// <summary>
		///     表示当前区块的积水量
		/// </summary>
		[ConsoleVisable]
		public virtual int PondingAmount { get ; set ; }

		/// <summary>
		///     表示每天能够减少的积水量
		/// </summary>
		[ConsoleVisable]
		public abstract int PondingDecrease { get ; }

		/// <summary>
		///     指示当前块是否覆盖了水
		/// </summary>
		[ConsoleVisable]
		public bool IsWet => PondingAmount != 0 ;

		/// <summary>
		///     指示可燃性
		/// </summary>
		[ConsoleVisable]
		public abstract int Flammability { get ; }

		/// <summary>
		///     指示当前的火焰强度
		/// </summary>
		[ConsoleVisable]
		public int FlameStrength { get ; set ; }

		/// <summary>
		///     指示没有被燃烧的比率
		/// </summary>
		[ConsoleVisable]
		public int UnburnedRatio
			=>
				Convert . ToInt32 (
					Convert . ToDecimal ( BurnedAmount ) / Convert . ToDecimal ( CombustibleMaterialAmount ) * 10000 ) ;

		/// <summary>
		///     指示当前块的可燃物总量
		/// </summary>
		[ConsoleVisable]
		public abstract int CombustibleMaterialAmount { get ; }

		/// <summary>
		///     指示当前块已经被烧毁的量
		/// </summary>
		[ConsoleVisable]
		public int BurnedAmount { get ; set ; }

		/// <summary>
		///     指示当前块的森林覆盖率
		/// </summary>
		[ConsoleVisable]
		public abstract int ForestCoverRate { get ; set ; }

		/// <summary>
		///     指示当前块是否正在燃烧
		/// </summary>
		[ConsoleVisable]
		public bool IsFiring => FlameStrength != 0 ;

		/// <summary>
		///     指示当前块是否覆盖了冰
		/// </summary>
		[ConsoleVisable]
		public bool IsFrozen => IceThickness != 0 ;

		/// <summary>
		///     指示当前块覆盖冰的厚度
		/// </summary>
		[ConsoleVisable]
		public int IceThickness { get ; protected set ; }

		/// <summary>
		///     指示当前块是否覆盖了雪
		/// </summary>
		[ConsoleVisable]
		public bool IsBearSnow => SnowThickness != 0 ;

		/// <summary>
		///     指示当前块覆盖雪的厚度
		/// </summary>
		[ConsoleVisable]
		public int SnowThickness { get ; protected set ; }

		public Block ( [NotNull] XElement resource ) : base ( resource )
		{
			if ( resource == null )
			{
				throw new ArgumentNullException ( nameof(resource) ) ;
			}
		}

		protected Block ( ) { }

		public override void StartDay ( GameDate thisDate )
		{
			//Todo:更新火焰强度之类的
			//积水量会减少燃烧强度
			if ( IsFiring )
			{
				FlameStrength += Flammability ;

				//降水量造成的影响
				//Todo:改名字以及定义
				int 降水量造成的影响的系数 = 1 ;
				FlameStrength = Math . Max ( FlameStrength - Game . Current . Weather . Precipitation * 降水量造成的影响的系数 , 0 ) ;

				//判断是否扩散


				//风影响扩散而不是强度
			}
		}

		public override void EndToday ( )
		{
			//todo:
			//积水量会增加降雨量的数目
			//可燃物的量减少燃烧强度


			PondingAmount += Game . Current . Weather . Precipitation ;
			int firePoint = FlameStrength ;
			int currentPondignAmount = PondingAmount ;
			PondingAmount = Math . Max ( currentPondignAmount - firePoint , 0 ) ;
			firePoint = Math . Max ( firePoint - currentPondignAmount , 0 ) ;
			BurnedAmount = Math . Min ( firePoint + BurnedAmount , CombustibleMaterialAmount ) ;
		}

	}

	/// <summary>
	///     提供将x,y映射到单个值的方法
	/// </summary>
	public static class CantorPairing
	{

		public static long Calu ( int x , int y ) { return ( x + y ) * ( x + y + 1 ) / 2 + y ; }

		//public static 

	}

}
