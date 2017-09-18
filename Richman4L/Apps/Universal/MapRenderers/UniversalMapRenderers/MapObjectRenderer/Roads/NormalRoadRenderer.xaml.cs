using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using Windows . Foundation ;

namespace WenceyWang . Richman4L . Apps . XamlMapRenderers . MapObjectRenderer . Roads
{

	public sealed partial class NormalRoadRenderer : MapObjectRenderer , IMapObjectRenderer <NormalRoad>
	{

		public override Size Size => new Size ( 112 , 56 ) ;

		[CanBeNull]
		public NormalRoad Target { get ; private set ; }

		public NormalRoadRenderer ( ) { InitializeComponent ( ) ; }

		public void SetTarget ( [NotNull] NormalRoad target )
		{
			if ( Target == null )
			{
				Target = target ;
				StartUp ( ) ;
			}
			else
			{
				throw new InvalidOperationException ( ) ;
			}
		}

		public void StartUp ( ) { }

		public void Update ( )
		{
			if ( Target == null )
			{
				throw new InvalidOperationException ( ) ;
			}
		}

		public override void Hide ( ) { }

		public override void Show ( ) { }

	}

}
