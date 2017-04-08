using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Annotations ;

namespace WenceyWang . Richman4L . Maps . Events
{

	public class MapAddMapObjectEventArgs : EventArgs
	{

		[NotNull]
		public MapObject NewObject { get ; }

		public MapAddMapObjectEventArgs ( [NotNull] MapObject newObject )
		{
			if ( newObject == null )
			{
				throw new ArgumentNullException ( nameof(newObject) ) ;
			}

			NewObject = newObject ;
		}

	}

}
