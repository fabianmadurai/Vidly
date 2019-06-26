using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
        public ActionResult New()

        {
            TempData["FormType"] = "New";
            var viewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()

            };

            return View("MovieForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            TempData["FormType"] = "Edit";
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if(movie == null)
            {
                return HttpNotFound();
            }
            var Genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = Genres,
                Movie = movie
            };
                        

            return View("MovieForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)//Model binding
        {
            if(movie.Id == 0)  //means new and not edit
            {
                try
                {
                    _context.Movies.Add(movie);
                }
                catch (DbEntityValidationException e)
                {

                    Console.WriteLine(e);
                }
            }

            else
            {
                //get movie from db

                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.StockNumber = movie.StockNumber;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;

            }
            
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}