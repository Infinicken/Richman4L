using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Auctions ;
using WenceyWang . Richman4L . Cards ;
using WenceyWang . Richman4L . Interoperability . Arguments ;
using WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains ;

namespace WenceyWang . Richman4L . Players . Commands
{

	[PlayerCommand]
	public class UseCardCommand : PlayerCommand
	{

		public override bool CanPerform => Card . CanUse ;

		public override List <ArgumentInfo> ArgumentsInfo => Card . ArgumentsInfo ;

		public Card Card { get ; }

		[PublicAPI]
		public UseCardCommand ( Player performer , [NotNull] Card card ) : base ( performer )
		{
			Card = card ?? throw new ArgumentNullException ( nameof(card) ) ;
		}

		public override void Apply ( ArgumentsContainer arguments ) { Card . Use ( arguments ) ; }

	}


	public class RequestAuctionCommand : PlayerCommand
	{

		public override List <ArgumentInfo> ArgumentsInfo { get ; }

		public RequestAuctionCommand ( Player performer ) : base ( performer )
		{
			ArgumentsInfo = new List <ArgumentInfo> ( ) ;

			ArgumentInfo auction = new ArgumentInfo ( "" , "" , typeof ( IAsset ) , null ) ;
		}

		public override void Apply ( ArgumentsContainer arguments )
		{
			Game . Current . AuctionPerformer . PerformAuction ( new AuctionRequest ( 0 , null , null ) ) ;
		}

	}

	[PlayerCommand]
	public class PlayerMoveCommand : PlayerCommand
	{

		public override List <ArgumentInfo> ArgumentsInfo { get ; }

		public override bool CanPerform => Performer . CanMove ;

		public PlayerMoveCommand ( Player performer ) : base ( performer )
		{
			//Todo:完善资源文件
			ArgumentInfo diceType =
				new ArgumentInfo ( "" , "" , typeof ( DiceType ) , new DiceOwnerDefineDomains ( Performer ) ) ;

			ArgumentInfo moveType =
				new ArgumentInfo ( "" , "" , typeof ( MoveType ) , new MoveTypeAbilityDefineDomains ( Performer ) ) ;

			ArgumentsInfo = new List <ArgumentInfo> { moveType , diceType } ;
		}

		public override void Apply ( ArgumentsContainer arguments )
		{
			if ( arguments . Arguments . Count != 2 )
			{
				throw new ArgumentException ( ) ;
			}

			Performer . Move ( ( MoveType ) arguments . Arguments [ 0 ] , ( DiceType ) arguments . Arguments [ 1 ] ) ;
		}

	}

}
