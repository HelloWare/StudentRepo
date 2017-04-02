using Microsoft.AspNet.Identity.Owin;
using ResumeCollectingSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeCollectingSystem.Controllers
{
    [Authorize(Users ="deyikong@yahoo.com")]
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            ViewBag.Users = new SelectList(db.Users, "Id", "Email");
           
            //ViewBag.Roles = dbContext.Roles.ToList().Select(x => new SelectListItem
            //{
            //    Text = x.Id,
            //    Value = x.Name
            //});
            ViewBag.Roles = new SelectList(db.Roles, "Id", "Name");
            return View();
        }

        // HOST: Role
        [HttpPost]
        public String Index(UserRoleModel model)
        {
            UserRoleModelRepo repo = new UserRoleModelRepo(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            repo.Save(model.UserId, model.RoleId);
            return "Assign successfully";
        }
    }
}