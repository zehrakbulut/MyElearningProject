using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class StudentLayoutController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialHead()
        {
            return PartialView();
        }

        public ActionResult PartialPreloader()
        {
            return PartialView();
        }

        public ActionResult PartialHeader()
        {
            string values = Session["CurrentMail"].ToString();
            ViewBag.studentName = values;
            int id = context.Students.Where(x => x.Name == values).Select(y => y.StudentID).FirstOrDefault();
            return PartialView();
        }

        public ActionResult PartialSidebar()
        {
            return PartialView();
        }

        public ActionResult PartialRowPage()
        {
            return PartialView();
        }

        public ActionResult PartialFooter()
        {
            return PartialView();
        }

        public ActionResult PartialScript()
        {
            return PartialView();
        }
    }
}