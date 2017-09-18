using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net . Security ;

using WenceyWang . Richman4L . Logics ;
using WenceyWang . Richman4L . Logics . Auctions ;
using WenceyWang . Richman4L . Logics . GameEnviroment ;
using WenceyWang . Richman4L . Logics . InfomationCenter ;
using WenceyWang . Richman4L . Logics . Players ;
using WenceyWang . Richman4L . Logics . Players . Commands ;
using WenceyWang . Richman4L . Logics . Players . Models ;

namespace WenceyWang . Richman4L . Sockets
{

	public class Server
	{

	}

	/// <summary>
	///     为服务器抽象的远程客户端
	/// </summary>
	public class RemoteClient : PlayerConsole
	{

		public SslStream Stream { get ; }

		public Queue <DataPackage> Queue { get ; }

		public override void ShowEvent ( Event @event ) { throw new NotImplementedException ( ) ; }

		public override void PlayerSay ( Player player , PlayerSaying saying ) { throw new NotImplementedException ( ) ; }

		public override void ShowFlag ( bool flaged ) { throw new NotImplementedException ( ) ; }

		public override void UpdateGame ( GameObject gameObject ) { throw new NotImplementedException ( ) ; }

		public override void ShowChatMessage ( Player source , string message ) { throw new NotImplementedException ( ) ; }

		public override void ShowDices ( List <DiceWithValue> dices ) { throw new NotImplementedException ( ) ; }

		public override void UpdatePlayerCommand ( List <PlayerCommand> commands ) { throw new NotImplementedException ( ) ; }

		public override void StartSmallGame ( SmallGameType gameType ) { throw new NotImplementedException ( ) ; }

		public override void ShowGameOver ( GameResult info ) { throw new NotImplementedException ( ) ; }

		public override void StartAuction ( AuctionRequest request ) { throw new NotImplementedException ( ) ; }

		public override void ShowDice ( DiceType diceType , int value ) { throw new NotImplementedException ( ) ; }

		public override void UpdateAuction ( AuctionRequest request , Player buyer , long priceRised )
		{
			throw new NotImplementedException ( ) ;
		}

		public override void ShowAuctionResult ( AuctionRequest request , AuctionResult result )
		{
			throw new NotImplementedException ( ) ;
		}

		public override PlayerConsoleAbility GetAbility ( ) { throw new NotImplementedException ( ) ; }

	}

	public class DataPackage
	{

	}

}
