using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Logics . Players ;

namespace WenceyWang . Richman4L . Logics
{

	/// <summary>
	///     表示已经结束的游戏的信息
	/// </summary>
	public sealed class GameResult : ISelfSerializeable
	{

		/// <summary>
		///     指示游戏的胜利者
		/// </summary>
		public List <Player> Winers { get ; set ; }

		internal GameResult ( ) { }

		//Todo:添加其他信息

		public XElement ToXElement ( ) { throw new NotImplementedException ( ) ; }

	}

}
