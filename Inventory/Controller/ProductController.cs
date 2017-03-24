using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HWA.ECom.Entity;
using HWA.ECom.Repository;

namespace HWA.ECom.Web.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View("ProductSearchUser");
        }

        public ActionResult IndexInsert()
        {
            return View();
        }

        //public ActionResult IndexDelete()
        //{
        //    return View();
        //}

        public ActionResult IndexUpdate(int id)
        {
            return View("IndexUpdate");
        }

        public ActionResult ShowTable()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EComLocalConnection"].ConnectionString;

            ProductRepository productRepository = new ProductRepository(connectionString);

            List<Product> product = productRepository.GetAll();

            return View("ShowAllMessageList", productRepository.GetAll());
        }

        public ActionResult ShowAllMessageList(List<Product> product)
        {
            return View(product);
        }

        public ActionResult ShowAllMessage(Product product)
        {
            return View(product);
        }

        public ActionResult Insert(Product input)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EComLocalConnection"].ConnectionString;
            ProductRepository productRepository = new ProductRepository(connectionString);

            productRepository.Insert(input);

            return View("ShowAllMessageList", productRepository.GetAll());
        }

        public ActionResult Delete(Int32 id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EComLocalConnection"].ConnectionString;

            ProductRepository productRepository = new ProductRepository(connectionString);

            productRepository.Delete(id);

            return View("ShowAllMessageList", productRepository.GetAll());
        }

        public ActionResult Update(Product input)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EComLocalConnection"].ConnectionString;
            ProductRepository productRepository = new ProductRepository(connectionString);

            productRepository.Update(input);

            return View("ShowAllMessageList", productRepository.GetAll());
        }

        public ActionResult Get(Int32 id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EComLocalConnection"].ConnectionString;
            ProductRepository productRepository = new ProductRepository(connectionString);

            return View("ShowAllMessage", productRepository.Get(id));
        }

        public ActionResult ShowMoreDetail(Int32 categoryId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EComLocalConnection"].ConnectionString;

            CategoryRepository categoryRepository = new CategoryRepository(connectionString);
            ViewBag.categoryName = categoryRepository.Get(categoryId).Name;

            ProductRepository productRepository= new ProductRepository(connectionString);

            return View("ShowAllMessageMoreDetail", productRepository.GetByCategoryId(categoryId));
        }

        public ActionResult ProductSearchAdm(Product product)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EComLocalConnection"].ConnectionString;

            ProductRepository productRepository = new ProductRepository(connectionString);

            return View("ShowProductSearchAdm", productRepository.GetByProductNameAdm(product.Name));
        }

        public ActionResult ProductSearchUser(Product product)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EComLocalConnection"].ConnectionString;

            ProductRepository productRepository = new ProductRepository(connectionString);

            return View("ShowProductSearchUser", productRepository.GetByProductNameUser(product.Name));
        }
    }
}