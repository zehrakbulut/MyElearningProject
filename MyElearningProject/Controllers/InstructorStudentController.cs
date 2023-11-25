using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class InstructorStudentController : Controller
    {

        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            TempData["Location"] = "Öğrencilerim";
            string mail = Session["CurrentMail"].ToString();
            int id = context.Instructors.Where(x => x.Email == mail).Select(y => y.InstructorID).FirstOrDefault();
            var includeTables = context.CourseRegisters.Include("Course").Include("Student").ToList();
            var instructerStudents = includeTables.Where(x => x.Course.InstructorID == id).ToList();
            return View(instructerStudents);
        }
    }
}