using System ;

using Windows . Foundation ;

using WenceyWang . Richman4L . Maps ;
using WenceyWang . Richman4L . Maps . Buildings ;
using WenceyWang . Richman4L . Properties ;

namespace WenceyWang . Richman4L . App . XamlMapDrawer . MapObjectDrawers . Buildings
{
	public sealed partial class SmallHouse : MapObjectDrawer, IMapObjectDrawer<SmallSimpleBuilding>
	{



		[CanBeNull]
		public SmallSimpleBuilding Target { get; private set; } = null;

		public override Size Size => new Size ( 120 , 60 );

		public void SetTarget ( [NotNull] SmallSimpleBuilding target )
		{
			if ( Target == null )
			{
				Target = target;
			}
			else
			{
				throw new InvalidOperationException ( );
			}
		}

		public override void Show ( )
		{
			//todo:
		}

		public override void Hide ( )
		{
			//todo:
		}

		public void Update ( ) { }

		public SmallHouse ( )
		{
			this . InitializeComponent ( );
		}

	}
}
