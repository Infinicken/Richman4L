using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . IO ;
using System . Linq ;
using System . Reflection ;
using System . Xml . Linq ;

namespace WenceyWang . Richman4L . Apps . Console
{

	public static class ResourceHelper
	{

		public static XDocument LoadXmlDocument ( string fileName )
		{
			if ( fileName == null )
			{
				throw new ArgumentNullException ( nameof(fileName) ) ;
			}

			Assembly assembly = typeof ( Program ) . GetTypeInfo ( ) . Assembly ;

			Stream stream = assembly . GetManifestResourceStream ( typeof ( Program ) . Namespace + "." + fileName ) ;

			if ( stream == null )
			{
				throw new ArgumentException ( @"File not found" , nameof(fileName) ) ;
			}

			StreamReader reader = new StreamReader ( stream ) ;

			XDocument doc = XDocument . Parse ( reader . ReadToEnd ( ) ) ;

			reader . Dispose ( ) ;

			return doc ;
		}

	}

}
