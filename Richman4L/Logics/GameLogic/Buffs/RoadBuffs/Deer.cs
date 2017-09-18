using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Buffs . RoadBuffs . Event ;
using WenceyWang . Richman4L . Logics . Calendars ;
using WenceyWang . Richman4L . Logics . GameEnviroment ;
using WenceyWang . Richman4L . Logics . Players ;
using WenceyWang . Richman4L . Logics . Weathers ;

namespace WenceyWang . Richman4L . Logics . Buffs . RoadBuffs
{

	public class Deer : RoadBuff
	{

		[GameRuleValue ( 3333 )]
		public static GameValue KickWalkerPossibility { get ; internal set ; }

		[GameRuleValue ( 800 )]
		public static GameValue HighestTolerableWindStrength { get ; set ; }

		[GameRuleValue ( - 15 )]
		public static int LowestTolerableTemperature { get ; set ; }

		[GameRuleValue ( 30 )]
		public static int HighestTolerableTemperature { get ; set ; }

		[GameRuleValue ( 40 )]
		public static int MaxLiveDuration { get ; set ; }


		[GameRuleValue ( 1 )]
		public static int MinLiveDuration { get ; set ; }


		public Deer ( int duration ) : base ( duration ) { }

		public Deer ( GameDate startDate , int duration ) : base ( startDate , duration ) { }

		public void Kick ( Player player )
		{
			int days = GameRandom . Current . Next ( 1 , 4 ) ;
			KickEvent ? . Invoke ( this , new DogBiteEventArgs ( player , days ) ) ;
			player . AddBuff ( new DogBitedBuff ( player ) ) ;

			Expire ( ) ;
		}


		public event EventHandler <DogBiteEventArgs> KickEvent ;

		public event EventHandler <DogDeadEventArgs> DeadEvent ;

		public override void DoWhenPass ( Player player , MoveType moveType )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}

			switch ( moveType )
			{
				case MoveType . Walk :
				case MoveType . RidingBicycle :
				case MoveType . RidingMotorcycle :
				{
					if ( GameRandom . Current . InvokeEvent ( KickWalkerPossibility ) )
					{
						Kick ( player ) ;
					}
					break ;
				}
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
