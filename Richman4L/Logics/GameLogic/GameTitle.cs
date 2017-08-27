using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics ;
using System . Linq ;
using System . Xml . Linq ;

namespace WenceyWang . Richman4L
{

	public struct GameTitle
	{

		public static GameTitle Defult => new GameTitle ( DefaultTitleRoot , DefaultTitleKey ) ;

		public string TitleRoot { get ; }

		public string TitleKey { get ; }

		public string Content => $"{TitleRoot}4{TitleKey}" ;

		public string ContentWithSpace => $"{TitleRoot} 4 {TitleKey}" ;

		public override string ToString ( ) { return Content ; }

		public static implicit operator GameTitle ( string text )
		{
			string [ ] temp = text . Split ( '4' ) ;
			return new GameTitle ( temp . First ( ) , temp . Last ( ) ) ;
		}

		private GameTitle ( string titleRoot , string titleKey )
		{
			TitleRoot = titleRoot ;
			TitleKey = titleKey ;
		}

		private static List <string> TitleRoots { get ; set ; }

		private static List <string> TitleKeys { get ; set ; }

		private static bool Loaded { get ; set ; }

		public static string DefaultTitleRoot => @"Richman" ;

		public static string DefaultTitleKey => @"L" ;

		public static void AddTitleRoot ( string titleRoot )
		{
			if ( titleRoot == null )
			{
				throw new ArgumentNullException ( nameof(titleRoot) ) ;
			}

			if ( TitleRoots . Contains ( titleRoot ) )
			{
				return ;
			}

			TitleRoots . Add ( titleRoot ) ;
		}

		public static void AddTitleKey ( ) { }

		public static GameTitle GetTitle ( bool randomTitleRoot )
		{
			if ( ! Loaded )
			{
				LoadTitles ( ) ;
			}

			if ( randomTitleRoot )
			{
				return new GameTitle ( TitleRoots . RandomItem ( GameRandom . Current ) ,
										TitleKeys . RandomItem ( GameRandom . Current ) ) ;
			}

			return new GameTitle ( DefaultTitleRoot , TitleKeys . RandomItem ( GameRandom . Current ) ) ;
		}

		public bool Equals ( GameTitle other )
		{
			return string . Equals ( TitleRoot , other . TitleRoot ) && string . Equals ( TitleKey , other . TitleKey ) ;
		}

		public override bool Equals ( object obj )
		{
			if ( ReferenceEquals ( null , obj ) )
			{
				return false ;
			}

			return obj is GameTitle && Equals ( ( GameTitle ) obj ) ;
		}

		public override int GetHashCode ( )
		{
			unchecked
			{
				return ( ( TitleRoot ? . GetHashCode ( ) ?? 0 ) * 397 ) ^ ( TitleKey ? . GetHashCode ( ) ?? 0 ) ;
			}
		}

		public static bool operator == ( GameTitle left , GameTitle right ) { return left . Equals ( right ) ; }

		public static bool operator != ( GameTitle left , GameTitle right ) { return ! left . Equals ( right ) ; }

		private static object Locker { get ; } = new object ( ) ;

		[Startup]
		public static void LoadTitles ( )
		{
			lock ( Locker )
			{
				if ( Loaded )
				{
					return ;
				}

				TitleRoots = new List <string> ( ) ;
				TitleKeys = new List <string> ( ) ;

				XDocument doc = ResourceHelper . LoadXmlDocument ( $"{nameof(GameTitle)}Resources.xml" ) ;

				Debug . Assert ( doc . Root != null , "doc . Root != null" ) ;

				//Let resource file error throw

				// ReSharper disable once PossibleNullReferenceException
				foreach ( XElement item in doc . Root . Element ( nameof(TitleRoots) ) . Elements ( ) )
				{
					TitleRoots . Add ( item . Attribute ( nameof(Content) ) . Value ) ;
				}

				// ReSharper disable once PossibleNullReferenceException
				foreach ( XElement item in doc . Root . Element ( nameof(TitleKeys) ) . Elements ( ) )
				{
					TitleKeys . Add ( item . Attribute ( nameof(Content) ) . Value ) ;
				}

				Loaded = true ;
			}
		}

	}

}
