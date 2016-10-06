using System ;
using System . Collections . Generic ;
using System . Collections . ObjectModel ;

using WenceyWang . Richman4L . Players ;
using WenceyWang . Richman4L . Weathers ;

namespace WenceyWang . Richman4L .Calendars
{

	public class Calendar : GameObject
	{

		public ReadOnlyCollection < Weather > WeatherList { get ; }

		private List < Weather > weatherList { get ; }

		public GameDate Today { get ; set ; }

		public Calendar ( )
		{
			Today = new GameDate ( 1 ) ;
			eventList = new List < ReadOnlyCollection < CalendarEvent > > ( ) ;
			EventList = new ReadOnlyCollection < ReadOnlyCollection < CalendarEvent > > ( eventList ) ;
			weatherList = new List < Weather > ( ) ;
			WeatherList = new ReadOnlyCollection < Weather > ( weatherList ) ;
		}

		public void PostEvent ( string text ) { todayEventList . Add ( new CalendarEvent ( text ) ) ; }

		public void PostEvent ( string title , string text ) { todayEventList . Add ( new CalendarEvent ( text , title ) ) ; }

		public void PostEvent ( string title , string text , Player gainedPlayer , Player harmedPlayer )
		{
			todayEventList . Add ( new CalendarEvent ( text , title , gainedPlayer , harmedPlayer ) ) ;
		}

		public override void StartDay ( GameDate nextDate )
		{
			if ( nextDate != Today + 1 )
			{
				throw new ArgumentException ( $"{nameof ( nextDate )} is not the day after yesterday" ) ;
			}

			Today += 1 ;
			todayEventList = new List < CalendarEvent > ( ) ;
			TodayEventList = new ReadOnlyCollection < CalendarEvent > ( todayEventList ) ;
			eventList . Add ( TodayEventList ) ;
		}

		public override void EndToday ( )
		{
			todayEventList = null ;
			TodayEventList = null ;
		}

		#region Events

		public ReadOnlyCollection < CalendarEvent > TodayEventList { get ; private set ; }

		private List < CalendarEvent > todayEventList { get ; set ; }

		public ReadOnlyCollection < ReadOnlyCollection < CalendarEvent > > EventList { get ; }

		private List < ReadOnlyCollection < CalendarEvent > > eventList { get ; }

		public ReadOnlyCollection < CalendarEvent > GetEvents ( GameDate date )
		{
			if ( date > Today )
			{
				throw new ArgumentOutOfRangeException ( nameof ( date ) , $"{nameof ( date )} is later than today" ) ;
			}

			return EventList [ date . Date - 1 ] ;
		}

		#endregion

		#region Season Lenth

		public long SpringLenth { get ; set ; }

		public long SummerLenth { get ; set ; }

		public long AutumnLenth { get ; set ; }

		public long WinterLenth { get ; set ; }

		#endregion
	}

}
