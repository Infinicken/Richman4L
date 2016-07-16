﻿using System;

using Windows . Foundation;

using WenceyWang . Richman4L . Maps;
using WenceyWang . Richman4L . Maps . Roads;
using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . App . XamlMapRenderer . MapObjectRenderer . Roads
{

	public sealed partial class NormalRoadRenderer : MapObjectRenderer, IMapObjectRenderer<NormalRoad>
	{

		public override Size Size => new Size ( 112 , 56 );

		[CanBeNull]
		public NormalRoad Target { get; private set; }

		public void SetTarget ( [NotNull] NormalRoad target )
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

		public void StartUp ( )
		{


			#region 断头路

			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
				Target . BackwardRoad == null ||
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up &&
				Target . ForwardRoad == null )
			{

			}
			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
				Target . BackwardRoad == null ||
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down &&
				Target . ForwardRoad == null )
			{

			}
			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
				Target . BackwardRoad == null ||
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left &&
				Target . ForwardRoad == null )
			{

			}
			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
				Target . BackwardRoad == null ||
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right &&
				Target . ForwardRoad == null )
			{

			}

			#endregion


			#region 连续路

			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
				Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up )
			{
				//上下
			}
			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right ||
				Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
			{
				//左右
			}
			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
				Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
			{
				//左上
			}
			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
				Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
			{
				//右上
			}
			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
				Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
			{
				//左下
			}
			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
				Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
			{
				//右下
			}

			#endregion


		}

		public override void Hide ( ) { }

		public override void Show ( ) { }

		public void Update ( )
		{
			if ( Target == null )
			{
				throw new InvalidOperationException ( );
			}
		}

		public NormalRoadRenderer ( ) { this . InitializeComponent ( ); }

		#region IDisposable Support

		private bool DisposedValue = false; // To detect redundant calls

		private void Dispose ( bool disposing )
		{
			if ( !DisposedValue )
			{
				if ( disposing )
				{

				}

				// TODO: set large fields to null.

				DisposedValue = true;
			}
		}

		~NormalRoadRenderer ( ) { Dispose ( false ); }

		public void Dispose ( ) { Dispose ( true ); }

		#endregion

	}

}
