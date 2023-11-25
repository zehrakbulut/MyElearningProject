using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class InstructorCourseController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            TempData["Location"] = "Kurslarım";
            string mail = Session["CurrentMail"].ToString();
            int id = context.Instructors.Where(x => x.Email == mail).Select(y => y.InstructorID).FirstOrDefault();
            var courses = context.Courses.Where(x => x.InstructorID == id).ToList();
            return View(courses);
        }


        public ActionResult DeleteInstructorCourse(int id)
        {
            var value = context.Courses.Find(id);
            context.Courses.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateInstructorCourse(int id)
        {
            TempData["Location"] = "Kurs Güncelleme";
            List<SelectListItem> categories = (from x in context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
            List<SelectListItem> instructors = (from x in context.Instructors.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Name + " " + x.Surname,
                                                    Value = x.InstructorID.ToString()
                                                }).ToList();
            ViewBag.instructors = instructors;

            var value = context.Courses.Where(x => x.CourseID == id).FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateInstructorCourse(Course course)
        {
            TempData["Location"] = "Kurs Güncelleme";
            var value = context.Courses.Find(course.CourseID);
            value.Title = course.Title;
            value.Price = course.Price;
            value.Duration = course.Duration;
            value.ImageUrl = course.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddVideo(int id)
        {
            TempData["Location"] = "Video";
            ViewBag.id = id;
            ViewBag.courseName = context.Courses.Where(x => x.CourseID == id).Select(x => x.Title).FirstOrDefault();
            var values = context.CourseWatchLists.Where(x => x.CourseID == id).ToList();
            return View(values);
        }

        [HttpPost]
        public ActionResult AddVideo(CourseWatchList courseWatchList)
        {
            context.CourseWatchLists.Add(courseWatchList);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCourseWatchList(int id)
        {
            var value = context.CourseWatchLists.Find(id);
            context.CourseWatchLists.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}