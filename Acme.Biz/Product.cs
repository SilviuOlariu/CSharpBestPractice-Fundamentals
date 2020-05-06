using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
   public  class Product
    {
        public Product()
        {
           ProductVendor = new Vendor();

        }

        public Product(int productId, string productName, string description) : this()
        {
            ProductId = productId;
            ProductName = productName;
            Description = description;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public Vendor ProductVendor { get; set;}

        //-instantiate an object through the lazy loading method
        //public Vendor ProductVendor
        //{
        //    get
        //    {
        //        return new Vendor();
        //    }
        //    set { }
        //}

        public string ShowProductDetails()
        {
         

            var details = "product: " + ProductName + " " + Description;
            
          
            return details;
        }

        public string SendDWelcomeMessagetoProductVendor()
        {
            

            string message = "welcome ";
         return   ProductVendor.SendWelcomeEmail(message);
        }

    }
}
