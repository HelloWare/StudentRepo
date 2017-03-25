using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWA.ECom.Entity
{
   public class CustomerOrderProduct:BaseEntity
    {
        public CustomerOrderProduct(int CustomerOrderId, int ProductId)
        {
            this.CustomerOrderId = CustomerOrderId;
            this.ProductId = ProductId;
        }
        public int CustomerOrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Tax { get; set; }
        public string UnitOfMeasure { get; set; }
    
        public String Subtotal { get; set; }
    }
}
