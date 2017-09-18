using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Windows ;
using System . Windows . Controls ;
using System . Windows . Media ;

using Microsoft . CSharp . RuntimeBinder ;

namespace WenceyWang . Richman4L . Apps . Wpf . Logic
{

	internal static class ComicSansModeExtensions
	{

		internal static List <FontFamily> EnglishFonts ;

		internal static List <FontFamily> NatureFonts ;


		internal static void LoadComicSansModeFont ( )
		{
			lock ( EnglishFonts )
			{
				lock ( NatureFonts )
				{
				}
			}
		}

		internal static void TurnOnComicSansMode ( this Panel panel , Random random = null )
		{
			if ( panel == null )
			{
				throw new ArgumentNullException ( nameof(panel) ) ;
			}

			random = random ?? new Random ( ) ;


			foreach ( UIElement item in panel . Children )
			{
				if ( item is Panel )
				{
					( item as Panel ) . TurnOnComicSansMode ( random ) ;
				}
				else
				{
					( ( item as ContentControl ) ? . Content as Panel ) ? . TurnOnComicSansMode ( random ) ;
					try
					{
						dynamic control = item ;
					}
					catch ( RuntimeBinderException )
					{
					}
				}
			}
		}

	}

}
