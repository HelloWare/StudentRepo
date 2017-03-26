using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HWA.ECom.Repository;
using HWA.ECom.Entity;

namespace HWA.ECom.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepo = new CategoryRepository(ConstantUtil.EComDb);

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

            return View("ShowDetail", categoryRepo.GetById(id));
        }

        public ActionResult Insert(Category category)
        {
            categoryRepo.Insert(category);
            Category customer_0 = new Category();
            customer_0 = categoryRepo.GetByName(category.Name);
            return View("ShowDetail", customer_0);
        }

        public ActionResult ShowAllList()
        {

            return View(categoryRepo.GetAll());
        }

        public ActionResult Delete(int id)
        {
            categoryRepo.Delete(id);
            return View("ShowAllList", categoryRepo.GetAll());
        }

        public ActionResult Edit(int id)
        {

            return View(categoryRepo.GetById(id));
        }

        public ActionResult Update(Category category)
        {
            categoryRepo.Update(category);
            return View("ShowDetail", categoryRepo.GetById(category.Id));
        }
    }
}