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
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Product product)
        {
            ProductRepository productRespository = new ProductRepository(ConstantUtil.MyConnectionString);

            productRespository.Insert(product);

            return View(product);
        }
    }
}