using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Calendars ;
using WenceyWang . Richman4L . Logics . GameEnviroment ;
using WenceyWang . Richman4L . Logics . Maps . Roads ;

namespace WenceyWang . Richman4L . Logics . Maps . Buildings
{

	public class FireTruck : PlayerLikeBase <Block>
	{

		public override MapSize Size => MapSize . Small ;

		public override MapArea TakeUpArea { get ; }

		public override Block Place { get ; set ; }

		public int Moveability { get ; set ; }

		[GameRuleValue ( 100 )]
		public static int FireTruckMoveability { get ; set ; }

		[GameRuleValue ( 100 )]
		public static int DecreaseFlameAbility { get ; set ; }

		public Block MoveTarget => MovePath . Terminal ;

		public Path MovePath { get ; set ; }

		public override void StartDay ( GameDate nextDate )
		{
			base . StartDay ( nextDate ) ;
			Moveability = FireTruckMoveability ;

			//Moveability-=
		}

	}


	public abstract class PlayerLikeBase <TTarget> : MapObject where TTarget : Block
	{

		public override MapPosition Position
		{
			get => Place . Position ;
			protected set => throw new NotSupportedException ( ) ;
		}

		public abstract TTarget Place { get ; set ; }

	}


	public class FireStation : Building
	{

		public override int NoncombustiblePartRatio { get ; }

		public override bool IsEasyToDestroy => false ;

		public override long MaintenanceFee { get ; }

		public List <FireTruck> FireTrucks { get ; } = new List <FireTruck> ( ) ;

		public static List <FireStation> FireStations { get ; } = new List <FireStation> ( ) ;

		public static List <FireTruck> AllFireTrucks
			=> FireStations . SelectMany ( station => station . FireTrucks ) . ToList ( ) ;

		//public override 

		[GameRuleValue ( 10 )]
		public static int FireTruckCapacity { get ; set ; }

		public static bool Routed { get ; set ; }

		public static List <Block> FlamingBlocks => Map . Currnet . Blocks . FindAll ( block => block . IsFiring ) ;

		public override long MinimumValue { get ; }

		private static void EndDay ( )
		{
			lock ( Locker )
			{
				if ( Routed )
				{
					Routed = false ;
				}
			}
		}

		/// <summary>
		/// </summary>
		private static void StartDay ( )
		{
			lock ( Locker )
			{
				if ( ! Routed )
				{
					foreach ( Block block in FlamingBlocks )
					{
					}
				}
			}
		}

		public override void StartDay ( GameDate nextDate ) { base . StartDay ( nextDate ) ; }


		public override void Destoy ( BuildingDestroyReason reason ) { throw new NotImplementedException ( ) ; }

	}

}
