using HWA.ECom.Entity;
using HWA.ECom.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWA.ECom.Web.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListAllOrders()
        {
            CustomerOrderRepository cor = new CustomerOrderRepository(ConstantUtil.MyConnectionString);
            List<CustomerOrder> customerOrders = cor.GetAll();
            return View(customerOrders);
        }

        public String Delete(int id)
        {
            CustomerOrderRepository cor = new CustomerOrderRepository(ConstantUtil.MyConnectionString);
            cor.Delete(id);
            return "You successfully deleted the order with id: " + id;
        }

        public ActionResult Edit(int id)
        {
            
            return View();
        }
    }
}