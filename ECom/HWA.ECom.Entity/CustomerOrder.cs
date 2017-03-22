using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HWA.ECom.Entity
{
    public class CustomerOrder:BaseEntity
    {
        public int CustomerId{ get; set; }
        public int StatusId { get; set; }
        public decimal GrandTotal { get; set; }
        public string PaymentType { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipToAddressId { get; set; }
        public string OrderNumber { get; set; }
        
    }
}
