using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Calendars ;

namespace WenceyWang . Richman4L . Maps
{

	/// <summary>
	///     表示地图上的装饰
	/// </summary>
	public abstract class Decoration : Block
	{

		public Decoration ( XElement saving ) : base ( saving ) { }

		public override void StartDay ( GameDate thisDate ) { }

	}

}
