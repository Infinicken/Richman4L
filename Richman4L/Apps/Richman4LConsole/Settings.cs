using System ;
using System . Collections ;
using System . IO ;
using System . Linq ;
using System . Reflection ;
using System . Text ;

namespace WenceyWang . Richman4L . Apps .Console
{

	public class Settings
	{

		[SettingItem ( SettingCategory . General , "Allow random title" , "If true, game title will be a random value." ,
			false , false )]
		public bool AllowRandomTitle { get ; set ; }

		[SettingItem ( SettingCategory . General , "Allow random title root" ,
			"If true, the front part of the game title will be a random value." , false , false )]
		public bool AllowRandomTitleRoot { get ; set ; }

		[SettingItem ( SettingCategory . Display , "Console Width" , "Set the width of the console." , true , 80 )]
		public int ConsoleWidth { get ; set ; }

		[SettingItem ( SettingCategory . Display , "Console Height" , "Set the height of the console." , true , 24 )]
		public int ConsoleHeight { get ; set ; }

		public string Save ( )
		{
			StringBuilder [ ] stringBuilders =
				new StringBuilder[
					Enum . GetValues ( typeof ( SettingCategory ) ) . OfType <SettingCategory> ( ) . Max ( type => ( int ) type ) ] ;

			foreach ( SettingCategory type in Enum . GetValues ( typeof ( SettingCategory ) ) )
			{
				stringBuilders [ ( int ) type ] = new StringBuilder ( ) ;
			}

			foreach ( PropertyInfo property in typeof ( Settings ) . GetProperties ( ) )
			{
				SettingItemAttribute attribute =
					( SettingItemAttribute ) property . GetCustomAttribute ( typeof ( SettingItemAttribute ) ) ;
				int index = ( int ) attribute . SettingCategory ;
				StringBuilder propertyBuilder = stringBuilders [ index ] ;
				propertyBuilder . AppendLine ( attribute . ToString ( ) ) ;
				propertyBuilder . AppendLine ( $"{property . Name} = {property . GetValue ( this )}" ) ;
				propertyBuilder . AppendLine ( ) ;
			}

			StringBuilder builder = new StringBuilder ( ) ;

			for ( int i = 0 ; i < stringBuilders . Length ; i++ )
			{
				builder . AppendLine ( $"##{( SettingCategory ) i}" ) ;
				builder . AppendLine ( ) ;
				builder . AppendLine ( stringBuilders [ i ] . ToString ( ) ) ;
				builder . AppendLine ( ) ;
			}

			return builder . ToString ( ) ;
		}

		public static Settings GenerateNew ( )
		{
			Settings setting = new Settings ( ) ;

			foreach ( PropertyInfo property in typeof ( Settings ) . GetProperties ( ) )
			{
				SettingItemAttribute attribute =
					( SettingItemAttribute ) property . GetCustomAttribute ( typeof ( SettingItemAttribute ) ) ;
				property . SetValue ( setting , attribute . DefultValue ) ;
			}

			return setting ;
		}

		public static Settings Load ( string source )
		{
			Settings settings = new Settings ( ) ;

			foreach (
				string line in source . Split ( new [ ] { Environment . NewLine } , StringSplitOptions . RemoveEmptyEntries ) )
			{
				if ( ! string . IsNullOrWhiteSpace ( line ) &&
					! line . StartsWith ( "#" ) )
				{
					string [ ] setCommand = line . Split ( '=' ) ;

					PropertyInfo property = settings . GetType ( ) .
														GetProperty ( setCommand [ 0 ] . Trim ( ) , BindingFlags . IgnoreCase ) ;
					object value = Convert . ChangeType ( setCommand [ 1 ] . Trim ( ) , property . PropertyType ) ;

					property . SetValue ( settings , value ) ;
				}
			}

			return settings ;
		}

		public static Settings Load ( Stream stream )
		{
			Settings settings = new Settings ( ) ;

			StreamReader reader = new StreamReader ( stream ) ;

			while ( ! reader . EndOfStream )
			{
				string line = reader . ReadLine ( ) ;

				if ( ! string . IsNullOrWhiteSpace ( line ) &&
					! line . StartsWith ( "#" ) )
				{
					string [ ] setCommand = line . Split ( '=' ) ;

					PropertyInfo property = settings . GetType ( ) .
														GetProperty ( setCommand [ 0 ] . Trim ( ) , BindingFlags . IgnoreCase ) ;
					object value = Convert . ChangeType ( setCommand [ 1 ] . Trim ( ) , property . PropertyType ) ;

					property . SetValue ( settings , value ) ;
				}
			}

			reader . Close ( ) ;

			return settings ;
		}

	}

}
