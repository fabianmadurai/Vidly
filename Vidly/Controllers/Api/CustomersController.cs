using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;
using Vidly.Models;


namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/Customers    - Notice that for web api routing, there is no action
        //name in default routing, check out the webapiconfig.cs file.
        //The http method , get, put, post etc, determines which action gets called.
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();

        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            //Its possible that this customer does not exist , so the query above will returb
            //a null (default).therefore we handle that

            if(customer ==null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        //Notice the return type is IHttpActionResult. that gives us more control over the
        //status codes returned, because for webapi, successful customer create should be 
        //201, not 200.
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            //Line below will return the uri of the newly created customer.
            //..so something like ...http://localhost/api/customers/10
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customer);
        }

        [HttpPut]
        //PUT /api/customer/1
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }


            customerInDb.Name = customer.Name;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.Birthdate = customer.Birthdate;
            //notice for the update, we did not say _context.Customers.Add();
            _context.SaveChanges();

        }

        //DELETE /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

        }
    }
}
