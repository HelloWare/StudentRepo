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
        CustomerRepository customerRepo = new CustomerRepository(ConstantUtil.MyConnectionString);

        Customer customer;
        ShoppingCart shoppingCart; 
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public String AddToCart(int id)
        {
            //not supposed to be here, should be after login event
            customer = customerRepo.Get(1);
            shoppingCart = new ShoppingCart(customer.Id);
            // create a ShoppingCartRepository scr object
            //use scr to save shoppingCart


            ShoppingCartProduct scp = new ShoppingCartProduct(shoppingCart.Id, id);
            //create a ShoppinngCartProductRepository scpr
            //use scpr to save scp
            return "Add product " + id + " to the cart successfully!";
        }

        public ActionResult ListAllProducts()
        {
            ProductRepository productRepository = new ProductRepository(ConstantUtil.MyConnectionString);
            IEnumerable<Product> products = productRepository.GetAll();
            return View(products);
        }
        public ActionResult Create(Product product)
        {
            ProductRepository productRespository = new ProductRepository(ConstantUtil.MyConnectionString);

            productRespository.Insert(product);

            return View(product);
        }
    }
}