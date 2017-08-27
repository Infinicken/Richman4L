using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;

namespace WenceyWang . Richman4L
{

	public class GameObjectType
	{

		public string Introduction { get ; }

		/// <summary>
		///     Guid of this Type
		///     Always return EntryType.Guid
		/// </summary>
		public Guid Guid => EntryType . GetTypeInfo ( ) . GUID ;

		public string Name { get ; }

		public Type EntryType { get ; }

		protected GameObjectType ( [NotNull] Type entryType , [NotNull] XElement element )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof(element) ) ;
			}

			EntryType = entryType ?? throw new ArgumentNullException ( nameof(entryType) ) ;

			#region Load XML

			Name = GameObject . ReadNecessaryValue <string> ( element , nameof(Name) ) ;

			Introduction = GameObject . ReadNecessaryValue <string> ( element , nameof(Introduction) ) ;

			#endregion
		}

		protected GameObjectType ( [NotNull] Type entryType , [NotNull] string name , [NotNull] string introduction )
		{
			EntryType = entryType ?? throw new ArgumentNullException ( nameof(entryType) ) ;

			Name = name ?? throw new ArgumentNullException ( nameof(name) ) ;

			Introduction = introduction ?? throw new ArgumentNullException ( nameof(introduction) ) ;
		}

	}

}
