using System ;
using System . Collections ;
using System . Linq ;
using System . Web . Http ;

namespace WenceyWang . Richman4L . Apps .Web
{

	public static class WebApiConfig
	{

		public static void Register ( HttpConfiguration config )
		{
			config . MapHttpAttributeRoutes ( ) ;

			config . Routes . MapHttpRoute (
				"DefaultApi" ,
				"api/{controller}/{id}" ,
				new { id = RouteParameter . Optional }
			) ;
		}

	}

}
