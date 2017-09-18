using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics . Maps
{

	public static class AreaBuffExtensions
	{

		public static bool IsBlockBuild ( this Area area )
		{
			if ( area == null )
			{
				throw new ArgumentNullException ( nameof(area) ) ;
			}

			return area . Buffs . Any ( item => item . BlockBuild ) ;
		}

		public static bool IsBlockBuy ( this Area area )
		{
			if ( area == null )
			{
				throw new ArgumentNullException ( nameof(area) ) ;
			}

			return area . Buffs . Any ( item => item . BlockBuy ) ;
		}

		public static bool IsBlockCharge ( this Area area )
		{
			if ( area == null )
			{
				throw new ArgumentNullException ( nameof(area) ) ;
			}

			return area . Buffs . Any ( item => item . BlockCharge ) ;
		}

	}

}
