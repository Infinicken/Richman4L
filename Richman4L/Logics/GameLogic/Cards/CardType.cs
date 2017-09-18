using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

namespace WenceyWang . Richman4L . Logics . Cards
{

	[PublicAPI]
	public sealed class CardType : RegisType <CardType , CardAttribute , Card>
	{

		public CardType ( [NotNull] Type entryType , [NotNull] XElement element ) : base ( entryType , element ) { }

		public CardType ( [NotNull] Type entryType ) : base ( entryType ) { }

	}

}
