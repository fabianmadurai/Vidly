using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        //get context to DB
        private ApplicationDbContext _context;


        //instantiate the context within the constructor.
        public MoviesController()
        {
            _context = new ApplicationDbContext();


        }

        //dispose of connection

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Movies
        public ActionResult Random()
        {
            Movie movie = new Movie()
            {
                Name = "Shrek"
            };

            //create a list of customers
            List<Customer> customers = new List<Customer>()
            {
                new Customer { Name = "Customer 1"},
                new Customer {Name = "Customer 2" }
            };

            //create a view Model.

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Index()
        {
            //Use Eager Loading , Include, to get the genres.
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);
                
            return View(movie);
        }
    }
}