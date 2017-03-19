using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWA.ECom.Entity
{
    public class Product
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal StockQuantity { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasure { get; set; }
        public bool IsActive { get; set; }
        public int Sequence { get; set; }
        public int CategoryId { get; set; }
        public string IconUrl { get; set; }
        public string PictureUrl{ get; set; }
    }
}
