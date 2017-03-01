using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Maps ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang .Richman4L
{

	public class CashMoreThanCondition : WinningCondition
	{

		public long MoneyLimit { get ; }

		public override bool IsWin ( Player player ) { return player . Money >= MoneyLimit ; }

	}

	public class StayInAreaCondition : WinningCondition
	{

		public MapArea Area { get ; }

		public StayInAreaCondition ( MapArea area ) { Area = area ; }

		public override bool IsWin ( Player player ) { throw new NotImplementedException ( ) ; }

	}

	public class OrWinningCondition : WinningCondition
	{

		public List <WinningCondition> Conditions { get ; } = new List <WinningCondition> ( ) ;

		public override bool IsWin ( Player player )
		{
			return Conditions . Any ( condition => condition . IsWin ( player ) ) ;
		}

	}

	public class AndWinningCondition : WinningCondition
	{

		public List <WinningCondition> Conditions { get ; } = new List <WinningCondition> ( ) ;

		public override bool IsWin ( Player player )
		{
			return Conditions . All ( condition => condition . IsWin ( player ) ) ;
		}

	}

}
