using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class UIAboutController : Controller
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
    }
}