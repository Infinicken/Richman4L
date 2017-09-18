using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics
{

	/// <summary>
	///     指示骰子的种类
	/// </summary>
	public enum DiceType
	{

		/// <summary>
		///     硬币
		/// </summary>
		D2 = 2 ,

		/// <summary>
		///     正四面体骰子
		/// </summary>
		D4 = 4 ,

		/// <summary>
		///     正六面体骰子
		/// </summary>
		D6 = 6 ,

		/// <summary>
		///     正八面体骰子
		/// </summary>
		D8 = 8 ,

		/// <summary>
		///     十面骰子
		/// </summary>
		D10 = 10 ,

		/// <summary>
		///     正十二面体骰子
		/// </summary>
		D12 = 12 ,

		/// <summary>
		///     正二十面体骰子
		/// </summary>
		D20 = 20 ,

		/// <summary>
		///     二十四面骰子
		/// </summary>
		D24 = 24 ,

		/// <summary>
		///     D100
		/// </summary>
		D100 = 100

	}

}
