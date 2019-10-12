using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDotSample.Controllers;
using System.Linq;
using System.Collections.Generic;

namespace MyDotSample.Test
{
    [TestClass]
    public class BaseModelTest
    {
        [TestCleanup]
        public void EraseData()
        {
            var context = new SampleContext();
            context.Customers.RemoveRange(context.Customers);
            context.SaveChanges();
        }

        [TestMethod]
        public void CreateBaseModelOnDB()
        {
            //Arrange
            var custObj = new Customer() {FirstName="Pepito",LastName="Shen"};
            var custController = new CustomerController();

            //Act
            custController.CreateCustomer(custObj);
            var custDB = custController.DbCtx.Set<Customer>().First();

            //Asset
            Assert.AreSame(custObj, custDB);
        }

        [TestMethod]
        public void CreateMasterDetailModelOnDB()
        {

            //Arrange
            var custObj = new Customer() { FirstName = "Pepito", LastName = "Shen" };
            var custController = new CustomerController();

            //Act
            custController.CreateCustomer(custObj);
            //Arrange
            var contactObj = new Contact()
            {
                FullName = "Contacto",
                //Customers = new List<Customer>() {
                //    new Customer() { FirstName="Andres",LastName="Taranto"}
                //}
                Customers = new List<Customer>()
            };
            contactObj.Customers.Add(custObj);
            var contactController = new ContactController();

            //Act
            contactController.CreateContact(contactObj);
            var contactDB = contactController.DbCtx.Set<Contact>().First();

            //Asset
            Assert.AreSame(contactObj, contactDB);
        }
    }
}
