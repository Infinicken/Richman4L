using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L
{

	/// <summary>
	///     表示已经结束的游戏的信息
	/// </summary>
	public sealed class GameResult
	{

		/// <summary>
		///     指示游戏的胜利者
		/// </summary>
		public List <Player> Winers { get ; set ; }

		internal GameResult ( ) { }

		//Todo:添加其他信息

	}

}
