using System;

using WenceyWang . Richman4L . Maps;

namespace WenceyWang . Richman4L . App . CharacterMapRenderer . MapObjectRenderer
{

	public abstract class CharacterMapObjectRenderer<T> : ICharacterMapObjectRenderer, IMapObjectRenderer<T>
		where T : MapObject
	{

		public abstract char [ , ] CurrentView { get; }

		public abstract void Update ( );

		public abstract void StartUp ( );

		public abstract void SetTarget ( T target );

		public void SetTarget ( MapObject target )
		{
			if ( target == null )
			{
				throw new ArgumentNullException ( nameof ( target ) );
			}

			T targetArgument = target as T;
			if ( targetArgument != null )
			{
				SetTarget ( targetArgument );
			}
			else
			{
				throw new ArgumentException ( $"{nameof ( target )} is not {typeof ( T ) . Name}" );
			}
		}

		MapObject ICharacterMapObjectRenderer.Target => Target;

		public T Target { get; protected set; }

		#region IDisposable Support

		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose ( bool disposing )
		{
			if ( !disposedValue )
			{
				if ( disposing )
				{
					// TODO: dispose managed state (managed objects).
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~CharacterMapObjectRenderer() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose ( )
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose ( true );

			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}

		#endregion
	}

}
