using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyDotLibrary;

namespace MyDotSample.Controllers
{
	public class CustomerController : BaseController<Customer, SampleContext>
	{	
        public ActionResult Index()
        {
			return View("CustomerViewModel", new Customer(){FirstName= "hola", LastName="mundo"});
        }

        [HttpPost]
        public ActionResult CreateCustomer(Customer cust) {
            base.Create(cust);
            return View("CustomerViewModel");
        }
    }
}
