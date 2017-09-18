using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

using WenceyWang . Richman4L . Logics . Calendars ;

namespace WenceyWang . Richman4L . Logics . Players . PayReasons
{

	/// <summary>
	///     要钱的理由
	/// </summary>
	public abstract class PayMoneyReason : NeedRegisBase <PayMoneyReasonType , PayMoneyReasonAttribute , PayMoneyReason>
	{

		public abstract string Reason { get ; }

		public long Amount { get ; }

		public WithAssetObject Target { get ; }

		protected PayMoneyReason ( long amount , [NotNull] WithAssetObject target )
		{
			if ( amount <= 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof(amount) ) ;
			}

			Amount = amount ;
			Target = target ?? throw new ArgumentNullException ( nameof(target) ) ;
		}

		public override void EndToday ( ) { }

		public override void StartDay ( GameDate nextDate ) { }

	}

	public class PayMoneyReasonAttribute : NeedRegisAttributeBase
	{

	}

	[PublicAPI]
	public class PayMoneyReasonType : RegisType <PayMoneyReasonType , PayMoneyReasonAttribute , PayMoneyReason>
	{

		public PayMoneyReasonType ( [NotNull] Type entryType , [NotNull] XElement element ) : base ( entryType , element ) { }

		public PayMoneyReasonType ( [NotNull] Type entryType ) : base ( entryType ) { }

	}

}
