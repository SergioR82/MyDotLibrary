using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDotSample.Controllers;
using System.Linq;

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
    }
}
