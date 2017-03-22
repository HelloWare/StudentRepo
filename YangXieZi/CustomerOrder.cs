using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
=======

>>>>>>> ba4d559d0ee9d18db1a8030d041e12ebde339c08
namespace HWA.ECom.Entity
{
    public class CustomerOrder:BaseEntity
    {
        public int CustomerId{ get; set; }
<<<<<<< HEAD
        public string Status { get; set; }
=======
        public int StatusId { get; set; }
>>>>>>> ba4d559d0ee9d18db1a8030d041e12ebde339c08
        public decimal GrandTotal { get; set; }
        public string PaymentType { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipToAddressId { get; set; }
        public string OrderNumber { get; set; }
<<<<<<< HEAD
=======
        
>>>>>>> ba4d559d0ee9d18db1a8030d041e12ebde339c08
    }
}
