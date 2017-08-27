using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Web ;
using System . Web . Mvc ;
using System . Web . Optimization ;
using System . Web . Routing ;

namespace WenceyWang . Richman4L . Apps . Web
{

	public class MvcApplication : HttpApplication
	{

		protected void Application_Start ( )
		{
			Startup . RunAllTask ( ) . Wait ( ) ;
			AreaRegistration . RegisterAllAreas ( ) ;
			FilterConfig . RegisterGlobalFilters ( GlobalFilters . Filters ) ;
			RouteConfig . RegisterRoutes ( RouteTable . Routes ) ;
			BundleConfig . RegisterBundles ( BundleTable . Bundles ) ;
		}

	}

}
