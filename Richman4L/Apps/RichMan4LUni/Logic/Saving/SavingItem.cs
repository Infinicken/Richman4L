using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading . Tasks ;

using Windows . Storage ;
using Windows . Storage . Search ;

namespace WenceyWang . Richman4L . Apps . Uni . Logic . Saving
{

	internal class SavingItem
	{

		public string Name { get ; set ; }

		public string Map { get ; set ; }

		public DateTime Date { get ; set ; }

		public StorageFile File { get ; set ; }

		public SavingItem ( StorageFile file )
		{
			string [ ] fileName = file . Name . Split ( "_" . ToCharArray ( ) ) ;

			Name = fileName [ 0 ] ;

			Map = fileName [ 1 ] ;

			Date = DateTime . Parse ( fileName [ 2 ] ) ;

			File = file ;
		}

		public async void Delete ( ) { await File . DeleteAsync ( ) ; }

		public static async Task <List <SavingItem>> GetSaving ( )
		{
			List <SavingItem> list = new List <SavingItem> ( ) ;

			IReadOnlyList <StorageFile> fileList =
				await ApplicationData . Current . RoamingFolder . GetFilesAsync ( CommonFileQuery . OrderByDate ) ;

			foreach ( StorageFile item in fileList )
			{
				if ( item . FileType == "r4lsav" )
				{
					list . Add ( new SavingItem ( item ) ) ;
				}
			}

			list . Sort ( ) ;

			return list ;
		}

	}

}
