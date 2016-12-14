using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Buffs . StockBuffs ;
using WenceyWang . Richman4L . Stocks ;
using WenceyWang . Richman4L . Weathers ;

namespace WenceyWang . Richman4L .Cards
{

	[Card]
	public class BlackCard : Card
	{

		public override int PriceWhenBuy
		{
			get { throw new NotImplementedException ( ) ; }
			set { throw new NotImplementedException ( ) ; }
		}

		public override int PriceWhenSell
		{
			get { throw new NotImplementedException ( ) ; }
			set { throw new NotImplementedException ( ) ; }
		}


		public override bool CanUse ( Weather weather ) { throw new NotImplementedException ( ) ; }

		public override void Use ( )
		{
			Stock toUse = Owner . Console . StockPicker ( ) ;

			BlackBuff buff = new BlackBuff ( toUse , 3 ) ;
		}

	}

}
