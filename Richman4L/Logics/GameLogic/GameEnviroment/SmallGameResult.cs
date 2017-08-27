using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;

namespace WenceyWang . Richman4L . GameEnviroment
{

	public class SmallGameResult
	{

		public Guid Id { get ; }

		public SmallGameType Type { get ; }

		public int GamePoint { get ; set ; }

		public override string ToString ( )
		{
			return $"{nameof(Id)}: {Id}, {nameof(Type)}: {Type}, {nameof(GamePoint)}: {GamePoint}" ;
		}

	}

	public class StartSmallGameRequest
	{

		public Guid Id { get ; }

		public SmallGameType Type { get ; }

		public override string ToString ( ) { return $"{nameof(Id)}: {Id}, {nameof(Type)}: {Type}" ; }

	}


	public sealed class SmallGameType
	{

		public Guid Guid => EntryType . GetTypeInfo ( ) . GUID ;

		public string Name { get ; }

		public string Introduction { get ; }

		public Type EntryType { get ; }

		internal SmallGameType ( [NotNull] Type entryType , [NotNull] XElement element )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof(element) ) ;
			}

			EntryType = entryType ?? throw new ArgumentNullException ( nameof(entryType) ) ;

			#region Load XML

			Name = GameObject . ReadUnnecessaryValue ( element , nameof(Name) , string . Empty ) ;

			Introduction = GameObject . ReadUnnecessaryValue ( element , nameof(Introduction) , string . Empty ) ;

			#endregion
		}

		public override string ToString ( ) { return Guid . ToString ( ) ; }

	}

}
