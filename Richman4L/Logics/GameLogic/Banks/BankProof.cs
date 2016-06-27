using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

namespace WenceyWang . Richman4L . Banks
{
	/// <summary>
	/// 银行的凭据
	/// </summary>
	public abstract class BankProof : GameObject
	{
		/// <summary>
		/// 凭据的开始日期
		/// </summary>
		public Calendars . GameDate StartDate { get; set; }

		/// <summary>
		/// 凭据的结束日期
		/// </summary>
		public Calendars . GameDate EndDate { get; set; }

		/// <summary>
		/// 凭据持续的时间
		/// </summary>
		public long DueTime => EndDate - StartDate ;

		/// <summary>
		/// 凭据的所有者
		/// </summary>
		public Players . Player Owner { get; set; }

	}
}
