using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
   public  class Product
    {
        public Product(int productId, string productName,string description)
        {
            ProductId = productId;
            ProductName = productName;
            Description = description;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public string ShowProductDetails()
        {
            var details = "product: " + ProductName + " " + Description;
            return details;
        }

    }
}
