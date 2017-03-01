using System ;
using System . Collections ;
using System . Collections . ObjectModel ;
using System . Linq ;
using System . Net . Sockets ;

using WenceyWang . Richman4L . Cards ;
using WenceyWang . Richman4L . GameEnviroment ;
using WenceyWang . Richman4L . InfomationCenter ;
using WenceyWang . Richman4L . Interoperability . Arguments ;
using WenceyWang . Richman4L . Players ;
using WenceyWang . Richman4L . Players . Models ;

namespace WenceyWang . Richman4L .RemoteClient
{

	public class RemoteClient : PlayerConsole
	{

		public TcpClient Client = new TcpClient ( ) ;

		public override object Picker ( ArgumentInfo info ) { throw new NotImplementedException ( ) ; }

		public override void ShowDice ( DiceType diceType , int number ) { throw new NotImplementedException ( ) ; }

		public override void ShowEvent ( Event @event ) { throw new NotImplementedException ( ) ; }

		public override void PlayerSay ( Player player , PlayerSaying saying ) { throw new NotImplementedException ( ) ; }

		public override void ShowFlag ( bool flaged ) { throw new NotImplementedException ( ) ; }

		public override ReadOnlyCollection <CardType> CardStore ( Player player , ReadOnlyCollection <CardType> canBuy )
		{
			throw new NotImplementedException ( ) ;
		}

	}

}
