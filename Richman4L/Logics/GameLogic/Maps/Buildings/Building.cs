using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

using WenceyWang . Richman4L . Logics . Banks ;
using WenceyWang . Richman4L . Logics . Cards ;
using WenceyWang . Richman4L . Logics . Maps . Buildings . Events ;
using WenceyWang . Richman4L . Logics . Players ;
using WenceyWang . Richman4L . Logics . Players . PayReasons ;

namespace WenceyWang . Richman4L . Logics . Maps . Buildings
{

	//Todo:完善事件
	//Todo:如何表现升级状态？
	/// <summary>
	///     表示建筑
	/// </summary>
	public abstract class Building : NeedRegisBase <BuildingType , BuildingAttribute , Building> , IAsset
	{

		/// <summary>
		///     建筑的名称
		/// </summary>
		public virtual string Name { get ; set ; }

		/// <summary>
		///     建筑的位置
		/// </summary>
		public Area Position { get ; protected set ; }

		public List <BuildingBuff> Buffs { get ; } //todo 

		/// <summary>
		///     指示建筑的完成度
		/// </summary>
		[Own]
		public GameValue CompletedDgree { get ; set ; } = 0 ;

		/// <summary>
		///     指示建筑的维护水平
		/// </summary>
		[Own]
		public GameValue MaintenanceDegree { get ; set ; } = 0 ;

		[Own]
		public abstract int NoncombustiblePartRatio { get ; }

		/// <summary>
		///     指示当前建筑所处的等级
		/// </summary>
		[Own]
		public virtual BuildingGrade Grade { get ; protected set ; }

		/// <summary>
		///     指示建筑是否易于摧毁
		/// </summary>
		[Own]
		public abstract bool IsEasyToDestroy { get ; }

		/// <summary>
		///     指示建筑今天所需的维持费
		/// </summary>
		[Own]
		public abstract long MaintenanceFee { get ; }

		public static List <BuildingType> BuildingTypes { get ; private set ; } = new List <BuildingType> ( ) ;

		private static bool Loaded { get ; set ; }

		//Todo:complete this event arg

		[Own]
		public WithAssetObject Owner { get ; private set ; }

		public virtual void Upgrade ( BuildingGrade targetGrade ) { }

		[PublicAPI]
		public virtual void Pass ( Player player )
		{
		}

		[PublicAPI]
		public virtual void Stay ( Player player )
		{
		}

		/// <summary>
		///     外来的摧毁房子
		/// </summary>
		/// <param name="reason"></param>
		public abstract void Destoy ( BuildingDestroyReason reason ) ;

		[PublicAPI]
		public event EventHandler Destroied ;

		public static event EventHandler <BuildBuildingEventArgs> BuildBuildingEvent ;

		/// <summary>
		///     由Area调用,开始建造这个建筑
		/// </summary>
		/// <param name="position"></param>
		/// <param name="player"></param>
		public virtual void Build ( Area position , WithAssetObject player )
		{
			Position = position ;
			Grade = Type . EntryGrade ;
			State = BuildingState . Building ;
			Bank . Current . ReceivePayReason ( new PayMoneyForBuildBuildingReason ( this ,
																					Type . EntryGrade . StartUpgradeCost ,
																					Owner ) ) ;

			//player.RequestPay(player,
			//					Type.EntryGrade.StartUpgradeCost,
			//					new PayMoneyForBuildBuildingReason(this));
			UpgradeTo = Type . EntryGrade ;
			UpgradeProcess = 0 ;

			//Todo:完善这个
		}

		[PublicAPI]
		public static BuildingType RegisBuildingType ( Type entryType , XElement element )
		{
			#region Check Argument

			if ( entryType == null )
			{
				throw new ArgumentNullException ( nameof(entryType) ) ;
			}

			if ( ! typeof ( Building ) . GetTypeInfo ( ) . IsAssignableFrom ( entryType . GetTypeInfo ( ) ) )
			{
				throw new ArgumentException ( $"{nameof(entryType)} should assignable from {nameof(Building)}" ,
											nameof(entryType) ) ;
			}

			if ( entryType . GetTypeInfo ( ) . GetCustomAttributes ( typeof ( BuildingAttribute ) , false ) . FirstOrDefault ( )
				== null )
			{
				throw new ArgumentException ( $"{nameof(entryType)} should have atribute {nameof(BuildingAttribute)}" ,
											nameof(entryType) ) ;
			}

			if ( element == null )
			{
				throw new ArgumentNullException ( nameof(element) ) ;
			}

			if ( element . Name != nameof(BuildingType) )
			{
				throw new ArgumentException ( $"{nameof(element)} should perform a building type" , nameof(element) ) ;
			}

			if ( BuildingTypes . Any ( type => type . EntryType == entryType ) )
			{
				throw new InvalidOperationException ( $"{nameof(entryType)} have regised" ) ;
			}

			#endregion

			BuildingType buildingType = new BuildingType ( entryType , element ) ;

			BuildingTypes . Add ( buildingType ) ;
			RegisType ( buildingType ) ;

			return buildingType ;
		}

		[Startup]
		[PublicAPI]
		public static void LoadBuildingTypes ( )
		{
			lock ( Locker )
			{
				if ( Loaded )
				{
					return ;
				}

				BuildingTypes = new List <BuildingType> ( ) ;

				//Todo:Regis all internal Building
			}
		}

		/// <summary>
		///     由Area调用,创造一个Building以供建造
		///     <see
		///         cref="https://onedrive.live.com/edit.aspx/Documents/RichMan4L?cid=cb060fe3721bc584&id=documents&wd=target%28%E8%AE%BE%E8%AE%A1.one%7C65029F20-EC36-470D-A8A6-CAFE5DAB8F08%2F%E6%88%91%E4%BB%AC%E5%A6%82%E4%BD%95%E5%BB%BA%E6%88%BF%E5%AD%90%7C1A21558A-DE44-409F-9F49-9DDC048D6661%2F%29" />
		/// </summary>
		/// <param name="buildingType"></param>
		/// <returns>被创造出的Building对象</returns>
		[PublicAPI]
		public static Building Build ( BuildingType buildingType )
		{
			#region Check Argument

			if ( buildingType == null )
			{
				throw new ArgumentNullException ( nameof(buildingType) ) ;
			}

			//Todo: Use resources
			if ( ! BuildingTypes . Contains ( buildingType ) )
			{
				throw new ArgumentException ( $"{nameof(buildingType)} have not being registered" , nameof(buildingType) ) ;
			}

			#endregion

			Building building = Crate ( buildingType ) ;

			BuildBuildingEvent ? . Invoke ( typeof ( Building ) , new BuildBuildingEventArgs ( building ) ) ;
			return building ;
		}

		#region State

		/// <summary>
		///     指示当前建筑的状态
		/// </summary>
		[Own]
		public BuildingState State { get ; protected set ; } = BuildingState . NotBuild ;

		#region	Upgrade

		/// <summary>
		///     指示建筑将会升级到的等级
		/// </summary>
		public virtual BuildingGrade UpgradeTo { get ; protected set ; }

		/// <summary>
		///     指示建筑的升级进程的10000倍
		/// </summary>
		public virtual GameValue UpgradeProcess { get ; protected set ; }

		/// <summary>
		///     指示这个建筑应当拥有的最小价值
		/// </summary>
		public abstract long MinimumValue { get ; }

		public bool CanGive { get ; }

		public void GiveTo ( WithAssetObject newOwner ) { throw new NotImplementedException ( ) ; }

		#endregion

		#region

		#endregion

		#endregion

	}

}
