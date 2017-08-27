using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Maps . Buildings ;

namespace WenceyWang . Richman4L . Players . PayReasons
{

	[PayMoneyReason]
	public class PayMoneyForBuildBuildingReason : PayMoneyReason
	{

		[NotNull]
		public Building Building { get ; }

		public override string Reason { get ; }

		public PayMoneyForBuildBuildingReason ( [NotNull] Building building , long amount , WithAssetObject target ) :
			base ( amount , target )
		{
			Building = building ?? throw new ArgumentNullException ( nameof(building) ) ;
		}

	}

}
