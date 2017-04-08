using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Stocks ;

namespace WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains
{

	public class StockTransactDefineDomain : ArgumentValueDefineDomain
	{

		public bool Transact { get ; }

		public StockTransactDefineDomain ( bool transact ) { Transact = transact ; }

		public override bool IsValid ( object value )
		{
			try
			{
				return ( ( Stock ) value ) . TransactToday ;
			}
			catch ( Exception )
			{
				return false ;
			}
		}

	}

}
