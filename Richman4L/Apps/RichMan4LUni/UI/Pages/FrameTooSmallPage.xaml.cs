using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using Windows . UI ;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WenceyWang . Richman4L . Apps . Uni . UI . Pages
{

	/// <summary>
	///     An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class FrameTooSmallPage : AnimatePage
	{

		public static Color PageColor => XamlResources . Resources . Black ;

		public FrameTooSmallPage ( ) { InitializeComponent ( ) ; }

		public override void AddControl ( ) { throw new NotImplementedException ( ) ; }

		public override void RemoveControl ( ) { throw new NotImplementedException ( ) ; }

	}

}
