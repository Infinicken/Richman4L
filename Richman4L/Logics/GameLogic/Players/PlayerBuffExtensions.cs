using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics . Players
{

	public static class PlayerBuffExtensions
	{

		public static bool IsBlockBuyArea ( this Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}

			return player . Buffs . Any ( item => item . BlockBuyArea ) ;
		}

		public static bool IsBlockBuyStock ( this Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}

			return player . Buffs . Any ( item => item . BlockBuyStock ) ;
		}


		public static bool IsBlockGetCharge ( this Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}

			return player . Buffs . Any ( item => item . BlockGetCharge ) ;
		}


		public static bool IsBlockMoving ( this Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}

			return player . Buffs . Any ( item => item . BlockMoving ) ;
		}

		public static bool IsBlockSellStock ( this Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}

			return player . Buffs . Any ( item => item . BlockSellStock ) ;
		}

		public static bool IsFreeOfCharge ( this Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}

			return player . Buffs . Any ( item => item . FreeOfCharge ) ;
		}

	}

}
