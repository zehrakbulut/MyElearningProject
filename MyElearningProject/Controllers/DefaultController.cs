using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialCarousel()
        {
            return PartialView();
        }

        public PartialViewResult PartialService()
        {
            return PartialView();
        }

        public PartialViewResult PartialAbout()
        {
            return PartialView();
        }

        public PartialViewResult PartialCategories()
        {
            return PartialView();
        }

        public PartialViewResult PartialCourses()
        {
            return PartialView();
        }

        public PartialViewResult PartialTeam()
        {
            return PartialView();
        }

        public PartialViewResult PartialTestimonial()
        {
            return PartialView();
        }
    }
}