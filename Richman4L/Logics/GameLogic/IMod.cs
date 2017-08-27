using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Collections . ObjectModel ;
using System . Linq ;

namespace WenceyWang . Richman4L
{

	public interface IMods
	{

		Guid Guid { get ; }

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

				foreach ( IMods mod in modsToLoad . Where ( mod => mod . Dependencies . All ( dependency
																								=> loadedMods . Any ( loadedMod => loadedMod . Guid == dependency ) ) ) )
				{
					currentCircleLoadModCount++ ;
					modsToLoad . Remove ( mod ) ;

					try
					{
						mod . Load ( ) ;
					}
					catch ( Exception e )
					{
						throw new ModLoadFailedException ( $"Mod [{mod . Guid}] failed to load" , e , mod ) ;
					}

					loadedMods . Add ( mod ) ;
				}
			}
			while ( currentCircleLoadModCount != 0 ) ;

			if ( modsToLoad . Any ( ) )
			{
				throw new ModLoadFailedException ( "Some mods failed to load" ,
													null ,
													modsToLoad . ToArray ( ) ) ; //todo:show the exception
			}
		}

	}


	public class ModLoadFailedException : Exception
	{

		public ReadOnlyCollection <IMods> FailedMods { get ; }

		public ModLoadFailedException ( ) { }

		public ModLoadFailedException ( string message , Exception inner , params IMods [ ] failedMods ) :
			base ( message , inner )
		{
			FailedMods = new ReadOnlyCollection <IMods> ( failedMods ) ;
		}

	}

	[AttributeUsage ( AttributeTargets . Class , Inherited = false )]
	public sealed class ModAttribute : Attribute
	{

	}

}
