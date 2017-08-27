using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Stocks ;

namespace WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains
{

	public class StockTransactDefineDomain : ArgumentValueDefineDomain <Stock>
	{

		public bool Transact { get ; }

		public StockTransactDefineDomain ( bool transact ) { Transact = transact ; }

		public override bool IsValid ( Stock value )
		{
			try
			{
				return value . TransactToday == Transact ;
			}
			catch ( Exception )
			{
				return false ;
			}
		}

	}

}
