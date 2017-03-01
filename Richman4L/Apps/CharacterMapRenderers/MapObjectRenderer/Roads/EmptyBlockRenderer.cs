using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Maps ;

namespace WenceyWang . Richman4L . Apps . CharacterMapRenderers . MapObjectRenderer .Roads
{

	public class EmptyBlockRenderer : CharacterMapObjectRenderer <EmptyBlock>
	{

		public override void Update ( )
		{
			for ( int y = 0 ; y < Unit . Height ; y++ )
			{
				for ( int x = 0 ; x < Unit . Width ; x++ )
				{
					CurrentView [ x , y ] = new ConsoleChar ( ' ' , backgroundColor : ConsoleColor . DarkGreen ) ;
				}
			}
		}

	}

	public class NameShower : CharacterMapObjectRenderer <MapObject>
	{

		public override void Update ( )
		{
			string text = Target . Type . Name + " No Renderer " ;
			for ( int y = 0 ; y < Target . Size . Height * Unit . Height ; y++ )
			{
				for ( int x = 0 ; x < Target . Size . Width * Unit . Width ; x++ )
				{
					CurrentView [ x , y ] = text [ ( y * Target . Size . Width * Unit . Width + x ) % text . Length ] ;
				}
			}
		}

	}

}
