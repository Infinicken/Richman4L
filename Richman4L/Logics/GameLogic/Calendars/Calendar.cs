using System;
using System . Collections . Generic;
using System . Collections . ObjectModel;
using System . Linq;
using System . Text;
using System . Xml . Linq;

namespace WenceyWang . Richman4L . Calendars
{
	public class Calendar : GameObject
	{
		#region Events

		public ReadOnlyCollection<CalendarEvent> TodayEventList { get; private set; }

		private List<CalendarEvent> todayEventList { get; set; }

		public ReadOnlyCollection<ReadOnlyCollection<CalendarEvent>> EventList { get; }

		private List<ReadOnlyCollection<CalendarEvent>> eventList { get; }

		public ReadOnlyCollection<CalendarEvent> GetEvents ( GameDate date )
		{
			if ( date > Today )
			{
				throw new ArgumentOutOfRangeException ( nameof ( date ) , $"{nameof ( date )} is later than today" );
				//todo:完善这个错误信息
			}
			return EventList [ date . Date - 1 ];
		}

		#endregion

		public ReadOnlyCollection<Weathers . Weather> WeatherList { get; }

		private List<Weathers . Weather> weatherList { get; }


		#region Season Lenth

		public long SpringLenth { get; set; }

		public long SummerLenth { get; set; }

		public long AutumnLenth { get; set; }

		public long WinterLenth { get; set; }

		#endregion

		public GameDate Today { get; set; }

		public void PostEvent ( string text )
		{
			todayEventList . Add ( new CalendarEvent ( text ) );
		}

		public void PostEvent ( string title , string text )
		{
			todayEventList . Add ( new CalendarEvent ( text , title ) );
		}

		public void PostEvent ( string title , string text , Players . Player gainedPlayer , Players . Player harmedPlayer )
		{
			todayEventList . Add ( new CalendarEvent ( text , title , gainedPlayer , harmedPlayer ) );
		}


		public Calendar ( ) : base ( )
		{
			Today = new GameDate ( 1 );
			eventList = new List<ReadOnlyCollection<CalendarEvent>> ( );
			EventList = new ReadOnlyCollection<ReadOnlyCollection<CalendarEvent>> ( eventList );
			weatherList = new List<Weathers . Weather> ( );
			WeatherList = new ReadOnlyCollection<Weathers . Weather> ( weatherList );
		}

		public override void StartDay ( GameDate nextDate )
		{
			if ( nextDate != Today + 1 )
			{
				throw new ArgumentException ( $"{nameof ( nextDate )} is not the day after yesterday" ) ;
			}
			Today += 1;
			todayEventList = new List < CalendarEvent > ( ) ;
			TodayEventList = new ReadOnlyCollection < CalendarEvent > ( todayEventList ) ;
			eventList . Add ( TodayEventList ) ;
		}

		public override void EndToday ( )
		{
			todayEventList = null;
			TodayEventList = null ;
		}
	}
}
