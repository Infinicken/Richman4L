using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;

namespace WenceyWang . Richman4L . Cards
{

	[PublicAPI]
	public sealed class CardType : RegisType <CardType , CardAttribute , Card>
	{

		public CardType ( [NotNull] Type entryType , [NotNull] XElement element ) : base ( entryType , element ) { }

		public CardType ( [NotNull] Type entryType , [NotNull] string name , [NotNull] string introduction ) :
			base ( entryType , name , introduction )
		{
		}

	}

}
