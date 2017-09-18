using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

namespace WenceyWang . Richman4L . Logics . Maps . Buildings
{

	/// <summary>
	///     指示建筑的可选附件
	/// </summary>
	public class BuildingAccessory
	{

		/// <summary>
		///     隶属于的建筑等级
		/// </summary>
		public BuildingGrade BelongTo { get ; }

		/// <summary>
		///     建筑附件的名称
		/// </summary>
		public string Name { get ; }


		/// <summary>
		///     建筑附件的简介
		/// </summary>
		public string Introduction { get ; }

		/// <summary>
		///     安装建筑附件所需的资金
		/// </summary>
		public long Money { get ; }

		/// <summary>
		///     安装建筑附件所需的时间（天）
		/// </summary>
		public int InstallTime { get ; }

		internal BuildingAccessory ( XElement element , BuildingGrade belongTo )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof(element) ) ;
			}
			if ( element . Name != nameof(BuildingAccessory) )
			{
				throw new ArgumentException ( $"{nameof(element)} do not perform a {nameof(BuildingAccessory)}" ,
											nameof(element) ) ;
			}

			BelongTo = belongTo ?? throw new ArgumentNullException ( nameof(belongTo) ) ;
			try
			{
				Name = element . Attribute ( nameof(Name) ) . Value ;
				Introduction = element . Attribute ( nameof(Introduction) ) . Value ;
				Money = Convert . ToInt64 ( element . Attribute ( nameof(Money) ) . Value ) ;
				InstallTime = Convert . ToInt32 ( element . Attribute ( nameof(InstallTime) ) . Value ) ;
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof(element)} has wrong data or lack of data" , e ) ;
			}
		}

	}

}
