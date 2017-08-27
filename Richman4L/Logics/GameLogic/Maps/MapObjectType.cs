using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;

namespace WenceyWang . Richman4L . Maps
{

	public class MapObjectType : RegisType <MapObjectType , MapObjectAttribute , MapObject>
	{

		[PublicAPI]
		public MapObjectType ( [NotNull] Type entryType , [NotNull] XElement element ) : base ( entryType , element )
		{
		}

		[PublicAPI]
		public MapObjectType ( [NotNull] Type entryType , [NotNull] string name , [NotNull] string introduction ) :
			base ( entryType , name , introduction )
		{
		}

	}

}
