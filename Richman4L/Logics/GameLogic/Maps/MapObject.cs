using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;

namespace WenceyWang . Richman4L . Maps
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
				foreach ( TypeInfo type in typeof ( Game ) . GetTypeInfo ( ) . Assembly . DefinedTypes .
															Where ( type => type . GetCustomAttributes ( typeof ( MapObjectAttribute ) , false ) . Any ( )
																			&& typeof ( MapObject ) . GetTypeInfo ( ) . IsAssignableFrom ( type ) ) )
				{
					RegisMapObjectType ( type . AsType ( ) ) ;
				}

				Loaded = true ;
			}
		}


		/// <summary>
		///     注册一个MapObject类型
		///     这个方法应当在加载程序集的时候被调用，加载的程序集应当注册所有的MapObject
		/// </summary>
		/// <param name="name">用于从地图资源文件中识别的名称</param>
		/// <param name="entryType">要注册的类型类型</param>
		/// <returns>生成的类型</returns>
		[NotNull]
		public static MapObjectType RegisMapObjectType ( [NotNull] Type entryType )
		{
			lock ( Locker )
			{
				#region Check Argument

				if ( entryType == null )
				{
					throw new ArgumentNullException ( nameof(entryType) ) ;
				}

				#endregion

				#region Check Attributes

				MapObjectAttribute attribute =
					entryType . GetTypeInfo ( ) . GetCustomAttributes ( typeof ( MapObjectAttribute ) , false ) . FirstOrDefault ( ) as
						MapObjectAttribute ;

				if ( attribute == null )
				{
					throw new ArgumentException ( $"{nameof(entryType)} should have attribute {nameof(MapObjectAttribute)}" ,
												nameof(entryType) ) ;
				}

				#endregion

				if ( TypeList . Any ( type => type . Guid == entryType . GetTypeInfo ( ) . GUID ) )
				{
					return TypeList . Single ( type => type . Guid == entryType . GetTypeInfo ( ) . GUID ) ;
				}

				return RegisType ( entryType , attribute . Name , attribute . Introduction ) ;
			}
		}


		public override string ToString ( ) { return $"{GetType ( ) . Name} at {Position}" ; }

	}

}
