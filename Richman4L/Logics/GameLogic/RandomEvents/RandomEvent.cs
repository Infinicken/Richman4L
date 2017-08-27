using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . RandomEvents
{

	/// <summary>
	///     表示随机事件
	/// </summary>
	public abstract class RandomEvent : GameObject
	{

		/// <summary>
		///     表示事件每天发生的概率，概率为这个数值的1/10000。
		/// </summary>
		public virtual int Possibility { get ; set ; } = 0 ;

		/// <summary>
		///     表示事件能否发生
		/// </summary>
		public abstract bool CanInvoke { get ; }

		/// <summary>
		///     事件发生
		/// </summary>
		public abstract void Invoke ( ) ;

	}

}
