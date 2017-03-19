using HWA.ECom.Entity;
using HWA.Ecom.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace HWA.Ecom.Wed.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Create";

            return View();
        }

        public ActionResult CreateResult(ShoppingCartProduct model)
        {
            ViewBag.Message = "Test";
            if (HWA.Ecom.Repository.ShoppingCartProductRepository.Create(model))
            {
                ViewBag.Message = "Created Success!";
            }
            else
            {
                ViewBag.Message = "Created failed!";
            }
            return View();
        }

        public ActionResult Update()
        {
            ViewBag.Message = "Update";

            return View();
        }

        public ActionResult UpdateResult(ShoppingCartProduct model)
        {   
            if (HWA.Ecom.Repository.ShoppingCartProductRepository.Update(model))
            {
                ViewBag.Message = "Updated Success!";
            }
            else
            {
                ViewBag.Message = "Updated failed!";
            }
            return View();
        }

        public ActionResult Delete()
        {
            ViewBag.Message = "Delete";

            return View();
        }

        public ActionResult DeleteResult(ShoppingCartProduct model)
        {
            if (HWA.Ecom.Repository.ShoppingCartProductRepository.Delete(model.Id))
            {
                ViewBag.Message = "Delete Successfully!";
            }
            else
            {
                ViewBag.Message = "Delete failed!";
            }
            return View();
        }

        public ActionResult SelectById()
        {
            ViewBag.Message = "SelectById";

            return View();
        }

        public ActionResult SelectByIdResult(ShoppingCartProduct shoppingCartProduct)
        {
            shoppingCartProduct = ShoppingCartProductRepository.SelectById(shoppingCartProduct.Id);            
            return View(shoppingCartProduct);
        }

        public ActionResult TestSearch ()
        {
            ViewBag.Message = "TestSearch";

            return View();
        }

        public ActionResult Search(ShoppingCartProduct shoppingCartProduct)
        {
            List<ShoppingCartProduct> shoppingCartProductList = new List<ShoppingCartProduct> { };
            shoppingCartProductList = ShoppingCartProductRepository.Search(shoppingCartProduct.ShoppingCartId);           
            return View(shoppingCartProductList);
        }        
    }
}