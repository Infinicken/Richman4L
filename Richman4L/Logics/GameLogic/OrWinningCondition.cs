using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Maps ;
using WenceyWang . Richman4L . Logics . Players ;

namespace WenceyWang . Richman4L . Logics
{

	public class CashMoreThanCondition : WinningCondition
	{

		public long MoneyLimit { get ; }

		public CashMoreThanCondition ( long moneyLimit ) { MoneyLimit = moneyLimit ; }

		public override bool IsWin ( Player player ) { return player . Money >= MoneyLimit ; }

	}

	public class StayInAreaCondition : WinningCondition
	{

		public MapArea Area { get ; }

		public StayInAreaCondition ( MapArea area ) { Area = area ; }

		public override bool IsWin ( Player player ) { throw new NotImplementedException ( ) ; }

	}

	public class ExpressionCondition : WinningCondition
	{

		///
		public string Expression { get ; set ; }


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
