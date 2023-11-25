using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class InstructorLayoutController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialPreloader()
        {
            return PartialView();
        }

        public PartialViewResult PartialHeader()
        {
            string mail = Session["CurrentMail"].ToString();
            ViewBag.NameSurname = context.Instructors.Where(x => x.Email == mail).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            ViewBag.Image = context.Instructors.Where(x => x.Email == mail).Select(y => y.ImageUrl).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }

        public PartialViewResult PartialRowPage()
        {
            return PartialView();
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
    }
}