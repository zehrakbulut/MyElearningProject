using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class UIContactController : Controller
    {
        ELearningContext context=new ELearningContext();
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

        public PartialViewResult PartialContactMessage()
        {
            var values = context.Messages.ToList();
            return PartialView(values);
        }
    }
}