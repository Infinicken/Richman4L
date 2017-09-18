using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

using WenceyWang . Richman4L . Logics . Calendars ;
using WenceyWang . Richman4L . Logics . GameEnviroment ;

namespace WenceyWang . Richman4L . Logics . Maps
{

	/// <summary>
	///     表示区块，区块会计算积水
	/// </summary>
	public abstract class Block : MapObject
	{

		/// <summary>
		///     Represent the difficulty of crossing this block
		/// </summary>
		[Own]
		public abstract GameValue CrossDifficulty { get ; }

		public long Id => Position . ContorId ;

		public override MapArea TakeUpArea => new RectangleMapArea ( Position , Size ) ;

		/// <summary>
		///     表示当前区块的积水量
		/// </summary>
		[Own]
		public virtual int PondingAmount { get ; set ; }

		/// <summary>
		///     表示每天能够减少的积水量
		/// </summary>
		[Own]
		public abstract int PondingDecrease { get ; }

		/// <summary>
		///     指示当前块是否覆盖了水
		/// </summary>
		[Own]
		public bool IsWet => PondingAmount != 0 ;

		/// <summary>
		///     指示可燃性
		/// </summary>
		[Own]
		public abstract GameValue Flammability { get ; }

		/// <summary>
		///     指示当前的火焰强度
		/// </summary>
		[Own]
		public int FlameStrength { get ; set ; }

		/// <summary>
		///     指示没有被燃烧的比率
		/// </summary>
		[Own]
		public GameValue UnburnedRatio
		{
			get
			{
				if ( CombustibleMaterialAmount == 0 )
				{
					return GameValue . MaxValue ;
				}

				return ( GameValue ) ( BurnedAmount / Convert . ToDecimal ( CombustibleMaterialAmount ) ) ;
			}
		}


		/// <summary>
		///     指示当前块的可燃物总量
		/// </summary>
		[Own]
		public abstract int CombustibleMaterialAmount { get ; }

		/// <summary>
		///     指示当前块已经被烧毁的量
		/// </summary>
		[Own]
		public int BurnedAmount { get ; set ; }

		/// <summary>
		///     指示当前块的森林覆盖率
		/// </summary>
		[Own]
		public abstract GameValue ForestCoverRate { get ; set ; }

		/// <summary>
		///     指示当前块是否正在燃烧
		/// </summary>
		[Own]
		public bool IsFiring => FlameStrength != 0 ;

		/// <summary>
		///     指示当前块是否覆盖了冰
		/// </summary>
		[Own]
		public bool IsFrozen => IceThickness != 0 ;

		/// <summary>
		///     指示当前块覆盖冰的厚度
		/// </summary>
		[Own]
		public int IceThickness { get ; protected set ; }

		/// <summary>
		///     指示当前块是否覆盖了雪
		/// </summary>
		[Own]
		public bool IsBearSnow => SnowThickness != 0 ;


		/// <summary>
		///     指示当前块覆盖雪的厚度
		/// </summary>
		[Own]
		public int SnowThickness { get ; protected set ; }

		[GameRuleValue ( 5000 )]
		public GameValue EffectOfPrecipitation { get ; set ; }

		[GameRuleExpression ( "block.Flammability" , typeof ( int ) )]
		public int TodayFlameStrengthIncrease { get ; }

		public Block ( [NotNull] XElement resource ) : base ( resource )
		{
			if ( resource == null )
			{
				throw new ArgumentNullException ( nameof(resource) ) ;
			}
		}

		protected Block ( ) { }

		public override void StartDay ( GameDate thisDate )
		{
			//Todo:更新火焰强度之类的
			//积水量会减少燃烧强度
			if ( IsFiring )
			{
				FlameStrength += Flammability ;

				//降水量造成的影响
				//Todo:改名字以及定义
				int 降水量造成的影响的系数 = 1 ;
				FlameStrength = Math . Max ( FlameStrength - Game . Current . Weather . Precipitation * 降水量造成的影响的系数 , 0 ) ;
			}

			//判断是否扩散


			//风影响扩散而不是强度
		}

		public override void EndToday ( )
		{
			//todo:
			//积水量会增加降雨量的数目
			//可燃物的量减少燃烧强度


			PondingAmount += Game . Current . Weather . Precipitation ;
			int firePoint = FlameStrength ;
			int currentPondignAmount = PondingAmount ;
			PondingAmount = Math . Max ( currentPondignAmount - firePoint , 0 ) ;
			firePoint = Math . Max ( firePoint - currentPondignAmount , 0 ) ;
			BurnedAmount = Math . Min ( firePoint + BurnedAmount , CombustibleMaterialAmount ) ;
		}

	}

	/// <summary>
	///     提供将x,y映射到单个值的方法
	/// </summary>
	public static class CantorPairing
	{

		public static long Calu ( int x , int y ) { return ( x + y ) * ( x + y + 1 ) / 2 + y ; }

		public static (int , int) Calu ( long value )
		{
			decimal w =
				Convert . ToDecimal ( Math . Floor ( ( Math . Sqrt ( Convert . ToDouble ( 8m * value + 1 ) ) - 1 ) / 2 ) ) ;
			decimal t = ( w * w + w ) / 2 ;

			return (Convert . ToInt32 ( w - value + t ) , Convert . ToInt32 ( value - t )) ;
		}

	}

}
