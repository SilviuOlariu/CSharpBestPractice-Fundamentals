using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorTests
    {
        [TestMethod()]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "ABC Corp";
            var expected = "Message sent: Hello ABC Corp";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "";
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = null;
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PlaceOrderSuccessfullySent()
        {
            //arrange
            var product = new Product();
            product.ProductName = "Fruits";

            var vendor = new Vendor();

            //act
           var actual = vendor.PlaceOrder(product, 2);

            //asert

            Assert.AreEqual(actual.Success, true);
            Assert.AreEqual(actual.Message, "successfully processed the order");
           
        }

        [TestMethod()]
        public void PlaceOrderDeliveredBy()
        {
            //arrange
            var product = new Product();
            product.ProductName = "Fruits";
            var vendor = new Vendor();
            var expected = new OperationResult(true, "successfully processed the order");
            var deliveredby = new DateTimeOffset(DateTime.Now);
            //act

           var actual = vendor.PlaceOrder(product, 1, deliveredby);

            //assert

            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);


        }
        [TestMethod()]
        public void VendorToString()
        {
            var vendor = new Vendor();
            vendor.CompanyName = "Endava";
            var expected = "Vendor: Endava";

            var act = vendor.ToString();

            Assert.AreEqual(expected,act);
        }
    }
}