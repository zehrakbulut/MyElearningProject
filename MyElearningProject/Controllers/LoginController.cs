using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyElearningProject.Controllers
{
    public class LoginController : Controller
    {

        ELearningContext context = new ELearningContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Student student)
        {
            var values = context.Students.FirstOrDefault(x => x.Email == student.Email && x.Password == student.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Email, false);
                Session["CurrentMail"] = values.Email;
                Session.Timeout = 60;
                return RedirectToAction("Index", "Profile");
            }
            return View();
        }
    }
}