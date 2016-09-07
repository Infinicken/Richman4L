using System ;

using WenceyWang . Richman4L . Players . Commands . Arguments . DefineDomains ;

namespace WenceyWang . Richman4L . Players . Commands .Arguments
{

	public class PlayerCommandArgumentInfo
	{

		public string Name { get ; }

		public string Introduction { get ; }

		public ArgumentValueType ValueType { get ; }

		public ArgumentValueDefineDomain DefineDomain { get ; }

		public PlayerCommandArgumentInfo ( string name ,
											string introduction ,
											ArgumentValueType valueType ,
											ArgumentValueDefineDomain defineDomain )
		{
			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) ) ;
			}
			if ( introduction == null )
			{
				throw new ArgumentNullException ( nameof ( introduction ) ) ;
			}
			if ( defineDomain == null )
			{
				throw new ArgumentNullException ( nameof ( defineDomain ) ) ;
			}
			if ( ! Enum . IsDefined ( typeof ( ArgumentValueType ) , valueType ) )
			{
				throw new ArgumentOutOfRangeException ( nameof ( valueType ) ,
														"Value should be defined in the ArgumentValueType enum." ) ;
			}

			Name = name ;
			Introduction = introduction ;
			ValueType = valueType ;
			DefineDomain = defineDomain ;
		}

	}

}
