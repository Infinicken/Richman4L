using System;
using System . Collections;
using System . Linq;
using WenceyWang . Richman4L . Maps;

namespace WenceyWang . Richman4L . Apps . CharacterMapRenderers . MapObjectRenderer .Roads
{

	public class SmallAreaRenderer : CharacterMapObjectRenderer <SmallArea>
	{

		public override void Update ( )
		{
			switch ( Target . GetAzimuth ( Target . Position ) )
			{
				case BlockAzimuth . None :
				{
					break ;
				}
				case BlockAzimuth . Up :
				{
					break ;
				}
				case BlockAzimuth . Down :
				{
					break ;
				}
				case BlockAzimuth . Left :
				{
					break ;
				}
				case BlockAzimuth . Right :
				{
					break ;
				}
			}
		}

	}

}
