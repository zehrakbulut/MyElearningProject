using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class InformationAddressController : Controller
    {

        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            TempData["Location"] = "İletişim";
            var values = context.InformationAddresses.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddInformationAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInformationAddress(InformationAddress ınformationAddress)
        {
            context.InformationAddresses.Add(ınformationAddress);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteInformatonAddress(int id)
        {
            var value = context.InformationAddresses.Find(id);
            context.InformationAddresses.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateInformationAddress(int id)
        {
            var value = context.InformationAddresses.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateInformationAddress(InformationAddress ınformationAddress)
        {
            var value = context.InformationAddresses.Find(ınformationAddress.InformationAddressID);
            value.Title1 = ınformationAddress.Title1;
            value.Address = ınformationAddress.Address;
            value.Title2 = ınformationAddress.Title2;
            value.Phone = ınformationAddress.Phone;
            value.Email = ınformationAddress.Email;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}