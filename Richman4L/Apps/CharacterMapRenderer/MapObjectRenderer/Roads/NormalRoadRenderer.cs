using System;

using WenceyWang . Richman4L . Maps;
using WenceyWang . Richman4L . Maps . Roads;
using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . App . CharacterMapRenderer . MapObjectRenderer . Roads
{

	public class NormalRoadRenderer : CharacterMapObjectRenderer<NormalRoad>
	{

		public override char [ , ] CurrentView { get; } = new char [ 1 , 1 ];

		public override void Update ( ) { }

		public override void StartUp ( )
		{
			#region 断头路

			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
				Target . BackwardRoad == null ||
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up &&
				Target . ForwardRoad == null )
			{
				CurrentView [ 0 , 0 ] = '╨';
			}
			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
				Target . BackwardRoad == null ||
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down &&
				Target . ForwardRoad == null )
			{
				CurrentView [ 0 , 0 ] = '╥';
			}
			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
				Target . BackwardRoad == null ||
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left &&
				Target . ForwardRoad == null )
			{
				CurrentView [ 0 , 0 ] = '╡';
			}
			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
				Target . BackwardRoad == null ||
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right &&
				Target . ForwardRoad == null )
			{
				CurrentView [ 0 , 0 ] = '╞';
			}

			#endregion

			#region 连续路

			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
				Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up )
			{
				CurrentView [ 0 , 0 ] = '║';

				//上下
			}
			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right ||
				Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
			{
				CurrentView [ 0 , 0 ] = '═';

				//左右
			}
			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
				Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
			{
				CurrentView [ 0 , 0 ] = '╝';

				//左上
			}
			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
				Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
			{
				CurrentView [ 0 , 0 ] = '╚';

				//右上
			}
			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
				Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
			{
				CurrentView [ 0 , 0 ] = '╗';

				//左下
			}
			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
				Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
			{
				CurrentView [ 0 , 0 ] = '╔';

				//右下
			}

			#endregion
		}



		public override void SetTarget ( [NotNull] NormalRoad target )
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

	}

}
