using System;
using System . IO;
using System . Reflection;
using System . Xml . Linq;

using WenceyWang . FIGlet;

namespace WenceyWang . Richman4L . Apps . Console . Fonts
{

	public static class FontsHelper
	{

		public static FIGletFont LoadFont ( string fontName )
		{
			if ( fontName == null )
			{
				throw new ArgumentNullException ( nameof ( fontName ) );
			}

			Assembly assembly = typeof ( Program ) . GetTypeInfo ( ) . Assembly;

			Stream stream = assembly . GetManifestResourceStream ( typeof ( Program ) . Namespace + ".Fonts." + fontName+".flf" );

			if ( stream == null )
			{
				throw new ArgumentException ( @"File not found" , nameof ( fontName ) );
			}

			return new FIGletFont ( stream );

		}


	}

}
