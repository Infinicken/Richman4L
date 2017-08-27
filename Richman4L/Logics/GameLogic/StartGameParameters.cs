using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . GameEnviroment ;
using WenceyWang . Richman4L . Maps ;
using WenceyWang . Richman4L . Players . Models ;

namespace WenceyWang . Richman4L
{

	public class StartGameParameters
	{

		public long SpringLenth { get ; set ; }

		public long SummerLenth { get ; set ; }

		public long AutumnLenth { get ; set ; }

		public long WinterLenth { get ; set ; }

		public long StartMoney { get ; set ; }

		public long GameTime { get ; set ; }

		public Map Map { get ; set ; }

		public List <Tuple <PlayerModelProxy , PlayerConsole>> PlayerConfig { get ; set ; } =
			new List <Tuple <PlayerModelProxy , PlayerConsole>> ( ) ;

		public WinningCondition WinningCondition { get ; set ; }

		public GameRule EnviromentSetting { get ; set ; }

	}

}
