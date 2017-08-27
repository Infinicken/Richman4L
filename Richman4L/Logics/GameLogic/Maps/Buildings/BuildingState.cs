using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Maps . Buildings
{

	/// <summary>
	///     指示建筑的状态
	/// </summary>
	public enum BuildingState
	{

		/// <summary>
		///     建筑正常工作
		/// </summary>
		Working ,

		/// <summary>
		///     建筑被规划但尚未被建造
		/// </summary>
		NotBuild ,

		/// <summary>
		///     建筑正在安装附件
		/// </summary>
		InstallingAccessory ,

		/// <summary>
		///     建筑正在被建造
		/// </summary>
		Building ,

		/// <summary>
		///     建筑正在被升级
		/// </summary>
		Updating ,

		/// <summary>
		///     建筑被关闭
		/// </summary>
		Closed ,

		/// <summary>
		///     建筑被摧毁
		/// </summary>
		Destroyed ,

		/// <summary>
		///     建筑正在从不维护的状态恢复
		/// </summary>
		Restoreing ,

		/// <summary>
		///     建筑正在从被摧毁的状态恢复
		/// </summary>
		Recovering ,

		/// <summary>
		///     建筑由于天气原因无法工作
		/// </summary>
		WeatherAffect ,

		/// <summary>
		///     建筑由于所在区块的原因无法工作
		/// </summary>
		AreaAffect

	}

}
