using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

namespace WenceyWang . Richman4L . Logics . Maps
{

	public class MapObjectType : RegisType <MapObjectType , MapObjectAttribute , MapObject>
	{

		[PublicAPI]
		public MapObjectType ( [NotNull] Type entryType , [NotNull] XElement element ) : base ( entryType , element )
		{
		}

		[PublicAPI]
		public MapObjectType ( [NotNull] Type entryType ) : base ( entryType )
		{
		}

	}

}
