using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Players
{

	//Todo:正常的命名
	/// <summary>
	///     指示玩家宣告破产的原因
	/// </summary>
	public enum PlayerBankruptcyReason
	{

		/// <summary>
		///     玩家无法支付应付款
		/// </summary>
		CanNotPay ,

		/// <summary>
		///     玩家丢失了到服务器的连接
		/// </summary>
		LostControl ,

		/// <summary>
		///     玩家触发了破产的剧情或是在游戏中死亡
		/// </summary>
		PlayerLose ,

		/// <summary>
		///     玩家希望结束自己的游戏
		/// </summary>
		BySelf

	}

}
