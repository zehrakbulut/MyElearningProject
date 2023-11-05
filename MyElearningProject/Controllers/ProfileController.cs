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
    }
}