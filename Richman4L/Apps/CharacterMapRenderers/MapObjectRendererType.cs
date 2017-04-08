using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Annotations ;

namespace WenceyWang . Richman4L . Apps . CharacterMapRenderers
{

	public class MapObjectRendererType
	{

		[NotNull]
		public Type EntryType { get ; }

		[NotNull]
		public Type TargetType { get ; }

		internal MapObjectRendererType ( [NotNull] Type entryType , [NotNull] Type targetType )
		{
			if ( entryType == null )
			{
				throw new ArgumentNullException ( nameof(entryType) ) ;
			}
			if ( targetType == null )
			{
				throw new ArgumentNullException ( nameof(targetType) ) ;
			}

			EntryType = entryType ;
			TargetType = targetType ;
		}

	}

}
