using HWA.ECom.Entity;
using HWA.ECom.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWA.ECom.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get(Int32 id)
        {
            CategoryRepository categoryRepository = new CategoryRepository(ConstantUtil.AzureDb);

            Category category = categoryRepository.Get(id);
            if (category != null)
            {
                return View(category);
            }

            return View(category);
        }

        public ActionResult Insert(Category model)
        {
            CategoryRepository categoryRepository = new CategoryRepository(ConstantUtil.AzureDb);


            //String connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //CategoryRepository categoryRepository = new CategoryRepository(connectionString);

            if (categoryRepository.Insert(model))
                return View("Index", model);

            return View("Index", model);
        }
    }
}