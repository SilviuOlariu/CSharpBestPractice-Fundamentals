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
            this.MinimumPrice = 1.69;
            
        }

        public Product(int productId, string productName, string description) : this()
        {
            ProductId = productId;
            ProductName = productName;
            Description = description;
        }
        public readonly double MinimumPrice;
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public DateTime? AvailableOn { get; set; }
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
            var details = "product is: "+ Description +" with a  minimum price of " + MinimumPrice;
            
            return details;
        }

        public string SendDWelcomeMessagetoProductVendor()
        {
            

            string message = "welcome ";
         return   ProductVendor.SendWelcomeEmail(message);
        }

        public DateTime? availableDate()
        {
            //hard coded value for date;
            return AvailableOn?.ToLocalTime();

        }

    }
}
