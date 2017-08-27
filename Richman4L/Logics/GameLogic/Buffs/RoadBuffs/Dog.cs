using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Buffs . PlayerBuffs ;
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
		[GameRuleValue ( 3333 )]
		public static int BiteWalkerPossibility { get ; internal set ; }

		/// <summary>
		///     指示在此停止的人被狗咬的概率的10000倍
		/// </summary>
		[GameRuleValue ( 6666 )]
		public static int BiteStayerPossibility { get ; internal set ; }

		[GameRuleValue ( 800 )]
		public static int HighestTolerableWindStrength { get ; set ; }

		[GameRuleValue ( - 5 )]
		public static int LowestTolerableTemperature { get ; set ; }

		[GameRuleValue ( 37 )]
		public static int HighestTolerableTemperature { get ; set ; }

		[GameRuleValue ( 4 )]
		public static int MaxLiveDuration { get ; set ; }


		[GameRuleValue ( 1 )]
		public static int MinLiveDuration { get ; set ; }

		public Dog ( int duration ) : base ( duration ) { }

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
			return weather . Wind . Strength >= HighestTolerableWindStrength
					|| weather . Temperature <= LowestTolerableTemperature || weather . Temperature >= HighestTolerableTemperature ;
		}

		public void Bite ( Player player )
		{
			int days = GameRandom . Current . Next ( 1 , 4 ) ;
			BiteEvent ? . Invoke ( this , new DogBiteEventArgs ( player , days ) ) ;
			player . AddBuff ( new DogBitedBuff ( player ) ) ;

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

	//todo:should rename but i am too tired and you should fix this ingore thzose spell error and naming error ,yousghoulf fix these or i eill do this after those days.

	public class DogBitedBuff : PlayerBuff
	{

		[GameRuleValue ( 20 )]
		public int Harm { get ; set ; }


		public DogBitedBuff ( Player target ) : base ( target , 1 )
		{
			//todo:

			//	if ( target.Model. Strong )
			{
			}
			target . Health -= Harm ;
		}

	}

}
