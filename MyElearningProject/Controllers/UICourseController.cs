using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class UICourseController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHeader()
        {
            return PartialView();
        }

        public PartialViewResult PartialCategories()
        {
            var values = context.Categories.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialCourses()
        {
            var values = context.Courses.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
    }
}