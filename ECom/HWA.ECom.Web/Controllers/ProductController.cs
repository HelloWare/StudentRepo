using HWA.Ecom.Repository;
using HWA.ECom.Entity;
using HWA.ECom.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWA.ECom.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepo = new ProductRepository(ConstantUtil.MyConnectionString);
        CustomerRepository customerRepo = new CustomerRepository(ConstantUtil.MyConnectionString);

        Customer customer;
        ShoppingCart shoppingCart;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InsertView()
        {
            return View();
        }

        public ActionResult ShowDetail(int id)
        {

            return View("ShowDetail", productRepo.GetById(id));
        }

        public ActionResult Insert(Product product)
        {
            productRepo.Insert(product);
            Product _product = new Product(product.CategoryId);
            _product = productRepo.GetByName(product.Name);
            return View("ShowDetail", _product);
        }

        public ActionResult ShowAllList()
        {

            return View(productRepo.GetAll());
        }

        public ActionResult Delete(int id)
        {
            productRepo.Delete(id);
            return View("ShowAllList", productRepo.GetAll());
        }

        public ActionResult Edit(int id)
        {

            return View(productRepo.GetById(id));
        }

        public ActionResult Update(Product product)
        {
            productRepo.Update(product);
            return View("ShowDetail", productRepo.GetById(product.Id));
        }


        public String AddToCart(int id)
        {
            //not supposed to be here, should be after login event
            customer = customerRepo.GetById(1);
            shoppingCart = new ShoppingCart(customer.Id);
            // create a ShoppingCartRepository scr object
            //use scr to save shoppingCart
            ShoppingCartRepository scr = new ShoppingCartRepository(ConstantUtil.MyConnectionString);
            scr.Insert(shoppingCart);


            ShoppingCartProduct scp = new ShoppingCartProduct(shoppingCart.Id, id);
            scp.Quantity = 100;
            //create a ShoppinngCartProductRepository scpr
            //use scpr to save scp
            ShoppingCartProductRepository scpr = new ShoppingCartProductRepository(ConstantUtil.MyConnectionString);
            scpr.Create(scp);
            return "Add product " + id + " to the cart successfully!";
        }
    }
}