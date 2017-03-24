using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWA.ECom.Entity
{
    public class ShoppingCart : BaseEntity
    {
        public ShoppingCart(int customerId)
        {
            this.CustomerId = customerId;
        }
        public int CustomerId
        {
            get; set;
        }
        public decimal GrandTotal
        {
            get; set;
        }
    }
}
