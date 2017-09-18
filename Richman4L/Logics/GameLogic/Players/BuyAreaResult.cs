using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Maps ;

namespace WenceyWang . Richman4L . Logics . Players
{

	public class BuyAreaResult
	{

		public Area Area { get ; set ; }

		public long CostMoney { get ; set ; }

		public BuyAreaStatusCode ? StatusCode { get ; set ; }

		public static BuyAreaResult Crate ( Area area )
		{
			return new BuyAreaResult { Area = area , CostMoney = 0 , StatusCode = null } ;
		}

	}

	/// <summary>
	///     表示Player购买区域的结果
	/// </summary>
	public enum BuyAreaStatusCode
	{

		Success = 0 ,

		MoneyNotEnough ,

		PlayerDebuff ,

		AreaDebuff ,

		NotBuyable

	}

}
