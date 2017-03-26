using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWA.ECom.Entity
{

    public class ShoppingCartProduct:BaseEntity
    {
        public ShoppingCartProduct(int shoppinngCartId,int productId)
        {
            this.ShoppingCartId = shoppinngCartId;
            this.ProductId = productId;

                                
        }
        public int ShoppingCartId
        {
            get; set;
        }
        public int ProductId
        {
            get; set;
        }
        public decimal Quantity
        {
            get; set;
        }
        public decimal UnitPrice
        {
            get; set;
        }
        public string UnitOfMeasure     
        {
            get; set;
        }
        public decimal SubTotal
        {
            get; set;
        }
    }
}
