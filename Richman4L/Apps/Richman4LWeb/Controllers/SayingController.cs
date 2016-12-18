using System ;
using System . Collections ;
using System . Linq ;
using System . Web ;
using System . Web . Mvc ;

namespace WenceyWang . Richman4L . Apps . Web .Controllers
{

	public class SayingController : Controller
	{

		// GET: Saying
		//public ActionResult Index()
		//{
		//	return View();
		//}


		public ActionResult Xml ( string id )
		{
			if ( id == null )
			{
				return Content ( GameSaying . GetSaying ( ) . ToXElement ( ) . ToString ( ) , "text/xml" ) ;
			}

			Guid guid ;
			if ( Guid . TryParse ( id , out guid ) &&
				GameSaying . GetSaying ( guid ) != null )
			{
				return Content ( GameSaying . GetSaying ( guid ) . ToXElement ( ) . ToString ( ) , "text/xml" ) ;
			}

			throw new HttpException ( 404 , "Not Found" ) ;
		}

	}

}
