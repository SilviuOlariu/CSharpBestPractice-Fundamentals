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
            var product = new Product(1,"Paper","desc");
         

            //act
            var result = product.ShowProductDetails();

            //assert
            Assert.AreEqual("product: Paper desc", result);
            
        }
    }
}
