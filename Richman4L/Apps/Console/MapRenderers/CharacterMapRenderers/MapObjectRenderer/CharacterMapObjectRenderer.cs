using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

using WenceyWang . Richman4L . Logics . GameEnviroment . Renderers ;
using WenceyWang . Richman4L . Logics . Maps ;

namespace WenceyWang . Richman4L . Apps . Console . MapRenderers . MapObjectRenderer
{

	public abstract class CharacterMapObjectRenderer <T> : ICharacterMapObjectRenderer , IMapObjectRenderer <T>
		where T : MapObject
	{

		public virtual ConsoleChar [ , ] CurrentView { get ; protected set ; }

		public ConsoleSize Unit { get ; protected set ; }

		public virtual void StartUp ( )
		{
			CurrentView = new ConsoleChar[ Unit . Width , Unit . Height ] ;
			for ( int y = 0 ; y < Unit . Height ; y++ )
			{
				for ( int x = 0 ; x < Unit . Width ; x++ )
				{
					CurrentView [ x , y ] = new ConsoleChar ( ' ' , ConsoleColor . White , ConsoleColor . DarkGreen ) ;
				}
			}

			Update ( ) ;
		}

		public abstract void Update ( ) ;

		public virtual void SetUnit ( ConsoleSize unit ) { Unit = unit ; }

		MapObject ICharacterMapObjectRenderer . Target => Target ;

		public void SetTarget ( MapObject target )
		{
			if ( target == null )
			{
				throw new ArgumentNullException ( nameof(target) ) ;
			}

			if ( target is T targetArgument )
			{
				SetTarget ( targetArgument ) ;
			}
			else
			{
				throw new ArgumentException ( $"{nameof(target)} is not {typeof ( T ) . Name}" ) ;
			}
		}

		MapObject IMapObjectRenderer . Target => Target ;

		public T Target { get ; protected set ; }

		public virtual void SetTarget ( [NotNull] T target )
		{
			if ( Target == null )
			{
				Target = target ;
			}
			else
			{
				throw new InvalidOperationException ( ) ;
			}
		}

	}

}
