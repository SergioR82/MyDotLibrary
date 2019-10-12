using System.Collections.Generic;
using System.Web.Mvc;
using MyDotLibrary;

namespace MyDotSample.Controllers
{
    public class ContactController : BaseController<Contact, SampleContext>
    {
        public ActionResult Index()
        {
            var contact = new Contact()
            {
                FullName = "Contacto",
                Customers = new List<Customer>() {
                    new Customer() { FirstName="Andres",LastName="Taranto"}
                }
            };
            

            return View("ContactViewModel", contact);
        }

        [HttpPost]
        public ActionResult CreateContact(Contact contact)
        {
            base.Create(contact);
            return View("ContactViewModel");
        }
    }
}
