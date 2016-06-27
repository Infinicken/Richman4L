using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace WenceyWang . Richman4L
{
	/// <summary>
	/// 指示游戏的状态
	/// </summary>
	public enum GameStatus
	{

		/// <summary>
		/// 游戏还没开始
		/// </summary>
		NotStart,
		/// <summary>
		/// 游戏正在进行
		/// </summary>
		Playing,
		/// <summary>
		/// 游戏已经结束
		/// </summary>
		Over,
	}
}
