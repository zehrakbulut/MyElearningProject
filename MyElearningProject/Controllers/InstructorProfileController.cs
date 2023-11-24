using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class InstructorProfileController : Controller
    {
        ELearningContext context = new ELearningContext();

        [HttpGet]
        public ActionResult Index()
        {
            TempData["Location"] = "Profil";
            string value = Session["CurrentMail"].ToString();
            int ınstructorID = context.Instructors.Where(x => x.Email == value).Select(y => y.InstructorID).FirstOrDefault();
            var instructorInformations = context.Instructors.Where(x => x.InstructorID == ınstructorID).FirstOrDefault();
            return View(instructorInformations);
        }

        [HttpPost]
        public ActionResult Index(Instructor ınstructor)
        {
            var value = context.Instructors.Find(ınstructor.InstructorID);
            value.Title = ınstructor.Title;
            value.Name = ınstructor.Name;
            value.Surname = ınstructor.Surname;
            value.ImageUrl = ınstructor.ImageUrl;
            value.CoverImage = ınstructor.CoverImage;
            value.Email = ınstructor.Email;
            value.Password = ınstructor.Password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}