using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class MessageController : Controller
    {

        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            TempData["Location"] = "Mesajlar";
            var values = context.Messages.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = context.Messages.Find(id);
            context.Messages.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateMessage(int id)
        {
            var value = context.Messages.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateMessage(Message message)
        {
            var value = context.Messages.Find(message.MessageID);
            value.NameSurname = message.NameSurname;
            value.Email = message.Email;
            value.Subject = message.Subject;
            value.MessageDescription = message.MessageDescription;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}