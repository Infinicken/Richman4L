using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics ;
using System . Linq ;
using System . Reflection ;

using Windows . UI ;
using Windows . UI . Xaml . Controls ;
using Windows . UI . Xaml . Media . Animation ;
using Windows . UI . Xaml . Shapes ;

namespace WenceyWang . Richman4L . Apps . Uni . UI . Pages
{

	public abstract class AnimatePage : Page
	{

		public Storyboard GetLeaveStoryboard
			=> ( Storyboard ) GetType ( ) . GetTypeInfo ( ) . GetDeclaredField ( "LeaveStoryboard" ) . GetValue ( this ) ;

		public Rectangle GetBackgroundRect
			=> ( Rectangle ) GetType ( ) . GetTypeInfo ( ) . GetDeclaredField ( "BackgroundRect" ) . GetValue ( this ) ;

		public static Color GetPageColor <T> ( ) where T : AnimatePage
		{
			return ( Color ) typeof ( T ) . GetTypeInfo ( ) . GetDeclaredProperty ( "PageColor" ) . GetValue ( null ) ;
		}

		public static Color GetPageColor <T> ( T page ) where T : AnimatePage
		{
			return ( Color ) page . GetType ( ) . GetTypeInfo ( ) . GetDeclaredProperty ( "PageColor" ) . GetValue ( null ) ;
		}

		[DebuggerStepThrough]
		protected void SetEventArgsHandled ( object args )
		{
			PropertyInfo property = args . GetType ( ) . GetTypeInfo ( ) . GetDeclaredProperty ( "Handled" ) ;
			if ( property ? . CanWrite == true )
			{
				property . SetValue ( args , true ) ;
			}
		}

		public abstract void AddControl ( ) ;

		public abstract void RemoveControl ( ) ;

	}

}
