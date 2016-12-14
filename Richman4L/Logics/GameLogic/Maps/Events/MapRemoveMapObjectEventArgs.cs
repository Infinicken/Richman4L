using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Properties ;

namespace WenceyWang . Richman4L . Maps .Events
{

	public class MapRemoveMapObjectEventArgs : EventArgs
	{

		[NotNull]
		public MapObject PastObject { get ; }

		public MapRemoveMapObjectEventArgs ( [NotNull] MapObject pastObject )
		{
			if ( pastObject == null )
			{
				throw new ArgumentNullException ( nameof ( pastObject ) ) ;
			}

			PastObject = pastObject ;
		}

	}

}
