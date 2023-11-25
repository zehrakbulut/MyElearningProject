using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
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

        [HttpGet]
        public ActionResult Index()
        {
            TempData["Location"] = "Profil";
            string values = Session["CurrentMail"].ToString();
            ViewBag.mail = Session["CurrentMail"];
            ViewBag.name = context.Instructors.Where(x => x.Email == values).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            int ınstructorID = context.Instructors.Where(x => x.Email == values).Select(y => y.InstructorID).FirstOrDefault();
            var ınstructorInformation = context.Instructors.Where(x => x.InstructorID == ınstructorID).FirstOrDefault();
            return View(ınstructorInformation);
        }
        [HttpPost]
        public ActionResult Index(Instructor ınstructor)
        {
            var value = context.Instructors.Find(ınstructor.InstructorID);
            value.Name = ınstructor.Name;
            value.Surname = ınstructor.Surname;
            value.ImageUrl = ınstructor.ImageUrl;
            value.Title = ınstructor.Title;
            value.CoverImage = ınstructor.CoverImage;
            value.Email = ınstructor.Email;
            value.Password = ınstructor.Password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult InstructorPanelPartial()
        {
            string mail = Session["CurrentMail"].ToString();
            int InstructorID = context.Instructors.Where(x => x.Email == mail).Select(y => y.InstructorID).FirstOrDefault();
            var InstructorInformations = context.Instructors.Where(x => x.InstructorID == InstructorID).ToList();
            ViewBag.courseCount = context.Courses.Where(x => x.InstructorID == InstructorID).Count();
            var egitmenID = context.Instructors.Where(x => x.InstructorID == InstructorID).Select(y => y.InstructorID).FirstOrDefault();

            var ınstructorCoursesList = context.Courses.Where(x => x.InstructorID == egitmenID).Select(y => y.CourseID).ToList();

            ViewBag.commentCount = context.Comments.Where(x => ınstructorCoursesList.Contains(x.CourseID)).Count();

            ViewBag.averageCourseReview = 9.5;

            return PartialView(InstructorInformations);
        }

        public PartialViewResult CommentPartial()
        {
            string mail = Session["CurrentMail"].ToString();
            var v1 = context.Instructors.Where(x => x.Email==mail).Select(y => y.InstructorID).FirstOrDefault();

            var v2 = context.Courses.Where(x => x.InstructorID == v1).Select(y => y.CourseID).ToList();

            var v3 = context.Comments.Where(x => v2.Contains(x.CourseID)).ToList();

            return PartialView(v3);
        }

        public PartialViewResult InstructorContactInformation()
        {
            string mail = Session["CurrentMail"].ToString();
            int v1 = context.Instructors.Where(x => x.Email == mail).Select(y => y.InstructorID).FirstOrDefault();
            var values = context.Instructors.Where(x => x.InstructorID == v1).FirstOrDefault();
            return PartialView(values);
        }

        
    }
}