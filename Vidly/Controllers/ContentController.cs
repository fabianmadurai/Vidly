using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index()
        {
            return Content("Hello There again");
        }
    }
}