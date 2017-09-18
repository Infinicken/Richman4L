using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Runtime . InteropServices ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Logics . Players ;

namespace WenceyWang . Richman4L . Logics . Maps . Roads
{

	[MapObject]
	[Guid ( "6B4988D8-EBD5-471A-B22D-FFA94C997ECA" )]
	public class AreaRoad : NormalRoad
	{

		[Own]
		public BlockAzimuth AreaAzimuth => this . GetAzimuth ( Area ) ;

		public AreaRoad ( XElement resource ) : base ( resource )
		{
			try
			{
				_areaId = ReadNecessaryValue <long> ( resource , nameof(Area) ) ;
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof(resource)} has wrong data or lack of data" , e ) ;
			}
		}

		public override void Stay ( Player player , MoveType moveType )
		{
			Area ? . Stay ( player ) ;
			base . Stay ( player , moveType ) ;
		}

		public override void Pass ( Player player , MoveType moveType )
		{
			Area ? . Pass ( player ) ;
			base . Pass ( player , moveType ) ;
		}

		#region Area

		private Area _area ;

		private long _areaId ;

		public Area Area
		{
			get => _area ?? ( _area = Map . Currnet . GetArea ( _areaId ) ) ;
			set
			{
				_areaId = value . Id ;
				_area = value ;
			}
		}

		#endregion

	}

}
