using HWA.ECom.Entity;
using HWA.ECom.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWA.ECom.Web.Controllers
{
    public class CustomerOrderController : Controller
    {
        // GET: CustomerOrder
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get(Int32 id)
        {
            CustomerOrderRepository customerOrderRepository = new CustomerOrderRepository(ConstantUtil.AzureDb);

            CustomerOrder customerOrder = customerOrderRepository.GetById(id);
            if (customerOrder != null)
            {
                return View(customerOrder);
            }

            return View(customerOrder);
        }

        public ActionResult Insert(CustomerOrder model)
        {
            CustomerOrderRepository customerOrderRepository = new CustomerOrderRepository(ConstantUtil.AzureDb);


            //String connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //CategoryRepository categoryRepository = new CategoryRepository(connectionString);

            //if (customerOrderRepository.Insert(model))
            //    return View("Index", model);

            return View("Index", model);
        }
    }
}