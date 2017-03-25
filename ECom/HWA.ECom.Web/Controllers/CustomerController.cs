using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HWA.ECom.Entity;
using HWA.ECom.Repository;

namespace HWA.ECom.Web.Controllers
{
    public class CustomerController : Controller
    {

        CustomerRepository customerRepo = new CustomerRepository(ConstantUtil.EComDb);

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InsertView()
        {
            return View();
        }

        public ActionResult Insert(Customer customer)
        {
            customerRepo.Insert(customer);
            Customer customer_0 = new Customer();
            customer_0 = customerRepo.GetByName(customer.UserName);
            return View("ShowDetail",customer_0);
        }

        public ActionResult ShowAllList()
        {
            
            return View(customerRepo.GetAll());
        }

        public ActionResult Delete(int id)
        {
            customerRepo.Delete(id);
            return View("ShowAllList",customerRepo.GetAll());
        }

        public ActionResult Edit(int id)
        {
            
            return View(customerRepo.GetById(id));
        }

        public ActionResult Update(Customer customer)
        {
            customerRepo.Update(customer);
            return View("ShowDetail", customerRepo.GetById(customer.Id));
        }



    }
}