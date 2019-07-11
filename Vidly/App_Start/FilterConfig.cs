using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {

        //Here we can register global filters for our application
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            
            //If you just add the line below as is, it will restrict everything on the site, including homepage, which is not cool.
            //hence you should apply [AllowAnonymous] to the home page index action at least.
            filters.Add(new AuthorizeAttribute());
        }
    }
}
