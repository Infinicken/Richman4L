﻿using System;

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

		#region IDisposable Support
		private bool disposedValue = false; // 要检测冗余调用

		void Dispose ( bool disposing )
		{
			if ( !disposedValue )
			{
				if ( disposing )
				{
					// TODO: 释放托管状态(托管对象)。
				}

				// TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
				// TODO: 将大型字段设置为 null。

				disposedValue = true;
			}
		}

		// TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
		// ~SmallAreaDrawer() {
		//   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
		//   Dispose(false);
		// }

		// 添加此代码以正确实现可处置模式。
		public void Dispose ( )
		{
			// 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
			Dispose ( true );
			// TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
			// GC.SuppressFinalize(this);
		}
		#endregion
	}
}
