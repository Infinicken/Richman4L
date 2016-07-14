using System;

using Windows . Foundation;

using WenceyWang . Richman4L . Maps;
using WenceyWang . Richman4L . Properties ;

namespace WenceyWang . Richman4L . App . XamlMapDrawer . MapObjectDrawers
{
	public sealed partial class SmallAreaDrawer : MapObjectDrawer, IMapObjectDrawer<SmallArea>
	{
		public SmallAreaDrawer ( )
		{
			this . InitializeComponent ( );
		}

		public override Size Size => new Size ( 112 , 56 );

		public SmallArea Target { get; private set; } = null;

		public override void Hide ( )
		{
			throw new NotImplementedException ( );
		}

		public void StartUp ( )
		{
			
			
		}

		public void SetTarget ( [NotNull] SmallArea target )
		{
			if ( Target == null )
			{
				Target = target;
				StartUp ( );
			}
			else
			{
				throw new InvalidOperationException ( );
			}
		}

		public override void Show ( )
		{
			throw new NotImplementedException ( );
		}

		public void Update ( )
		{
			throw new NotImplementedException ( );
		}
	}
}
