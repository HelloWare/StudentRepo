using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWA.ECom.Entity
{
    public class Product : BaseEntity
    {
        //public Product(int id, int categoryId, string name, bool isActive)
        //{
        //    this.Id = id;
        //    this.CategoryId = categoryId;
        //    this.Name = name;
        //    this.IsActive = isActive;
        //}

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal StockQuantity { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasure { get; set; }
        public bool IsActive { get; set; }
        public int Sequence { get; set; }
        public string IconUrl { get; set; }
        public string PictureUrl { get; set; }
        public string Comment { get; set; }



 
    }
}
