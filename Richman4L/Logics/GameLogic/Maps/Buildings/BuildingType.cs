using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Collections . ObjectModel ;
using System . Linq ;
using System . Xml . Linq ;

namespace WenceyWang . Richman4L . Maps . Buildings
{

	/// <summary>
	///     指示建筑类型
	/// </summary>
	public sealed class BuildingType : RegisType <BuildingType , BuildingAttribute , Building>
	{

		/// <summary>
		///     形容这个建筑类型的格言
		/// </summary>
		public string Quote { get ; }

		/// <summary>
		///     建筑的尺寸
		/// </summary>
		public MapSize Size { get ; }

		/// <summary>
		///     建筑的初始等级
		/// </summary>
		public BuildingGrade EntryGrade { get ; }

		/// <summary>
		///     建筑的等级
		/// </summary>
		public ReadOnlyCollection <BuildingGrade> Grades { get ; }

		internal BuildingType ( Type entryType , XElement element ) : base ( entryType , element )
		{
			#region Load XML

			try
			{
				Size = GameObject . ReadNecessaryValue <MapSize> ( element , nameof(Size) ) ;
				List <BuildingGrade> grades = new List <BuildingGrade> ( ) ;
				Grades = new ReadOnlyCollection <BuildingGrade> ( grades ) ;
				foreach ( XElement grade in element . Element ( nameof(Grades) ) . Elements ( ) )
				{
					grades . Add ( new BuildingGrade ( grade , this ) ) ;
				}

				EntryGrade = Grades . Single ( grade => grade . Id == 1 ) ;
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof(element)} has wrong data or lack of data" , e ) ;
			}

			#endregion
		}

	}

}
