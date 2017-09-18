using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Calendars ;
using WenceyWang . Richman4L . Logics . Players ;

namespace WenceyWang . Richman4L . Logics . Banks
{

	/// <summary>
	///     银行的凭据
	/// </summary>
	public abstract class BankProof : GameObject
	{

		/// <summary>
		///     凭据的开始日期
		/// </summary>
		public GameDate StartDate { get ; set ; }

		/// <summary>
		///     凭据的结束日期
		/// </summary>
		public GameDate EndDate { get ; set ; }

		/// <summary>
		///     凭据持续的时间
		/// </summary>
		public long DueTime => EndDate - StartDate ;

		/// <summary>
		///     凭据的所有者
		/// </summary>
		public Player Owner { get ; set ; }

	}

}
