using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class ProfileController : Controller
    {

        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            string values = Session["CurrentMail"].ToString();
            ViewBag.mail = Session["CurrentMail"];    
            ViewBag.name=context.Students.Where(x=>x.Email==values).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            return View();
        }

        public ActionResult MyCourseList()
        {
            string values = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
            var courseList = context.Processes.Where(x => x.StudentID == id).ToList();
            return View(courseList);
        }

        public PartialViewResult StudentInformationPartial()
        {

            return PartialView();
        }

        public PartialViewResult StudentActivityPartial()
        {
            string values = Session["CurrentMail"].ToString();
            int studentID = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
            ViewBag.studentName = context.Students.Where(x => x.StudentID == studentID).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            var comments = context.Comments.Where(x => x.StudentID == studentID).ToList();
            return PartialView(comments);
        }

        public PartialViewResult StudentProfilePartial()
        {
            return PartialView();
        }

        public PartialViewResult StudentSettingsPartial()
        {
            return PartialView();
        }
    }
}