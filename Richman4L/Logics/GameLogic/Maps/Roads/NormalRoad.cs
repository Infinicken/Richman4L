using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Runtime . InteropServices ;
using System . Xml . Linq ;

using AutoLazy ;

namespace WenceyWang . Richman4L . Logics . Maps . Roads
{

	[MapObject]
	[Guid ( "C4D64F21-315F-4E82-A8A2-DF0F1B2603CE" )]
	public class NormalRoad : Road
	{

		public override GameValue CrossDifficulty => 0 ;

		public NormalRoad ( XElement resource ) : base ( resource )
		{
			try
			{
				XElement entrances = resource . Element ( nameof(Entrances) ) ;

				foreach ( XElement road in entrances . Elements ( ) )
				{
					_entrancesId . Add ( ReadNecessaryValue <long> ( road , nameof(Id) ) ) ;
				}

				XElement exits = resource . Element ( nameof(Exits) ) ;

				foreach ( XElement road in exits . Elements ( ) )
				{
					_exitsId . Add ( ReadNecessaryValue <long> ( road , nameof(Id) ) ) ;
				}
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof(resource)} has wrong data or lack of data" , e ) ;
			}
		}


		public override Path Route ( Road previous , int moveCount , Path result = null )
		{
			if ( previous == null )
			{
				throw new ArgumentNullException ( nameof(previous) ) ;
			}
			if ( ! CanEnterFrom ( previous ) )
			{
				throw new ArgumentException ( $"无法通过{nameof(previous)}进入此道路" , nameof(previous) ) ;
			}
			if ( moveCount < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof(moveCount) ) ;
			}
			if ( ! Exits . Any ( ) )
			{
				throw new InvalidOperationException ( "没有可用的出口" ) ;
			}

			Path current = result ?? new Path ( ) ;
			current . AddRoute ( this ) ;
			if ( BlockMoving || moveCount == 0 )
			{
				return current ;
			}

			List <Road> exits = Exits . Where ( road => road != previous ) . ToList ( ) ;
			if ( exits . Count == 0 )
			{
				return previous . Route ( this , moveCount - 1 , result ) ;
			}

			return exits . RandomItem ( ) . Route ( this , moveCount - 1 , result ) ;
		}

		public override bool CanEnterFrom ( Road road ) { return Entrances . Contains ( road ) ; }

		#region Entrances

		private readonly List <long> _entrancesId = new List <long> ( ) ;

		[Reference]
		[Lazy]
		public virtual List <Road> Entrances
		{
			get { return _entrancesId . Select ( roadId => Map . Currnet . GetRoad ( roadId ) ) . ToList ( ) ; }
		}

		#endregion

		#region Console Attribute

		[Own]
		public bool UpEntrance => Entrances . Any ( road => this . GetAzimuth ( road ) == BlockAzimuth . Up ) ;

		[Own]
		public bool DownEntrance => Entrances . Any ( road => this . GetAzimuth ( road ) == BlockAzimuth . Down ) ;

		[Own]
		public bool LeftEntrance => Entrances . Any ( road => this . GetAzimuth ( road ) == BlockAzimuth . Left ) ;

		[Own]
		public bool RightEntrance => Entrances . Any ( road => this . GetAzimuth ( road ) == BlockAzimuth . Right ) ;

		[Own]
		public bool UpExit => Exits . Any ( road => this . GetAzimuth ( road ) == BlockAzimuth . Up ) ;

		[Own]
		public bool DownExit => Exits . Any ( road => this . GetAzimuth ( road ) == BlockAzimuth . Down ) ;

		[Own]
		public bool LeftExit => Exits . Any ( road => this . GetAzimuth ( road ) == BlockAzimuth . Left ) ;

		[Own]
		public bool RightExit => Exits . Any ( road => this . GetAzimuth ( road ) == BlockAzimuth . Right ) ;

		#endregion

		#region Exits

		private readonly List <long> _exitsId = new List <long> ( ) ;

		//Todo:Add Lazy
		[Reference]
		[Lazy]
		public virtual List <Road> Exits
		{
			get { return _exitsId . Select ( roadId => Map . Currnet . GetRoad ( roadId ) ) . ToList ( ) ; }
		}

		#endregion

	}

}
