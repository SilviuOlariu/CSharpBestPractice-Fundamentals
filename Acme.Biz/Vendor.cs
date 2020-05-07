using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages the vendors from whom we purchase our inventory.
    /// </summary>
    public class Vendor 
    {
        public Vendor()
        {

        }
        public Vendor(int id, string companyName, string email):this()
        {
            VendorId = id;
            CompanyName = companyName;
            Email = email;

        }

        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <param name="deliveryBy"></param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity, DateTimeOffset deliveryBy)
        {
            
            if(product ==null)
            {
                throw new NullReferenceException(nameof(product));
            }
            if(quantity <1)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));

            }
            if(deliveryBy >=DateTimeOffset.Now)
            {
                throw new ArgumentOutOfRangeException(nameof(deliveryBy));
            }

            bool sent = false;
            string message = "";
            var orderText = $"Order {product.ProductName} delivered by {deliveryBy}";

            var emailService = new EmailService();
           var email= emailService.SendMessage("new order", orderText, this.Email);
            if (email.Contains("Message sent"))
            {
                sent = true;
                message = "successfully processed the order";
            }
            else
            {
                sent = false;
                message = "unable to process the order";
            }
            var operationResult = new OperationResult(sent, message);

            return operationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity)
        {
            bool sent = false;
            string message = "";
        
            if (product == null)
            {
              throw new ArgumentNullException(nameof(product));
             }
            if(quantity <1)
            {
             throw new ArgumentOutOfRangeException(nameof(quantity));
            }
           
            var orderText = $"product {product.ProductName} from Acme in quantity of {quantity} ";

           
            var emailService = new EmailService();
            var subject = $"Hello, you have sent an order";
            var recepit = "example@eu.ro";
           var confirmation =  emailService.SendMessage(subject, orderText, recepit);
            if (confirmation.Contains("Message sent"))
            {
                sent = true;
                message = "successfully processed the order";
            }
            else
            {
                sent = false;
                message = "unable to process the order";
            }
            var operationResult = new OperationResult(sent, message);

            return operationResult;
        }
        /// <summary>
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ("Hello " + this.CompanyName).Trim();
            var confirmation = emailService.SendMessage(subject,
                                                        message, 
                                                        this.Email);
            return confirmation;
        }
    }
}
