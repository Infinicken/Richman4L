using System ;

using Windows . Foundation ;

using WenceyWang . Richman4L . Maps ;
using WenceyWang . Richman4L . Maps . Buildings ;
using WenceyWang . Richman4L . Properties ;

namespace WenceyWang . Richman4L . App . XamlMapDrawer . MapObjectDrawers . Buildings
{
	public sealed partial class SmallHouseDrawer : MapObjectDrawer 
	{

		public override Size Size => new Size ( 120 , 60 );


		public override void Show ( )
		{
			//todo:
		}

		public override void Hide ( )
		{
			//todo:
		}

		public void Update ( ) { }

		public SmallHouseDrawer ( )
		{
			this . InitializeComponent ( );
		}

	}
}
