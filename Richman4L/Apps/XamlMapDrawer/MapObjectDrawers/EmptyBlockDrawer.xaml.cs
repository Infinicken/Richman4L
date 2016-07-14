using System;

using Windows . Foundation;

using WenceyWang . Richman4L . Maps;
using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . App . XamlMapDrawer . MapObjectDrawers
{
	public sealed partial class EmptyBlockDrawer : MapObjectDrawer, IMapObjectDrawer<EmptyBlock>
	{
		public EmptyBlockDrawer ( )
		{
			this . InitializeComponent ( );
		}

		public override Size Size => new Size ( 100 , 50 );


		public EmptyBlock Target { get; private set; } = null;

		public override void Hide ( )
		{

		}

		public void StartUp ( )
		{


		}

		public void SetTarget ( [NotNull]EmptyBlock target )
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
