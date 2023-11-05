using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class InstructorAnalysisController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            TempData["Location"] = "InstructorAnalaysis";
            return View();
        }

        public PartialViewResult InstructorPanelPartial()
        {
            int id = 1;
            var values = context.Instructors.Where(x => x.InstructorID == id).ToList();
            var v1 = context.Instructors.Where(x => x.Name == "Yusuf" && x.Surname == "Bulut").Select(y => y.InstructorID).FirstOrDefault();
            ViewBag.courseCount = context.Courses.Where(x => x.InstructorID == 1).Count();

            var v2 = context.Courses.Where(x => x.InstructorID == v1).Select(y => y.CourseID).ToList();


            ViewBag.commentCount = context.Comments.Where(x => v2.Contains(x.CourseID)).Count();

            return PartialView(values);
        }

        public PartialViewResult CommentPartial()
        {
            var v1 = context.Instructors.Where(x => x.Name == "Yusuf" && x.Surname == "Bulut").Select(y => y.InstructorID).FirstOrDefault();
            ViewBag.courseCount = context.Courses.Where(x => x.InstructorID == 1).Count();

            var v2 = context.Courses.Where(x => x.InstructorID == v1).Select(y => y.CourseID).ToList();

            var v3 = context.Comments.Where(x => v2.Contains(x.CourseID)).ToList();

            return PartialView(v3);
        }

        public PartialViewResult CourseListByInstructor()
        {
            var values = context.Courses.Where(x => x.InstructorID == 1).ToList();
            return PartialView(values);
        }
    }
}