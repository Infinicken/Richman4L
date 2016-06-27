using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;
using System . Collections . ObjectModel;
using System . Xml . Linq;

namespace WenceyWang . Richman4L . Calendars
{
	public class CalendarEvent : GameObject
	{
		public string Title { get; set; } = null;

		public string Text { get; set; } = null;

		public GameDate Date { get; set; }

		public List<Players . Player> GainedPlayer { get; set; } = new List<Players . Player> ( );

		public List<Players . Player> HarmedPlayer { get; set; } = new List<Players . Player> ( );

		//public static implicit operator CalendarEvent ( string text )
		//{
		//	return new CalendarEvent ( text );
		//}

		public static CalendarEvent FromString ( string str )
		{
			return new CalendarEvent ( str );
		}


		public CalendarEvent ( string text , string title = null , Players . Player gainedPlayer = null , Players . Player harmedPlayer = null )
		{
			if ( text == null )
			{
				throw new ArgumentNullException ( nameof ( text ) );
			}
			
			Text = text;
			Title = title;
			GainedPlayer . Add ( gainedPlayer );
			HarmedPlayer . Add ( harmedPlayer );
		}

		public override void StartDay ( GameDate nextDate )
		{

		}

		public override void EndToday ( )
		{
			throw new NotImplementedException ( );
		}
	}
}
