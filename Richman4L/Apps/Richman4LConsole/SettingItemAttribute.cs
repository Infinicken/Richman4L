using System ;
using System . ComponentModel ;
using System . Text ;

namespace WenceyWang . Richman4L . Apps .Console
{

	public class SettingItemAttribute : Attribute
	{

		public SettingCategory SettingCategory { get ; set ; }

		public string DisplayName { get ; set ; }

		public string Introduction { get ; set ; }

		public bool RestartRequired { get ; set ; }

		public object DefultValue { get ; set ; }

		public SettingItemAttribute ( SettingCategory settingCategory ,
									string displayName ,
									string introduction ,
									bool restartRequired ,
									object defultValue )
		{
			if ( displayName == null )
			{
				throw new ArgumentNullException ( nameof ( displayName ) ) ;
			}
			if ( introduction == null )
			{
				throw new ArgumentNullException ( nameof ( introduction ) ) ;
			}
			if ( defultValue == null )
			{
				throw new ArgumentNullException ( nameof ( defultValue ) ) ;
			}
			if ( ! Enum . IsDefined ( typeof ( SettingCategory ) , settingCategory ) )
			{
				throw new InvalidEnumArgumentException ( nameof ( settingCategory ) ,
														( int ) settingCategory ,
														typeof ( SettingCategory ) ) ;
			}

			SettingCategory = settingCategory ;
			DisplayName = displayName ;
			Introduction = introduction ;
			RestartRequired = restartRequired ;
			DefultValue = defultValue ;
		}

		public override string ToString ( )
		{
			StringBuilder builder = new StringBuilder ( ) ;
			builder . AppendLine ( $"#{DisplayName}" ) ;
			if ( RestartRequired )
			{
				builder . AppendLine ( $"#{Introduction} This setting will be applied after restart." ) ;
			}
			else
			{
				builder . AppendLine ( $"#{Introduction}" ) ;
			}
			builder . AppendLine ( $"#Defult Value: {Introduction}" ) ;
			return builder . ToString ( ) ;
		}

	}

}
