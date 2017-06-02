using System ;
using System . Collections . Generic ;
using System . Linq ;
using System . Text ;

namespace WenceyWang . Richman4L . Apps . Console
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
			if ( ! Enum . IsDefined ( typeof ( SettingCategory ) , settingCategory ) )
			{
				throw new ArgumentOutOfRangeException ( nameof(settingCategory) ,
														"Value should be defined in the SettingCategory enum." ) ;
			}


			SettingCategory = settingCategory ;
			DisplayName = displayName ?? throw new ArgumentNullException ( nameof(displayName) ) ;
			Introduction = introduction ?? throw new ArgumentNullException ( nameof(introduction) ) ;
			RestartRequired = restartRequired ;
			DefultValue = defultValue ?? throw new ArgumentNullException ( nameof(defultValue) ) ;
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
