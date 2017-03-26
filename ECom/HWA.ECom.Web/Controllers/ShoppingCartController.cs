using HWA.Ecom.Repository;
using HWA.ECom.Entity;
using HWA.ECom.Repository;
using HWA.ECom.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWA.ECom.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListShoppingCartProducts()
        {
            ShoppingCartProductRepository scpr = new ShoppingCartProductRepository(ConstantUtil.MyConnectionString);
            IEnumerable<ShoppingCartProduct> shoppingCartProducts = scpr.GetAll();
            return View(shoppingCartProducts);
        }
        //public String CheckOut(IEnumerable<ShoppingCartProduct> Model)
        //{
        //    CustomerRepository customerRepo = new CustomerRepository(ConstantUtil.MyConnectionString);
        //    Customer customer = customerRepo.GetById(1);
        //    CustomerOrder co = new CustomerOrder(1, 25);
        //    CustomerOrderRepository cor = new CustomerOrderRepository(ConstantUtil.MyConnectionString);
        //    int orderId = cor.Insert(co);

        //    List<CustomerOrderProduct> cops = new List<CustomerOrderProduct>();
        //    foreach (int scp in myModel.products)
        //    {
        //        CustomerOrderProduct temp = new CustomerOrderProduct(orderId, scp);
        //        ProductRepository pr = new ProductRepository(ConstantUtil.MyConnectionString);
        //        Product prod = pr.GetById(scp);
        //        temp.Quantity = 100;
        //        temp.UnitOfMeasure = prod.UnitOfMeasure;
        //        temp.UnitPrice = prod.UnitPrice;
        //        temp.CreatedBy = prod.CreatedBy;
        //        temp.CreatedDate = prod.CreatedDate;
        //        temp.LastModifiedBy = prod.LastModifiedBy;
        //        temp.LastModifiedDate = prod.LastModifiedDate;
        //        temp.Subtotal = 0;
        //        cops.Add(temp);
        //    }
        //    return "Successfully";
        //}

        public String CheckOut()
        {
            CustomerRepository customerRepo = new CustomerRepository(ConstantUtil.MyConnectionString);
            Customer customer = customerRepo.GetById(1);
            CustomerOrder co = new CustomerOrder(1, 25);
            CustomerOrderRepository cor = new CustomerOrderRepository(ConstantUtil.MyConnectionString);
            int orderId = cor.Insert(co);

            List<CustomerOrderProduct> cops = new List<CustomerOrderProduct>();
            ShoppingCartProductRepository scpr = new ShoppingCartProductRepository(ConstantUtil.MyConnectionString);
            IEnumerable<ShoppingCartProduct> myModel = scpr.GetAll();
            foreach (ShoppingCartProduct scp in myModel)
            {
                CustomerOrderProduct temp = new CustomerOrderProduct(orderId, scp.ProductId);
                //ProductRepository pr = new ProductRepository(ConstantUtil.MyConnectionString);
                //Product prod = pr.GetById(scp);
                temp.Quantity = scp.Quantity;
                temp.UnitOfMeasure = scp.UnitOfMeasure;
                temp.UnitPrice = scp.UnitPrice;
                temp.CreatedBy = scp.CreatedBy;
                temp.CreatedDate = scp.CreatedDate;
                temp.LastModifiedBy = scp.LastModifiedBy;
                temp.LastModifiedDate = scp.LastModifiedDate;
                temp.Subtotal = scp.SubTotal;
                //cops.Add(temp);

                CustomerOrderProductRepository copr = new CustomerOrderProductRepository(ConstantUtil.MyConnectionString);
                copr.Insert(temp);
            }
            return "Successfully";
        }
    }
}