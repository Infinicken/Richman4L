using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . IO ;
using System . Linq ;
using System . Reflection ;

using JetBrains . Annotations ;

using WenceyWang . FIGlet ;

namespace WenceyWang . Richman4L . Apps . Console . Fonts
{

	public static class FontsHelper
	{

		public static FIGletFont LoadFont ( [NotNull] string fontName )
		{
			if ( fontName == null )
			{
				throw new ArgumentNullException ( nameof(fontName) ) ;
			}

			Assembly assembly = typeof ( Program ) . GetTypeInfo ( ) . Assembly ;

			Stream stream =
				assembly . GetManifestResourceStream ( typeof ( Program ) . Namespace + ".Fonts." + fontName + ".flf" ) ;

			if ( stream == null )
			{
				throw new ArgumentException ( @"File not found" , nameof(fontName) ) ;
			}

			return new FIGletFont ( stream ) ;
		}

	}

}
