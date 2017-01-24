using System ;
using System . Collections ;
using System . Linq ;
using System . Runtime . CompilerServices ;

using Windows . UI ;
using Windows . UI . Xaml ;
using Windows . UI . Xaml . Media ;
using Windows . UI . Xaml . Media . Animation ;

namespace WenceyWang . Richman4L . Apps . Uni . UI .XamlResources
{

	public static class Resources
	{

		public static CubicEase EasingFunction => GetValue <CubicEase> ( ) ;

		private static T GetValue <T> ( [CallerMemberName] string propName = "" )
		{
			return ( T ) App . Current . Resources [ propName ] ;
		}

		#region Font

		public static double LargeTitle => GetValue <double> ( ) ;

		public static double SmallTitle => GetValue <double> ( ) ;

		public static double ExtraSmallTitle => GetValue <double> ( ) ;

		public static double BigFontSize => GetValue <double> ( ) ;

		public static double FontSize => GetValue <double> ( ) ;

		public static double SmallFontSize => GetValue <double> ( ) ;

		public static double LineHeight => GetValue <double> ( ) ;

		public static FontFamily Font => GetValue <FontFamily> ( ) ;

		#endregion

		#region Color

		#region Color

		public static Color Black => GetValue <Color> ( ) ;

		public static Color Blue => GetValue <Color> ( ) ;

		public static Color Cyan => GetValue <Color> ( ) ;

		public static Color DarkBlue => GetValue <Color> ( ) ;

		public static Color DarkLime => GetValue <Color> ( ) ;

		public static Color DeepRed => GetValue <Color> ( ) ;

		public static Color LightBlue => GetValue <Color> ( ) ;

		public static Color Lime => GetValue <Color> ( ) ;

		public static Color Pink => GetValue <Color> ( ) ;

		public static Color Purple => GetValue <Color> ( ) ;

		public static Color Transparent => GetValue <Color> ( ) ;

		public static Color TransparentCran => GetValue <Color> ( ) ;

		public static Color TransparentDeepRed => GetValue <Color> ( ) ;

		public static Color White => GetValue <Color> ( ) ;

		#endregion

		#region Brush

		public static SolidColorBrush BlackBrush => GetValue <SolidColorBrush> ( ) ;

		public static SolidColorBrush BlueBrush => GetValue <SolidColorBrush> ( ) ;

		public static SolidColorBrush CyanBrush => GetValue <SolidColorBrush> ( ) ;

		public static SolidColorBrush DarkBlueBrush => GetValue <SolidColorBrush> ( ) ;

		public static SolidColorBrush DarkLimeBrush => GetValue <SolidColorBrush> ( ) ;

		public static SolidColorBrush DeepRedBrush => GetValue <SolidColorBrush> ( ) ;

		public static SolidColorBrush LightBlueBrus => GetValue <SolidColorBrush> ( ) ;

		public static SolidColorBrush LimeBrush => GetValue <SolidColorBrush> ( ) ;

		public static SolidColorBrush PinkBrush => GetValue <SolidColorBrush> ( ) ;

		public static SolidColorBrush PurpleBrush => GetValue <SolidColorBrush> ( ) ;

		public static SolidColorBrush TransparentCranBrush => GetValue <SolidColorBrush> ( ) ;

		public static SolidColorBrush TransparentDeepRedBrush => GetValue <SolidColorBrush> ( ) ;

		public static SolidColorBrush WhiteBrush => GetValue <SolidColorBrush> ( ) ;

		#endregion

		#endregion

		#region Thickness

		public static Thickness ButtonPadding => GetValue <Thickness> ( ) ;

		public static Thickness WideMargin => GetValue <Thickness> ( ) ;

		#endregion
	}

}
