using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Resources ;

namespace WenceyWang . Richman4L . GameEnviroment
{

	[AttributeUsage ( AttributeTargets . Property )]
	internal sealed class GameRuleValueAttribute : Attribute
	{

		public object DefaultValue { get ; }

		public Type Type { get ; }

		//Todo:Finish resources
		public string Introduction
		{
			get
			{
				if ( IntroductionKey != null )
				{
					return Resource . ResourceManager . GetString ( IntroductionKey , Resource . Culture ) ;
				}
				else
				{
					return null ;
				}
			}
		}

		public string IntroductionKey { get ; }


		public GameRuleValueAttribute ( object defaultValue , Type type = null , string introductionKey = null )
		{
			DefaultValue = defaultValue ;
			Type = type ?? DefaultValue . GetType ( ) ;
			IntroductionKey = introductionKey ;
		}

	}


	[AttributeUsage ( AttributeTargets . Property )]
	internal sealed class GameRuleExpressionAttribute : Attribute
	{

		public Type Type { get ; }

		//Todo:Finish resources
		public string Introduction
		{
			get
			{
				if ( IntroductionKey != null )
				{
					return Resource . ResourceManager . GetString ( IntroductionKey , Resource . Culture ) ;
				}
				else
				{
					return null ;
				}
			}
		}

		public string IntroductionKey { get ; }

		public string DefaultExpression { get ; }


		public GameRuleExpressionAttribute ( string defaultExpression , Type type , string introductionKey = null )
		{
			DefaultExpression = defaultExpression ;
			Type = type ;
			IntroductionKey = introductionKey ;
		}

	}

}
