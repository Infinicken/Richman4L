using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

namespace WenceyWang . Richman4L . Logics
{

	public class GameObjectType
	{

		public string Introduction { get ; }

		/// <summary>
		///     Guid of this Type
		///     Always return EntryType.Guid
		/// </summary>
		public Guid Guid => EntryType . GetTypeInfo ( ) . GUID ;

		public Type EntryType { get ; }

		public string Name => EntryType . FullName ;

		public GameObjectType ( [NotNull] Type entryType , [NotNull] XElement element )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof(element) ) ;
			}

			EntryType = entryType ?? throw new ArgumentNullException ( nameof(entryType) ) ;

			#region Load XML

			Introduction = GameObject . ReadNecessaryValue <string> ( element , nameof(Introduction) ) ;

			#endregion
		}

		public GameObjectType ( [NotNull] Type entryType )
		{
			EntryType = entryType ?? throw new ArgumentNullException ( nameof(entryType) ) ;
		}

	}

}
