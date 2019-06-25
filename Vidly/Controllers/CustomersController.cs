using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller

         
    {
        //get context to DB
        private ApplicationDbContext _context;


        //instantiate the context within the constructor.
        public CustomersController()
        {
            _context = new ApplicationDbContext();


        }

        //dispose of connection

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        List<Customer> CustomersList = new List<Customer>
            {
                new Customer {Name = "Jack" , Id = 1 },
                new Customer {Name = "Mary Jane", Id = 2 }
            };

        // GET: Customers
        public ActionResult Index()
        {
            //get customers from dbcontex

            //Using Eager Loading below to get the related Membership tupes
            //must include using System.Data.Entity for the include to work.
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
           

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers
                .Include(c =>c.MembershipType)
                .SingleOrDefault(c => c.Id==id);

            

            return View(customer);
        }

        public ActionResult New()
        {
            return View();
        }
    }
}