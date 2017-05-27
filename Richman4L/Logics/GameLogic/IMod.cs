using System ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;

namespace WenceyWang . Richman4L
{

	public interface IMods
	{

		IReadOnlyCollection <Guid> Dependencies { get ; }

		void Load ( ) ;

	}

	public static class Mods
	{

		public static void LoadMods ( IReadOnlyCollection <IMods> mods )
		{
			List <IMods> modsToLoad = new List <IMods> ( mods ) ;

			List <IMods> loadedMods = new List <IMods> ( ) ;

			int currentCircleLoadModCount ;

			do
			{
				currentCircleLoadModCount = 0 ;

				foreach ( IMods mod in modsToLoad . Where (
					mod => mod . Dependencies . All (
						dependency => loadedMods . Any ( loadedMod => loadedMod . GetType ( ) . GetTypeInfo ( ) . GUID ==
																	dependency ) ) ) )
				{
					currentCircleLoadModCount++ ;
					modsToLoad . Remove ( mod ) ;

					try
					{
						mod . Load ( ) ;
					}
					catch ( Exception e )
					{
						throw new ModLoadFailedException ( "" , e ) ; //Todo:Message
					}

					loadedMods . Add ( mod ) ;
				}
			}
			while ( currentCircleLoadModCount != 0 ) ;

			if ( modsToLoad . Any ( ) )
			{
				throw new Exception ( ) ; //todo:show the exception
			}
		}

	}

	public class ModLoadFailedException : Exception
	{

		public ModLoadFailedException ( ) { }

		public ModLoadFailedException ( string message , Exception inner ) : base ( message , inner ) { }

	}

	[AttributeUsage ( AttributeTargets . All , Inherited = false )]
	public sealed class ModAttribute : Attribute
	{

	}

}
