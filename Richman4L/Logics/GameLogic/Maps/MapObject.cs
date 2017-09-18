using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

namespace WenceyWang . Richman4L . Logics . Maps
{

	/// <summary>
	///     代表地图上的元素
	/// </summary>
	public abstract class MapObject : NeedRegisBase <MapObjectType , MapObjectAttribute , MapObject>
	{

		[Own]
		public virtual MapPosition Position { get ; protected set ; }

		/// <summary>
		///     元素的尺寸
		/// </summary>
		[Own]
		public abstract MapSize Size { get ; }

		public abstract MapArea TakeUpArea { get ; }

		private static bool Loaded { get ; set ; }

		/// <summary>
		///     基于地图资源创建MapObject
		/// </summary>
		/// <param name="resource"></param>
		public MapObject ( [NotNull] XElement resource ) : this ( )
		{
			if ( resource == null )
			{
				throw new ArgumentNullException ( nameof(resource) ) ;
			}

			try
			{
				Position = ReadNecessaryValue <MapPosition> ( resource , nameof(Position) ) ;
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof(resource)} has wrong data or lack of data" , e ) ;
			}
		}

		public MapObject ( ) { }

		/// <summary>
		///     要求地图元素的视图更新
		/// </summary>
		public void UpdateView ( )
		{
			UpdateViewEvent ? . Invoke ( this , EventArgs . Empty ) ;
		}

		[NotNull]
		public event EventHandler UpdateViewEvent ;


		public event EventHandler DisposeEvent ;


		[Startup]
		public static void LoadMapObjects ( )
		{
			lock ( Locker )
			{
				if ( Loaded )
				{
					return ;
				}

				//Todo:Load All internal type
				foreach ( TypeInfo type in typeof ( Game ) . GetTypeInfo ( ) .
															Assembly . DefinedTypes .
															Where ( type => type . GetCustomAttributes ( typeof ( MapObjectAttribute ) , false ) . Any ( )
																			&& typeof ( MapObject ) . GetTypeInfo ( ) . IsAssignableFrom ( type ) ) )
				{
					RegisType ( type . AsType ( ) ) ; //Todo:resources?
				}

				Loaded = true ;
			}
		}


		public override string ToString ( ) { return $"{GetType ( ) . Name} at {Position}" ; }

	}

}
