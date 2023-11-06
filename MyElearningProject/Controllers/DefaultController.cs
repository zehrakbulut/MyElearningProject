using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class DefaultController : Controller
    {
        ELearningContext context = new ELearningContext();
        
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialCarousel()
        {
            var values = context.Features.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialService()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAboutPurpose()
        {
            var values = context.AboutPurposes.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialCategories()
        {
            var values = context.Categories.Take(3).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialCourses()
        {
            var values = context.Courses.Take(3).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTeam()
        {
            var values = context.Instructors.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
    }
}