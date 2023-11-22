using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class UIContactController : Controller
    {
        ELearningContext context = new ELearningContext();
        // GET: UIContact
        
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHeader()
        {
            return PartialView();
        }

        public PartialViewResult PartialContactInformation()
        {
            var values = context.Informations.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialContactInformationAddress()
        {
            var values = context.InformationAddresses.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialContactMap()
        {
            var values = context.Maps.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult PartialContactMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialContactMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
            return PartialView();
        }
    }
}