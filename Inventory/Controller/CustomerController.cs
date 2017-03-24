using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HWA.ECom.Entity;
using HWA.ECom.Repository;

namespace HWA.ECom.Web.Controllers
{
    public class CustomerController : Controller
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
        
            CustomerRepository customerRepository = new CustomerRepository(connectionString);

            List<Customer> customers = customerRepository.GetAll();

            return View("ShowAllMessageList", customerRepository.GetAll());
        }

        public ActionResult ShowAllMessageList(List<Customer> customers)
        {
            return View(customers);
        }

        public ActionResult ShowAllMessage(Customer customer)
        {
            return View(customer);
        }

        public ActionResult Insert(Customer input)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EComLocalConnection"].ConnectionString;
            CustomerRepository customerRepository = new CustomerRepository(connectionString);

            customerRepository.Insert(input);

            return View("ShowAllMessageList", customerRepository.GetAll());
        }

        public ActionResult Delete(Int32 id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EComLocalConnection"].ConnectionString;

            CustomerRepository customerRepository = new CustomerRepository(connectionString);

            customerRepository.Delete(id);

            return View("ShowAllMessageList", customerRepository.GetAll());
        }

        public ActionResult Update(Customer input)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EComLocalConnection"].ConnectionString;
            CustomerRepository customerRepository = new CustomerRepository(connectionString);

            customerRepository.Update(input);

            return View("ShowAllMessageList", customerRepository.GetAll());
        }

        public ActionResult Get(Int32 id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EComLocalConnection"].ConnectionString;
            CustomerRepository customerRepository = new CustomerRepository(connectionString);

            return View("ShowAllMessage", customerRepository.Get(id));
        }

    }
}