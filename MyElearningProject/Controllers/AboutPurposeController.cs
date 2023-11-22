using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class AboutPurposeController : Controller
    {

        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            TempData["Location"] = "Amaçlar";
            var values = context.AboutPurposes.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAboutPurpose()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAboutPurpose(AboutPurpose aboutPurpose)
        {
            context.AboutPurposes.Add(aboutPurpose);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAboutPurpose(int id)
        {
            var value = context.AboutPurposes.Find(id);
            context.AboutPurposes.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAboutPurpose(int id)
        {
            var value = context.AboutPurposes.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAboutPurpose(AboutPurpose aboutPurpose)
        {
            var value = context.AboutPurposes.Find(aboutPurpose.AboutPurposeID);
            value.Title = aboutPurpose.Title;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}