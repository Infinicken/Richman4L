using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

namespace WenceyWang . Richman4L . Logics . Players . Models
{

	public class PlayerSaying
	{

		public string Text { get ; }

		public string Expression { get ; }

		public string Player { get ; }

		public PlayerSaying ( XElement element )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof(element) ) ;
			}

			Text = element . Attribute ( nameof(Text) ) . Value ;
			Expression = element . Attribute ( nameof(Expression) ) . Value ;
			Player = element . Attribute ( nameof(Player) ) . Value ;
		}

	}

}
