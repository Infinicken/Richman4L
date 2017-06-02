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

using WenceyWang . Richman4L . Buffs . RoadBuffs . Event ;
using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . GameEnviroment ;
using WenceyWang . Richman4L . Players ;
using WenceyWang . Richman4L . Weathers ;

namespace WenceyWang . Richman4L . Buffs . RoadBuffs
{

	/// <summary>
	///     表示道路上的狗，会咬伤步行经过的人和在此停留的玩家，会被自行车，机车和汽车碾死，会因为不好的天气状况而死。
	/// </summary>
	public class Dog : RoadBuff
	{

		/// <summary>
		///     指示狗咬经过的行人的概率的10000倍
		/// </summary>
		[GameRuleItem ( 3333 )]
		public static int BiteWalkerPossibility { get ; internal set ; }

		/// <summary>
		///     指示在此停止的人被狗咬的概率的10000倍
		/// </summary>
		[GameRuleItem ( 6666 )]
		public static int BiteStayerPossibility { get ; internal set ; }

		[GameRuleItem ( 800 )]
		public static int HighestTolerableWindStrength { get ; set ; }

		[GameRuleItem ( 0 )]
		public static int LowestTolerableTemperature { get ; set ; }

		[GameRuleItem ( 37 )]
		public static int HighestTolerableTemperature { get ; set ; }

		[GameRuleItem ( 4 )]
		public static int MaxLiveDuration { get ; set ; }


		[GameRuleItem ( 1 )]
		public static int MinLiveDuration { get ; set ; }

		public override void DoWhenPass ( Player player , MoveType moveType )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}

			switch ( moveType )
			{
				case MoveType . Walk :
				{
					if ( GameRandom . Current . InvokeEvent ( BiteWalkerPossibility ) )
					{
						Bite ( player ) ;
					}
					break ;
				}
				case MoveType . RidingBicycle :
				case MoveType . RidingMotorcycle :
				case MoveType . DrivingCar :
				{
					Kill ( player , moveType ) ;
					break ;
				}
				default :
				{
					throw new ArgumentOutOfRangeException ( nameof(moveType) ) ;
				}
			}

			base . DoWhenPass ( player , moveType ) ;
		}

		public override void DoWhenStay ( Player player , MoveType moveType )
		{
			if ( GameRandom . Current . InvokeEvent ( BiteStayerPossibility ) )
			{
				Bite ( player ) ;
			}
			base . DoWhenStay ( player , moveType ) ;
		}

		public override void StartDay ( GameDate thisDate )
		{
			if ( IsKilled ( Game . Current . Weather ) )
			{
				Kill ( Game . Current . Weather ) ;
			}
			base . StartDay ( thisDate ) ;
		}

		public bool IsKilled ( Weather weather )
		{
			return weather . Wind . Strength >= HighestTolerableWindStrength ||
					weather . Temperature <= LowestTolerableTemperature ||
					weather . Temperature >= HighestTolerableTemperature ;
		}

		public void Bite ( Player player )
		{
			int days = GameRandom . Current . Next ( 1 , 4 ) ;
			player . ChangeState ( PlayerState . Hospitalized , days ) ;
			BiteEvent ? . Invoke ( this , new DogBiteEventArgs ( player , days ) ) ;
			Expire ( ) ;
		}

		public event EventHandler <DogBiteEventArgs> BiteEvent ;

		public event EventHandler <DogDeadEventArgs> DeadEvent ;

		public void Kill ( Weather weather )
		{
			DeadEvent ? . Invoke ( this , new DogDeadEventArgs ( DogDeadCause . BadWeather ) ) ;
			Kill ( ) ;
		}

		public void Kill ( Player murderer , MoveType moveType )
		{
			switch ( moveType )
			{
				case MoveType . RidingBicycle :
				{
					DeadEvent ? . Invoke ( this , new DogDeadEventArgs ( DogDeadCause . Bicycle ) ) ;
					break ;
				}
				case MoveType . RidingMotorcycle :
				{
					DeadEvent ? . Invoke ( this , new DogDeadEventArgs ( DogDeadCause . Motorcycle ) ) ;
					break ;
				}
				case MoveType . DrivingCar :
				{
					DeadEvent ? . Invoke ( this , new DogDeadEventArgs ( DogDeadCause . Car ) ) ;
					break ;
				}
				default :
				{
					throw new ArgumentOutOfRangeException ( nameof(moveType) ) ;
				}
			}

			Kill ( ) ;
		}

		private void Kill ( ) { Expire ( ) ; }

	}

}
