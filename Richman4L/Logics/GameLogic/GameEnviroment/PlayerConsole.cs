using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Auctions ;
using WenceyWang . Richman4L . Logics . Cards ;
using WenceyWang . Richman4L . Logics . InfomationCenter ;
using WenceyWang . Richman4L . Logics . Interoperability . Arguments ;
using WenceyWang . Richman4L . Logics . Maps ;
using WenceyWang . Richman4L . Logics . Players ;
using WenceyWang . Richman4L . Logics . Players . Commands ;
using WenceyWang . Richman4L . Logics . Players . Models ;

namespace WenceyWang . Richman4L . Logics . GameEnviroment
{

	/// <summary>
	///     指示玩家所使用的控制台
	/// </summary>
	public abstract class PlayerConsole
	{

		public Guid Guid { get ; set ; }

		public Player Target { get ; internal set ; }

		public abstract void ShowDices ( List <DiceWithValue> dices ) ;

		public abstract void ShowEvent ( Event @event ) ;

		public abstract void PlayerSay ( Player player , PlayerSaying saying ) ;

		public abstract void ShowFlag ( bool flaged ) ;

		public abstract void UpdateGame ( GameObject gameObject ) ;

		public abstract void UpdatePlayerCommand ( List <PlayerCommand> commands ) ;

		public abstract void ShowChatMessage ( Player source , string message ) ;

		public abstract void StartSmallGame ( SmallGameType gameType ) ;

		public abstract void ShowGameOver ( GameResult info ) ;

		public abstract void StartAuction ( AuctionRequest request ) ;

		public abstract void UpdateAuction ( AuctionRequest request , Player buyer , long priceRised ) ;

		public abstract void ShowDice ( DiceType diceType , int value ) ;

		public void RiseAuctionPrice ( AuctionRequest request , long priceRised ) { }

		public abstract void ShowAuctionResult ( AuctionRequest request , AuctionResult result ) ;

		public abstract PlayerConsoleAbility GetAbility ( ) ;

		public event EventHandler Disconntcted ;

		//Todo:这点事件得慢慢生成啊
		//public event EventHandler<>

		public void SmallGameResult ( SmallGameResult result ) { }

		public void ApplyPlayerCommand ( PlayerCommand command , ArgumentsContainer arguments ) { }

		public void SendChatMessage ( string message ) { }

	}

	public class PlayerConsoleAbility
	{

		public Version SupportVersion { get ; }

		public List <(Guid , Version)> SupportMod { get ; } = new List <(Guid , Version)> ( ) ;

		public List <MapObjectType> SupportedMapObjectTypes { get ; } = new List <MapObjectType> ( ) ;

		public List <CardType> SupportedCardTypes { get ; } = new List <CardType> ( ) ;

		public List <SmallGameType> SupportSmallGameType { get ; } = new List <SmallGameType> ( ) ;

		//public List<>

	}

}
