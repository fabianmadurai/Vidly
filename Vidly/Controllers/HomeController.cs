using System.Web.Mvc;

namespace Vidly.Controllers
{
    [AllowAnonymous] //we have a global filter in filter.config, so we have to use this to allow users to see the home page.
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Random()
        {
            return RedirectToAction("Index","Home",new {FilterBy="Name", SortBy="Title" });
        }
    }
}