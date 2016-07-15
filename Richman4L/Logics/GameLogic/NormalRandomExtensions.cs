using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace WenceyWang . Richman4L
{
	public static class NormalRandomExtensions
	{
		private static double Normal ( double x , double miu , double sigma )
		{
			return 1.0 / Math . Sqrt ( 2 * Math . PI * sigma ) * Math . Exp ( -1 * ( x - miu ) * ( x - miu ) / ( 2 * sigma * sigma ) );
		}

		/// <summary>
		/// 返回一个满足正态分布的随机浮点数
		/// </summary>
		/// <param name="random">随机数生成器</param>
		/// <param name="miu">数值的均值（数学期望）</param>
		/// <param name="sigma">数值的标准差</param>
		/// <param name="minValue">允许的最小值</param>
		/// <param name="maxValue">允许的最大值</param>
		/// <returns>生成的随机数</returns>
		/// <exception cref="ArgumentNullException">random 为 null</exception>
		/// <exception cref="ArgumentOutOfRangeException">sigma小于0 - 或 - minValue大于maxValue</exception>
		public static double NextNormalDouble ( this Random random , double miu , double sigma , double minValue , double maxValue )
		{
			if ( random == null )
			{
				throw new ArgumentNullException ( nameof ( random ) );
			}
			if ( sigma < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( sigma ) );
			}
			if ( minValue > maxValue )
			{
				throw new ArgumentOutOfRangeException ( nameof ( maxValue ) );
			}
			double x;
			double dScope;
			double y;
			do
			{
				x = minValue + random . NextDouble ( ) * ( maxValue - minValue );
				y = Normal ( x , miu , sigma );
				dScope = random . NextDouble ( ) * Normal ( miu , miu , sigma );
			} while ( dScope > y );
			return x;
		}

		/// <summary>
		/// 返回一个满足正态分布的随机整数
		/// </summary>
		/// <param name="random">随机数生成器</param>
		/// <param name="miu">数值的均值（数学期望）</param>
		/// <param name="sigma">数值的标准差</param>
		/// <param name="minValue">允许的最小值</param>
		/// <param name="maxValue">允许的最大值</param>
		/// <returns>生成的随机数</returns>
		/// <exception cref="ArgumentNullException">random 为 null</exception>
		/// <exception cref="ArgumentOutOfRangeException">sigma小于0 - 或 - minValue大于maxValue</exception>
		public static int NextNormal ( this Random random , double miu , double sigma , int minValue , int maxValue )
		{
			if ( random == null )
			{
				throw new ArgumentNullException ( nameof ( random ) );
			}
			if ( sigma < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( sigma ) );
			}
			if ( minValue > maxValue )
			{
				throw new ArgumentOutOfRangeException ( nameof ( maxValue ) );
			}
			double x;
			double dScope;
			double y;
			do
			{
				x = minValue + random . NextDouble ( ) * ( maxValue - minValue );
				y = Normal ( x , miu , sigma );
				dScope = random . NextDouble ( ) * Normal ( miu , miu , sigma );
			} while ( dScope > y );
			return Convert . ToInt32 ( x );
		}
	}

}
