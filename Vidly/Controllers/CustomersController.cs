using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller

         
    {

        List<Customer> CustomersList = new List<Customer>
            {
                new Customer {Name = "Jack" , Id = 1 },
                new Customer {Name = "Mary Jane", Id = 2 }
            };

        // GET: Customers
        public ActionResult Index()
        {
            //create List of Customers
           

            return View(CustomersList);
        }

        public ActionResult Details(int id)
        {
            Customer customer = CustomersList.Find(c => c.Id == id);

            return View(customer);
        }
    }
}