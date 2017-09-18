using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

using WenceyWang . Richman4L . Logics . Buffs . RoadBuffs ;
using WenceyWang . Richman4L . Logics . Calendars ;
using WenceyWang . Richman4L . Logics . Players ;
using WenceyWang . Richman4L . Logics . Statistics ;

namespace WenceyWang . Richman4L . Logics . Maps . Roads
{

	/// <summary>
	///     代表地图上的道路
	/// </summary>
	public abstract class Road : Block
	{

		[Own]
		public bool BlockMoving => Buffs . Any ( buff => buff . BlockMoving ) ;

		[Own]
		[NotNull]
		public List <RoadBuff> Buffs { get ; } = new List <RoadBuff> ( ) ;

		public override MapSize Size => MapSize . Small ;

		public override int PondingDecrease => 400 ;

		public override GameValue Flammability => 0 ;

		public override int CombustibleMaterialAmount => 0 ;

		public override GameValue ForestCoverRate { get { return 0 ; } set { } }

		public Road ( XElement resource ) : base ( resource ) { }

		public virtual void Pass ( Player player , MoveType moveType )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}

			foreach ( RoadBuff buff in Buffs )
			{
				buff . DoWhenPass ( player , moveType ) ;
			}

			CountPass ( player ) ;
		}

		public virtual void Stay ( Player player , MoveType moveType )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}

			foreach ( RoadBuff buff in Buffs )
			{
				buff . DoWhenStay ( player , moveType ) ;
			}

			CountStay ( player ) ;
		}

		/// <summary>
		///     获取路径的末端和末端之前的路径
		/// </summary>
		/// <param name="previous">前一个路径</param>
		/// <param name="moveCount">能延长的路径长度</param>
		/// <param name="result"></param>
		/// <returns>路径</returns>
		public abstract Path Route ( Road previous , int moveCount , Path result = null ) ;

		/// <summary>
		///     获取能否从某个道路进入这个道路
		/// </summary>
		/// <param name="road">前一个道路</param>
		/// <returns>能否进入</returns>
		public abstract bool CanEnterFrom ( Road road ) ;

		public override void StartDay ( GameDate thisDate ) { }

		public override void EndToday ( ) { }

		/// <summary>
		///     为这个道路增加一个增益
		/// </summary>
		/// <param name="buff">要增加的增益</param>
		public virtual void AddBuff ( RoadBuff buff )
		{
			if ( buff == null )
			{
				throw new ArgumentNullException ( nameof(buff) ) ;
			}

			Buffs . Add ( buff ) ;
		}

		#region Stats

		#region Pass

		public long PassCount { get ; private set ; }

		public List <PlayerCount> PlayerPassCount { get ; } = new List <PlayerCount> ( ) ;

		private void CountPass ( Player player )
		{
			PassCount++ ;
			PlayerCount currentItem = PlayerPassCount . SingleOrDefault ( item => item . Player == player ) ;
			if ( currentItem == null )
			{
				PlayerPassCount . Add ( new PlayerCount ( player ) ) ;
			}
			else
			{
				currentItem . Count++ ;
			}
		}

		#endregion

		#region Stay

		public long StayCount { get ; private set ; }

		public List <PlayerCount> PlayerStayCount { get ; } = new List <PlayerCount> ( ) ;

		private void CountStay ( Player player )
		{
			StayCount++ ;
			PlayerCount currentItem = PlayerStayCount . SingleOrDefault ( item => item . Player == player ) ;
			if ( currentItem == null )
			{
				PlayerStayCount . Add ( new PlayerCount ( player ) ) ;
			}
			else
			{
				currentItem . Count++ ;
			}
		}

		#endregion

		#endregion

	}

}
