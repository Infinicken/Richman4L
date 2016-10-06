using System ;
using System . Collections . Generic ;

using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L .Calendars
{

	public class CalendarEvent : GameObject
	{

		public string Title { get ; set ; }

		public string Text { get ; set ; }

		public GameDate Date { get ; set ; }

		public List < Player > GainedPlayer { get ; set ; } = new List < Player > ( ) ;

		public List < Player > HarmedPlayer { get ; set ; } = new List < Player > ( ) ;

		public CalendarEvent ( string text , string title = null , Player gainedPlayer = null , Player harmedPlayer = null )
		{
			if ( text == null )
			{
				throw new ArgumentNullException ( nameof ( text ) ) ;
			}

			Text = text ;
			Title = title ;
			GainedPlayer . Add ( gainedPlayer ) ;
			HarmedPlayer . Add ( harmedPlayer ) ;
		}

		//public static implicit operator CalendarEvent ( string text )
		//{
		//	return new CalendarEvent ( text );
		//}

		public static CalendarEvent FromString ( string str ) { return new CalendarEvent ( str ) ; }

		public override void StartDay ( GameDate nextDate ) { }

		public override void EndToday ( ) { throw new NotImplementedException ( ) ; }

	}

}
