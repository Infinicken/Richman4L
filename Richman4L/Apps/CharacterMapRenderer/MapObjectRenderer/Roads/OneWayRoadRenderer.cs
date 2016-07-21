using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

using WenceyWang . Richman4L . Maps . Roads ;

namespace WenceyWang . Richman4L . App . CharacterMapRenderer . MapObjectRenderer . Roads
{
	public class OneWayRoadRenderer:CharacterMapObjectRenderer <OneWayRoad>
	{

		public override ConsoleChar [ , ] CurrentView { get ; protected set ; }

		public override void StartUp ( )
		{
			CurrentView = new ConsoleChar[ Unit . Width, Unit . Height ] ;
			Update ( ) ;
		}

		public override void Update ( )
		{
			if ( Unit==ConsoleSize.Small  )
			{
				
			}
			else if ( Unit == ConsoleSize . Large )
			{
				
			}
		}

	}
}
