using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Web . Mvc ;
using System . Web . Routing ;

namespace WenceyWang . Richman4L . Apps . Web
{

	public class RouteConfig
	{

		public static void RegisterRoutes ( RouteCollection routes )
		{
			routes . IgnoreRoute ( "{resource}.axd/{*pathInfo}" ) ;

			routes . MapRoute ( "Default" ,
								"{controller}/{action}/{id}" ,
								new { controller = "Home" , action = "Index" , id = UrlParameter . Optional } ) ;
		}

	}

}
