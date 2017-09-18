using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Calendars ;
using WenceyWang . Richman4L . Logics . GameEnviroment ;
using WenceyWang . Richman4L . Logics . Players ;

namespace WenceyWang . Richman4L . Logics . Maps . Buildings
{

	[Building]
	public class SmallSimpleBuilding : Building
	{

		public long MoneyCostWhenCrossed => throw new NotImplementedException ( ) ;


		public override bool IsEasyToDestroy => true ;

		//Todo:完善价格机制
		public override long MaintenanceFee => Grade . MaintenanceFee ;

		public override int NoncombustiblePartRatio { get ; }

		[GameRuleExpression ( "500d" , typeof ( decimal ) )]
		public override long MinimumValue { get ; }

		public override void Pass ( Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}

			//Todo:加入对是否收费的判断
			if ( State == BuildingState . Working
				&& player != Owner )
			{
			}
			base . Pass ( player ) ;
		}

		public override void Stay ( Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}

			if ( player != Owner )
			{
				if ( player . IsFreeOfCharge ( ) )
				{
				}
				else
				{
					if ( ( Owner as Player ) ? . IsBlockGetCharge ( ) == false )
					{
						;
					}
					{
						//todo
						//player . RequestPay ( Owner , MoneyCostWhenCrossed , new PayMoneyForStayReason ( Position ) ) ;
					}
				}
			}
			base . Stay ( player ) ;
		}


		public override void Destoy ( BuildingDestroyReason reason )
		{
			State = BuildingState . Destroyed ;
			MaintenanceDegree = 0 ;
			CompletedDgree = 5000 ;
		}

		public override void StartDay ( GameDate thisDate )
		{
			if ( Game . Current . Weather . Wind . Strength >= 800 )
			{
				if ( Game . Current . Weather . Wind . Strength >= 950 )
				{
					if ( Game . Current . Weather . Wind . Strength - 950 >= GameRandom . Current . Next ( 51 ) )
					{
						Destoy ( BuildingDestroyReason . Weather ) ;
					}
				}
			}

			switch ( State )
			{
				case BuildingState . Working :
				{
					//Owner ? . RequestPay ( Bank . Current ,
					//						MaintenanceFee ,
					//						new PayMoneyForMaintainBuildingReason ( this ) ) ;
					break ;
				}
				case BuildingState . Closed :
				{
					break ;
				}
				case BuildingState . Destroyed :
				{
					break ;
				}
			}
		}

		public override void EndToday ( ) { }

		public override string ToString ( )
		{
			return $"{nameof(SmallSimpleBuilding)} named {Name} in {Grade} at ({Position})" ;
		}

	}

}
