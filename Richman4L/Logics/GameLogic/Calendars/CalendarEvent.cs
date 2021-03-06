﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Players ;

namespace WenceyWang . Richman4L . Logics . Calendars
{

	public class CalendarEvent : GameObject
	{

		public string Title { get ; set ; }

		public string Text { get ; set ; }

		public GameDate Date { get ; set ; }

		public List <Player> GainedPlayer { get ; set ; } = new List <Player> ( ) ;

		public List <Player> HarmedPlayer { get ; set ; } = new List <Player> ( ) ;

		public CalendarEvent ( string text , string title = null , Player gainedPlayer = null , Player harmedPlayer = null )
		{
			Text = text ?? throw new ArgumentNullException ( nameof(text) ) ;
			Title = title ;
			GainedPlayer . Add ( gainedPlayer ) ;
			HarmedPlayer . Add ( harmedPlayer ) ;
		}

		//public static implicit operator CalendarEvent ( string text )
		//{
		//	return new CalendarEvent ( text );
		//}

		public static CalendarEvent FromString ( string str ) { return new CalendarEvent ( str ) ; }

		public override void StartDay ( GameDate thisDate ) { }

		public override void EndToday ( ) { throw new NotImplementedException ( ) ; }

	}

}
