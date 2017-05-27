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
using WenceyWang . Richman4L . Buffs . RoadBuffs ;
using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Players ;
using WenceyWang . Richman4L . Stats ;

namespace WenceyWang . Richman4L . Maps . Roads
{

	/// <summary>
	///     代表地图上的道路
	/// </summary>
	public abstract class Road : Block
	{

		public bool BlockMoving => Buffs . Any ( buff => buff . BlockMoving ) ;

		[NotNull]
		public List <RoadBuff> Buffs { get ; } = new List <RoadBuff> ( ) ;

		public override MapSize Size => MapSize . Small ;

		public override int PondingDecrease => 400 ;

		public override GameValue Flammability => 0 ;

		public override int CombustibleMaterialAmount => 0 ;

		public override GameValue ForestCoverRate { get { return 0 ; } set { } }

		public Road ( XElement resource ) : base ( resource ) { }

		public virtual void Pass ( Player player , MoveType moveType )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}

			foreach ( RoadBuff buff in Buffs )
			{
				buff . DoWhenPass ( player , moveType ) ;
			}

			CountPass ( player ) ;
		}

		public virtual void Stay ( Player player , MoveType moveType )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}

			foreach ( RoadBuff buff in Buffs )
			{
				buff . DoWhenStay ( player , moveType ) ;
			}

			CountStay ( player ) ;
		}

		/// <summary>
		///     获取路径的末端和末端之前的路径
		/// </summary>
		/// <param name="previous">前一个路径</param>
		/// <param name="moveCount">能延长的路径长度</param>
		/// <param name="result"></param>
		/// <returns>路径</returns>
		public abstract Path Route ( Road previous , int moveCount , Path result = null ) ;

		/// <summary>
		///     获取能否从某个道路进入这个道路
		/// </summary>
		/// <param name="road">前一个道路</param>
		/// <returns>能否进入</returns>
		public abstract bool CanEnterFrom ( Road road ) ;

		public override void StartDay ( GameDate thisDate ) { }

		public override void EndToday ( ) { }

		/// <summary>
		///     为这个道路增加一个增益
		/// </summary>
		/// <param name="buff">要增加的增益</param>
		public virtual void AddBuff ( RoadBuff buff )
		{
			if ( buff == null )
			{
				throw new ArgumentNullException ( nameof(buff) ) ;
			}

			Buffs . Add ( buff ) ;
		}

		#region Stats

		#region Pass

		public long PassCount { get ; private set ; }

		public List <PlayerCount> PlayerPassCount { get ; } = new List <PlayerCount> ( ) ;

		private void CountPass ( Player player )
		{
			PassCount++ ;
			PlayerCount currentItem = PlayerPassCount . SingleOrDefault ( item => item . Player == player ) ;
			if ( currentItem == null )
			{
				PlayerPassCount . Add ( new PlayerCount ( player ) ) ;
			}
			else
			{
				currentItem . Count++ ;
			}
		}

		#endregion

		#region Stay

		public long StayCount { get ; private set ; }

		public List <PlayerCount> PlayerStayCount { get ; } = new List <PlayerCount> ( ) ;

		private void CountStay ( Player player )
		{
			StayCount++ ;
			PlayerCount currentItem = PlayerStayCount . SingleOrDefault ( item => item . Player == player ) ;
			if ( currentItem == null )
			{
				PlayerStayCount . Add ( new PlayerCount ( player ) ) ;
			}
			else
			{
				currentItem . Count++ ;
			}
		}

		#endregion

		#endregion

	}

}
