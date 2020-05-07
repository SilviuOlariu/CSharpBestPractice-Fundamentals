using Acme.Biz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BizTests
{
    [TestClass()]
  public class ProductTests
    {
        [TestMethod()]
        public void ShowProductDetail()
        {
            //arrange
            var product = new Product(1,"Chair","Smart chaire");
            var expect = "product is: Smart chaire with a  minimum price of 1.69";

            //act
            var result = product.ShowProductDetails();

            //assert
            Assert.AreEqual(expect, result);
            
        }

        [TestMethod()]
        public void SendMessageToVendor()
        {
            //arrange
            var product = new Product();

            var result= product.SendDWelcomeMessagetoProductVendor();

            Assert.AreEqual("Message sent: Hello",result);
        }

        [TestMethod()]
        public void AvailableDate()
        {
            var product = new Product();

            var expected = product.availableDate();

            Assert.AreEqual(null, expected);
        }

        [TestMethod()]
        public void ProductNameToShort()
        {
            //arrange
            var product = new Product();
            
             product.ProductName = "AB";
            //act
            string expected = null;
            var expectedMessage = product.ValidationProduct;

            //assert

            Assert.AreEqual(expected, product.ProductName);
            Assert.AreEqual(expectedMessage, product.ValidationProduct);
        }

        [TestMethod()]
        public void ProductCode()
        {
            //arrange 
            var product = new Product();
            product.Category = "general";
            product.SequenceNumber = 1;

            //act
            var expected = "general-1";

            //assert
            Assert.AreEqual(expected, product.ProductCode);
        }

        [TestMethod()]
        public void CalculateSuggestedPrice()
        {
            var product = new Product();
            product.Cost = 100;

            var expected = product.CalculateSuggestedPrice(10);

            Assert.AreEqual(110, expected, 0);
        }


    }
}
