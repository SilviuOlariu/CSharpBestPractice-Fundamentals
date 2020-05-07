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
        public string ValidationProduct { get; set; } 
        public readonly double MinimumPrice;
        public int ProductId { get; set; }
        public string Description { get; set; }
        public DateTime? AvailableOn { get; set; }
        public Vendor ProductVendor { get; set;}
        public string Category { get; set; }
        public int SequenceNumber { get; set; }
        public string ProductCode => Category + "-" + SequenceNumber.ToString();
        private string productName;
        public double Cost;
        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                if(value.Length <=3)
                {
                    ValidationProduct = "Product must have at least 3 characters";
                }
                else
                {
                    productName = value;
                }
              
            }
        }

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

        public double CalculateSuggestedPrice(double Percent)
            => this.Cost + (this.Cost * Percent / 100);

    }
}
