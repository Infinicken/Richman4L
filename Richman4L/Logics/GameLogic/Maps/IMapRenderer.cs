using System ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Maps
{

	/// <summary>
	///     指示地图的绘制器
	/// </summary>
	public interface IMapRenderer
	{

		Map Target { get ; }

		void RendererCatched ( ) ;


		void SetMap ( Map map ) ;

	}

}
