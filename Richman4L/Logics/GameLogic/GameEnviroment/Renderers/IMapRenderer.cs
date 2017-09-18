using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Maps ;

namespace WenceyWang . Richman4L . Logics . GameEnviroment . Renderers
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
