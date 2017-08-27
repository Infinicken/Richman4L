using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Players
{

	public static class PlayerException
	{

		public static bool IsMoveTypeAvilibale ( this Player player , MoveType moveType )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}
			if ( ! Enum . IsDefined ( typeof ( MoveType ) , moveType ) )
			{
				throw new ArgumentOutOfRangeException ( nameof(moveType) , "Value should be defined in the MoveType enum." ) ;
			}

			return player . MoveTypeList ? . Contains ( moveType ) ?? false ;
		}

		public static bool IsDiceAviliable ( this Player player , DiceType diceType )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}
			if ( ! Enum . IsDefined ( typeof ( DiceType ) , diceType ) )
			{
				throw new ArgumentOutOfRangeException ( nameof(diceType) , "Value should be defined in the DiceType enum." ) ;
			}

			//todo:
			return player . DiceList . ContainsKey ( diceType ) && player . DiceList [ diceType ] != 0 ;
		}

	}

}
