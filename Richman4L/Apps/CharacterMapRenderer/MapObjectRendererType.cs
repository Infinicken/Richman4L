using System;

using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . App . CharacterMapRenderer
{

	public class MapObjectRendererType
	{

		[NotNull]
		public Type EntryType { get; }

		[NotNull]
		public Type TargetType { get; }

		internal MapObjectRendererType ( [NotNull] Type entryType , [NotNull] Type targetType )
		{
			if ( entryType == null )
			{
				throw new ArgumentNullException ( nameof ( entryType ) );
			}
			if ( targetType == null )
			{
				throw new ArgumentNullException ( nameof ( targetType ) );
			}

			EntryType = entryType;
			TargetType = targetType;
		}

	}

}