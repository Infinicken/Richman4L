using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace WenceyWang . Richman4L . Calendars
{
	public struct GameDate
	{
		public int Date { get; private set; }

		/// <summary>
		/// 当前的季节
		/// </summary>
		public Seasons . Season Season
		{
			get
			{
				long currentDays = ( Date % ( Game . Current . Calendar . SpringLenth + Game . Current . Calendar . SummerLenth + Game . Current . Calendar . AutumnLenth + Game . Current . Calendar . WinterLenth ) );
				if ( ( currentDays -= Game . Current . Calendar . SpringLenth ) <= 0 )
				{
					return Seasons . Season . Spring;
				}
				if ( ( currentDays -= Game . Current . Calendar . SummerLenth ) <= 0 )
				{
					return Seasons . Season . Summer;
				}
				if ( ( currentDays -= Game . Current . Calendar . AutumnLenth ) <= 0 )
				{
					return Seasons . Season . Autumn;
				}
				if ( ( currentDays -= Game . Current . Calendar . WinterLenth ) <= 0 )
				{
					return Seasons . Season . Winter;
				}
				return Seasons . Season . Winter;
			}
		}

		/// <summary>
		/// 当前季节的天数
		/// </summary>
		public long SeasonProcess
		{
			get
			{
				long currentDays = ( Date % ( Game . Current . Calendar . SpringLenth + Game . Current . Calendar . SummerLenth + Game . Current . Calendar . AutumnLenth + Game . Current . Calendar . WinterLenth ) );
				if ( ( currentDays -= Game . Current . Calendar . SpringLenth ) <= 0 )
				{
					return currentDays;
				}
				if ( ( currentDays -= Game . Current . Calendar . SummerLenth ) <= 0 )
				{
					return currentDays;
				}
				if ( ( currentDays -= Game . Current . Calendar . AutumnLenth ) <= 0 )
				{
					return currentDays;
				}
				if ( ( currentDays -= Game . Current . Calendar . WinterLenth ) <= 0 )
				{
					return currentDays;
				}
				return currentDays;
			}
		}

		/// <summary>
		/// 当前季节的长度
		/// </summary>
		public long SeasonLenth
		{
			get
			{
				long currentDays = ( Date % ( Game . Current . Calendar . SpringLenth + Game . Current . Calendar . SummerLenth + Game . Current . Calendar . AutumnLenth + Game . Current . Calendar . WinterLenth ) );
				if ( ( currentDays -= Game . Current . Calendar . SpringLenth ) <= 0 )
				{
					return Game . Current . Calendar . SpringLenth;
				}
				if ( ( currentDays -= Game . Current . Calendar . SummerLenth ) <= 0 )
				{
					return Game . Current . Calendar . SummerLenth;
				}
				if ( ( currentDays -= Game . Current . Calendar . AutumnLenth ) <= 0 )
				{
					return Game . Current . Calendar . AutumnLenth;
				}
				if ( ( currentDays -= Game . Current . Calendar . WinterLenth ) <= 0 )
				{
					return Game . Current . Calendar . WinterLenth;
				}
				return Game . Current . Calendar . WinterLenth;
			}
		}

		#region 运算符重载

		public override bool Equals ( object obj )
		{
			return obj != null && obj is GameDate && ( ( GameDate ) obj ) . Date == Date;
		}

		public override int GetHashCode ( )
		{
			return Date . GetHashCode ( );
		}

		public static bool operator == ( GameDate date1 , GameDate date2 )
		{
			return date1 . Date == date2 . Date;
		}

		public static bool operator != ( GameDate date1 , GameDate date2 )
		{
			return date1 . Date != date2 . Date;
		}

		public static GameDate operator + ( GameDate date , int day )
		{
			return new GameDate ( date . Date + day );
		}

		public static GameDate operator - ( GameDate date , int day )
		{
			return new GameDate ( date . Date - day );
		}

		public static long operator - ( GameDate date1 , GameDate date2 )
		{
			return date1 . Date - date2 . Date;
		}

		public static bool operator > ( GameDate date1 , GameDate date2 )
		{
			return date1 . Date > date2 . Date;
		}

		public static bool operator < ( GameDate date1 , GameDate date2 )
		{
			return date1 . Date < date2 . Date;
		}

		public static bool operator >= ( GameDate date1 , GameDate date2 )
		{
			return date1 . Date >= date2 . Date;
		}

		public static bool operator <= ( GameDate date1 , GameDate date2 )
		{
			return date1 . Date <= date2 . Date;
		}

		public static int Compare ( GameDate date1 , GameDate date2 )
		{
			return date1 . Date . CompareTo ( date2 . Date );
		}

		#endregion

		public GameDate ( int date )
		{
			Date = date;
		}

	}
}
