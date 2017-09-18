using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics
{

	/// <summary>
	///     指示游戏的状态
	/// </summary>
	public enum GameStatus
	{

		/// <summary>
		///     游戏还没被初始化
		/// </summary>
		NotInitialize ,

		/// <summary>
		///     游戏还没开始
		/// </summary>
		NotStart ,

		/// <summary>
		///     游戏正在进行
		/// </summary>
		Playing ,

		/// <summary>
		///     游戏已经结束而未被清理
		/// </summary>
		Over ,

		/// <summary>
		///     游戏已经被清理
		/// </summary>
		Disposed

	}

}
