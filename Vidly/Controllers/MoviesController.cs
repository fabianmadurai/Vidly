using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
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
            List<Movie> Movies = new List<Movie>()
            {
                new Movie {Name ="Terminator"},
                new Movie {Name ="Peter Pan" }
            };

            return View(Movies);
        }
    }
}