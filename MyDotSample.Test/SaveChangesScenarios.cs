using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyDotSample.Test
{
    [TestClass]
    public class SaveChangesScenarios
    {
        [TestMethod]
        public void CreateAllObjectsInTree()
        {
            //Arrange
            var dbctx = new SampleContext();
            var custObj = new Customer() { FirstName = "Pepito", LastName = "Shen" };
            var contactObj = new Contact()
            {
                FullName = "MyContact",
                Customers = new List<Customer>()
            };
            contactObj.Customers.Add(custObj);

            //Act
            dbctx.Contacts.Add(contactObj);
            dbctx.SaveChanges();

            var contactDB = dbctx.Contacts.FirstOrDefault(c => c.FullName == "MyContact");

            //Asset
            Assert.AreSame(contactObj, contactDB);
        }

        [TestMethod]
        public void CreateContactEditCustomer()
        {
            //Arrange
            var dbctx = new SampleContext();
            var custObj = new Customer() { FirstName = "Diego", LastName = "Maradona" };

            var contactObj = new Contact()
            {
                FullName = "MyContact2",
                Customers = new List<Customer>()
            };

            //Act
            dbctx.Customers.Add(custObj);
            dbctx.SaveChanges();

            custObj.FirstName = "Diego Armando";
            contactObj.Customers.Add(custObj);

            dbctx.Contacts.Add(contactObj);
            dbctx.SaveChanges();

            var contactDB = dbctx.Contacts.FirstOrDefault(c => c.FullName == "MyContact2");

            //Asset
            Assert.AreSame(contactObj, contactDB);
        }

        [TestMethod]
        public void CreateContactAssignCustomerCreatingIt()
        {
            //Arrange
            var dbctx = new SampleContext();
            var custObj = new Customer() { FirstName = "Diego Armando", LastName = "Maradona" };

            var contactObj = new Contact()
            {
                FullName = "MyContact2",
                Customers = new List<Customer>()
            };

            //Act
            dbctx.Customers.Add(custObj);
            dbctx.SaveChanges();

            contactObj.Customers.Add(custObj);
            dbctx.Contacts.Add(contactObj);
            dbctx.SaveChanges();

            var custCount = dbctx.Customers.Count(cust => cust.LastName == "Maradona");

            //Asset
            Assert.AreEqual(1, custCount);
        }

        [TestMethod]
        public void CreateContactAssignCustomerWithoutCreatingIt()
        {
            //Arrange
            var dbctx = new SampleContext();
            //Se asume que ya existe un Diego Armando Maradona con id 1005.
            var custObj = new Customer() { Id = 1, LastName = "Maradona" };

            var contactObj = new Contact()
            {
                FullName = "ThisIsANewContact",
                Customers = new List<Customer>()
            };

            //Act

            dbctx.Contacts.Remove(
                dbctx.Contacts.FirstOrDefault(cont => cont.FullName == "MyContact2")
                );
            dbctx.SaveChanges();

            contactObj.Customers.Add(custObj);
            dbctx.Contacts.Add(contactObj);
            dbctx.SaveChanges();

            var custCount = dbctx.Customers.Count(cust => cust.LastName == "Maradona");

            //Asset
            Assert.AreEqual(1, custCount);
        }
    }
}
