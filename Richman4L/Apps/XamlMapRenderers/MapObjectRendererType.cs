using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Annotations ;

namespace WenceyWang . Richman4L . Apps . XamlMapRenderers
{

	public class MapObjectRendererType
	{

		[NotNull]
		public Type EntryType { get ; }

		[NotNull]
		public Type TargetType { get ; }

		internal MapObjectRendererType ( [NotNull] Type entryType , [NotNull] Type targetType )
		{
			EntryType = entryType ?? throw new ArgumentNullException ( nameof(entryType) ) ;
			TargetType = targetType ?? throw new ArgumentNullException ( nameof(targetType) ) ;
		}

	}

}
