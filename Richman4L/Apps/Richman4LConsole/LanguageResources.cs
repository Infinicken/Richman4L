using System ;
using System . Collections . Generic ;
using System . IO ;
using System . Linq ;
using System . Reflection ;

namespace WenceyWang . Richman4L . Apps . Console
{

	public class LanguageResources
	{

		public string LicenseFileNotFound { get ; }

		public string SettingFileNotFound { get ; }

		public string LoadingComplete { get ; }

		public static LanguageResources LoadFromFile ( Stream stream )
		{
			LanguageResources languageResources = new LanguageResources ( ) ;

			StreamReader reader = new StreamReader ( stream ) ;

			while ( ! reader . EndOfStream )
			{
				string line = reader . ReadLine ( ) ;

				if ( ! string . IsNullOrWhiteSpace ( line ) &&
					! line . StartsWith ( "#" ) )
				{
					string [ ] setCommand = line . Split ( '=' ) ;

					PropertyInfo property = languageResources . GetType ( ) .
																GetProperty ( setCommand [ 0 ] . Trim ( ) , BindingFlags . IgnoreCase ) ;
					object value = Convert . ChangeType ( setCommand [ 1 ] . Trim ( ) , property . PropertyType ) ;

					property . SetValue ( languageResources , value ) ;
				}
			}

			return languageResources ;
		}

	}

}
