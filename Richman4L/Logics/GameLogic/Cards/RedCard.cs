using System ;

using WenceyWang . Richman4L . Buffs . StockBuffs ;
using WenceyWang . Richman4L . Stocks ;
using WenceyWang . Richman4L . Weathers ;

namespace WenceyWang . Richman4L .Cards
{

	[ Card ]
	public class RedCard : Card
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

			RedBuff buff = new RedBuff ( toUse , 3 ) ;
		}

	}

}
