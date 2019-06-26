using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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
            //Get Membership Types from db so that you can use it in a dropdown in the view.
            var membershiptypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
               
                MembershipTypes = membershiptypes
            };

            //used in if statement at top of view to set the Heading of page, based on what we are doing, ie. New or edit.
            TempData["FormType"] = "New";


            //below we ovveride the MVC convention to look for view with the same name
            //as the method. We specify the method.remember we do this because we are using the 
            //same view and model for the new and edit methods and views.
            return View("CustomerForm",viewModel);
        }

        //even though the model in the view is of type NewCustomerViewModel, 
        //The fields in the form were from the Customer model, and you can see in the Network header
        //in chrome developer tab, that the form data being sent all are prefixed with Customer.
        //Hence in this post method, we can use the Customer model and MVC knows to bind the form data 
        //with the customer model.
        [HttpPost]
        public ActionResult Save(Customer customer)  //Model Binding at work
        {
            //We are using this method for both save and edit.
            //hence we first check if the customer has an Id or not. If not, then its a new customer.
            //if yes, then its an existing customer and we do an edit.

            if(customer.Id==0)  // Id was saved in the form in a hidden field. see the view, just above the save button.
                // line below is just in memory for now.
                _context.Customers.Add(customer);
            else
            {
                //To edit a customer, we first have to get that record from the db
                //then we can change it with values that we got from the form.
                //we explicity use single and not single or default, because we want that exact customer.
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //You can check out TryUpdateModel() in the asp docs, but its risky and its safer
                //to update the model manually and explicity like so...
                //also there are tools like AutoMapper that can save some time.
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            }

              //persist from memory to db
            _context.SaveChanges();

            //redirect user once saved to a useful page 
            return RedirectToAction("Index", "Customers");
        }

        //In this case, For editing a customer we will use the same form and viewmodel as we do for creating a customer.
        //but we will pre-populate the form with the data for the customer with id that we pass to the Edit method.
         
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            //check for nulls
            if(customer == null)
            {
                return HttpNotFound(); //Standard 404 error
            }

            //this Edit method received the Id of the customer to edit. 
            //hence we can populate the viewModel with customer data already 
            // and we can get the membership types from the DB
            // Hence, when the user goes to the view to edit the customer, they have
            //all the info in the view to edit already.


            //used in if statement at top of view to set the Heading of page, based on what we are doing, ie. New or edit.
            TempData["FormType"] = "Edit";

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            //below we ovveride the MVC convention to look for view with the same name
            //as the method. We specify the method. remember we do this because we are using the 
            //same view and model for the new and edit methods and views.
            return View("CustomerForm",viewModel);
        }
    }
}