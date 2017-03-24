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
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

            CategoryRepository categoryRepository = new CategoryRepository(connectionString);

            List<Category> category = categoryRepository.GetAll();

            return View("ShowAllMessageList", categoryRepository.GetAll());
        }

        public ActionResult ShowAllMessageList(List<Category> category)
        {
            return View(category);
        }

        public ActionResult ShowAllMessage(Category category)
        {
            return View(category);
        }

        public ActionResult Insert(Category input)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EComLocalConnection"].ConnectionString;
            CategoryRepository categoryRepository = new CategoryRepository(connectionString);

            categoryRepository.Insert(input);

            return View("ShowAllMessageList", categoryRepository.GetAll());
        }

        public ActionResult Delete(Int32 id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EComLocalConnection"].ConnectionString;

            CategoryRepository categoryRepository = new CategoryRepository(connectionString);

            categoryRepository.Delete(id);

            return View("ShowAllMessageList", categoryRepository.GetAll());
        }

        public ActionResult Update(Category input)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EComLocalConnection"].ConnectionString;
            CategoryRepository categoryRepository = new CategoryRepository(connectionString);

            categoryRepository.Update(input);

            return View("ShowAllMessageList", categoryRepository.GetAll());
        }

        public ActionResult Get(Int32 id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EComLocalConnection"].ConnectionString;
            CategoryRepository categoryRepository = new CategoryRepository(connectionString);

            return View("ShowAllMessage", categoryRepository.Get(id));
        }
    }
}