using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Runtime . InteropServices ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Logics . Cards ;
using WenceyWang . Richman4L . Logics . Maps . Roads ;
using WenceyWang . Richman4L . Logics . Players ;

namespace WenceyWang . Richman4L . Logics . Maps
{

	[MapObject]
	[Guid ( "0FFBE4CB-F194-4483-B99A-954CA4087786" )]
	public class CardStore : NormalRoad
	{

		public CardStore ( XElement resource ) : base ( resource ) { }


		public override void Stay ( Player player , MoveType moveType )
		{
			//Todo:Make Enviroment Buy Card
			List <CardType> cardCanBuy = new List <CardType> ( ) ;


			base . Stay ( player , moveType ) ;
		}

	}

}
