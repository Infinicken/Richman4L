using System ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Calendars ;

namespace WenceyWang . Richman4L . Players . PayReasons
{

	public class PayReason : NeedRegisTypeBase <PayReasonType , PayReasonAttribute , PayReason>
	{

		public string Reason { get ; }

		public PayReason ( long money ) { }

		protected PayReason ( ) { }

		public override void EndToday ( ) { throw new NotImplementedException ( ) ; }

		public override void StartDay ( GameDate nextDate ) { throw new NotImplementedException ( ) ; }

	}

	public class PayReasonAttribute : Attribute
	{

	}

	public class PayReasonType : RegisterableTypeBase <PayReasonType , PayReasonAttribute , PayReason>
	{

		public PayReasonType ( [NotNull] Type entryType , [NotNull] XElement element ) : base ( entryType , element ) { }

		public PayReasonType ( [NotNull] Type entryType , [NotNull] string name , [NotNull] string introduction ) : base (
			entryType ,
			name ,
			introduction )
		{
		}

	}

}
