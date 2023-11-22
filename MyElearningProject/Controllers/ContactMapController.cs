using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class ContactMapController : Controller
    {

        ELearningContext context = new ELearningContext(); 

        // GET: InstructorMap
        public ActionResult Index()
        {
            TempData["Location"] = "Haritalar";
            var values = context.Maps.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddMap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMap(Map map)
        {
            context.Maps.Add(map);
            context.SaveChanges();
            return RedirectToAction("Index");   
        }

        public ActionResult DeleteMap(int id)
        {
            var value = context.Maps.Find(id);
            context.Maps.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateMap(int id)
        {
            var value = context.Maps.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateMap(Map map)
        {
            var value = context.Maps.Find(map.MapID);
            value.EmbedLink = map.EmbedLink;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}