using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics . Players
{

	/// <summary>
	///     指示玩家的移动类型
	/// </summary>
	public enum MoveType
	{

		/// <summary>
		///     步行，使用一颗骰子
		/// </summary>
		Walk = 1 ,

		/// <summary>
		///     骑自行车，使用两颗骰子
		/// </summary>
		RidingBicycle = 2 ,

		/// <summary>
		///     骑机车，使用三颗骰子
		/// </summary>
		RidingMotorcycle = 3 ,

		//todo:是否简化？

		/// <summary>
		///     驾驶汽车，使用四颗骰子
		/// </summary>
		DrivingCar = 4

	}

}
