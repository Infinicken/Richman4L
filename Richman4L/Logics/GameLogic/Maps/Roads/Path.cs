using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Maps . Roads
{

	/// <summary>
	///     指示游戏中由一些道路顺次连接构成的路径
	/// </summary>
	public sealed class Path
	{

		/// <summary>
		///     指示这个路径的末尾
		/// </summary>
		public Road Terminal => Route . Last ( ) ;

		/// <summary>
		///     指示这个路径末尾之前的路径
		/// </summary>
		public Road Penultimate => Route [ Route . Count - 2 ] ;


		/// <summary>
		///     指示整个路径
		/// </summary>
		public List <Road> Route { get ; } = new List <Road> ( ) ;


		/// <summary>
		///     延长这个路径
		/// </summary>
		/// <param name="road">新增的路段</param>
		public void AddRoute ( Road road )
		{
			if ( road == null )
			{
				throw new ArgumentNullException ( nameof(road) ) ;
			}
			if ( ! road . CanEnterFrom ( Terminal ) )
			{
				throw new ArgumentException ( $"{nameof(road)} can not enter from {nameof(Terminal)}" ) ;
			}

			Route . Add ( road ) ;
		}

	}

}
