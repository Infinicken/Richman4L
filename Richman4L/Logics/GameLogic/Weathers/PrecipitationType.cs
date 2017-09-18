using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics . Weathers
{

	/// <summary>
	///     表示降水的类型
	/// </summary>
	[Flags]
	public enum PrecipitationType
	{

		/// <summary>
		///     不降水
		/// </summary>
		None = 0x0 ,

		/// <summary>
		///     下雨，可能的温度-5s-25
		/// </summary>
		Rainy = 0x1 ,

		/// <summary>
		///     雾，影响移动
		/// </summary>
		Fog = 0x2 ,

		/// <summary>
		///     下雪，可能的温度-20-5
		/// </summary>
		Snowy = 0x4 ,

		/// <summary>
		///     雨夹雪
		/// </summary>
		Sleet = Rainy | Snowy

		//Todo:雾雨

		//todo:

	}

}
