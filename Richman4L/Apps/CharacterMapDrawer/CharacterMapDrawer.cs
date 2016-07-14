
using System ;

using WenceyWang . Richman4L . App . CharacterMapDrawer . MapObjectDrawer . Roads ;
using WenceyWang . Richman4L . Maps ;
using WenceyWang . Richman4L . Maps . Roads ;
using WenceyWang . Richman4L . Properties ;

namespace WenceyWang . Richman4L . App .CharacterMapDrawer
{
	public class CharacterMapDrawer : IMapDrawer
	{

		public void DrawerCatched ( )
		{

		}

		public char [ , ] CurrentView { get; private set; }

		public void SetMap ([NotNull] Map map )
		{
			if ( map == null )
			{
				throw new ArgumentNullException ( nameof ( map ) );
			}

			Target = map;
			Target . RegisMapDrawer ( this );

			CurrentView = new char [ map . Size . X , map . Size . Y ];

			for ( int y = 0 ; y < map . Size . Y ; y++ )
			{
				for ( int x = 0 ; x < map . Size . X ; x++ )
				{
					CurrentView [ x , y ] = ' ';
				}
			}

			foreach ( MapObject mapObject in Target . Objects )
			{
				if ( mapObject . Type . Name == "NormalRoad" )
				{
					NormalRoadDrawer drawer = new NormalRoadDrawer ( );
					drawer . SetTarget ( mapObject as NormalRoad );

					CurrentView [ mapObject . X , mapObject . Y ] = drawer . CurrentView [ 0 , 0 ];
				}
				else
				{
					CurrentView [ mapObject . X , mapObject . Y ] = mapObject . Type . Name . ToUpper ( ) [ 0 ];
				}
			}

		}

		public Map Target { get; private set; }

	}
}
