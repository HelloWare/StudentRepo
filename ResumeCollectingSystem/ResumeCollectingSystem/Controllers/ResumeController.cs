using ResumeCollectingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeCollectingSystem.Controllers
{
    public class ResumeController : Controller
    {
        // GET: Resume
        public ActionResult Index()
        {
            ViewBag.Degrees = new SelectList(DegreeRepo.GetAll(),"Id","Name");
            ViewBag.Genders = new SelectList(GenderRepo.GetAll(), "Id", "Name");
            ViewBag.Positons = new SelectList(PositionRepo.GetAll(), "Id", "Name");

            return View();
        }
    }
}