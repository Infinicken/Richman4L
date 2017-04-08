using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L
{

	public class VersusWinningCondition : WinningCondition
	{

		public List <WinningCondition> Conditions { get ; } = new List <WinningCondition> ( ) ;

		public override bool IsWin ( Player player )
		{
			return Conditions . All ( condition => condition . IsWin ( player ) ) ;
		}

	}

}
