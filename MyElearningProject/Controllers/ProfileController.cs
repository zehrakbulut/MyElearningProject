using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using MyElearningProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyElearningProject.Controllers
{
    public class ProfileController : Controller
    {

        ELearningContext context = new ELearningContext();
        [HttpGet]
        public ActionResult Index()
        {
            TempData["Location"] = "Profil";
            string values = Session["CurrentMail"].ToString();
            ViewBag.mail = Session["CurrentMail"];
            ViewBag.name = context.Students.Where(x => x.Email == values).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            int studentID = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
            var studentInformations = context.Students.Where(x => x.StudentID == studentID).FirstOrDefault();
            return View(studentInformations);
        }
        [HttpPost]
        public ActionResult Index(Student student)
        {
            var value = context.Students.Find(student.StudentID);
            value.Name = student.Name;
            value.Surname = student.Surname;
            value.Email = student.Email;
            value.Password = student.Password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MyCourseList()
        {
            TempData["Location"] = "Kurslarım";
            string values = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
            var courseList = context.Processes.Where(x => x.StudentID == id).ToList();
            return View(courseList);
        }

        public ActionResult WatchCourse(int? id)
        {
            TempData["Location"] = "Kurslarım";
            ViewBag.id = id;
            ViewBag.courseName = context.Courses.Where(x => x.CourseID == id).Select(x => x.Title).FirstOrDefault();
            var values = context.CourseWatchLists.Where(x => x.CourseID == id).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult ReviewCourse(int id)    
        {
            TempData["Location"] = "Değerlendirme";
            ViewBag.courseID = id;
            return View();
        }

        [HttpPost]
        public ActionResult ReviewCourse(ReviewCommentViewModel model)
        {
            TempData["Location"] = "Değerlendirme";
            string userEmail = Session["CurrentMail"].ToString();
            int studentID = context.Students.Where(x => x.Email == userEmail).Select(y => y.StudentID).FirstOrDefault();

            Review existingReview = context.Reviews.FirstOrDefault(r => r.StudentID == studentID && r.CourseID == model.CourseID);

            Comment existingComment = context.Comments.FirstOrDefault(c => c.StudentID == studentID && c.CourseID == model.CourseID);

            if (existingReview != null)
            {
                existingReview.ReviewScore = model.ReviewScore;
                context.SaveChanges();
            }
            else
            {
                Review newReview = new Review
                {
                    StudentID = studentID,
                    CourseID = model.CourseID,
                    ReviewScore = model.ReviewScore
                };
                context.Reviews.Add(newReview);
                context.SaveChanges();
            }

            if (existingComment != null)
            {
                existingComment.CommentText = model.CommentText;
                context.SaveChanges();
            }
            else
            {
                Comment newComment = new Comment
                {
                    StudentID = studentID,
                    CourseID = model.CourseID,
                    CommentText = model.CommentText,
                    CommentDate = DateTime.Now
                };
                context.Comments.Add(newComment);
                context.SaveChanges();
            }

            TempData["ReviewSuccess"] = "Değerlendirme ve yorum başarıyla kaydedildi.";
            return RedirectToAction("ReviewCourse", "Profile");
        }

        [HttpGet]
        public ActionResult StudentCourseBuy()
        {
            TempData["Location"] = "Kurslar";
            var values = context.Courses.ToList();  
            return View(values);
        }

        [HttpPost]
        public ActionResult StudentCourseBuy(int CourseID)
        {
            string values = Session["CurrentMail"].ToString();
            int studentID = context.Students
                .Where(x => x.Email == values)
                .Select(y => y.StudentID)
                .FirstOrDefault();
            bool isRegistered = context.CourseRegisters
                .Any(cr => cr.StudentID == studentID && cr.CourseID == CourseID);

            if (isRegistered)
            {
                TempData["Message"] = "Bu kursa kayıtlısınız!";
            }
            else
            {
                CourseRegister newRegister = new CourseRegister
                {
                    StudentID = studentID,
                    CourseID = CourseID,
                    RegisterDate = DateTime.Now
                };
                context.CourseRegisters.Add(newRegister);
                context.SaveChanges();
                TempData["Message"] = "Kurs başarıyla eklendi!";
            }

            return RedirectToAction("StudentCourseBuy", "Profile");
        }


        public PartialViewResult StudentInformationPartial()
        {
            string value = Session["CurrentMail"].ToString();
            int studentID = context.Students.Where(x => x.Email == value).Select(y => y.StudentID).FirstOrDefault();
            var studentInformations = context.Students.Where(x => x.StudentID == studentID).FirstOrDefault();
            ViewBag.StudentCourseCount = context.CourseRegisters.Where(x => x.StudentID == studentID).Count();
            ViewBag.StudentCommentCount = context.Comments.Where(x => x.StudentID == studentID).Count();
            return PartialView(studentInformations);
        }

        public PartialViewResult StudentActivityPartial()
        {
            string values = Session["CurrentMail"].ToString();
            int studentID = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
            ViewBag.studentName = context.Students.Where(x => x.StudentID == studentID).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            var comments = context.Comments.Where(x => x.StudentID == studentID).ToList();
            return PartialView(comments);
        }

        public PartialViewResult StudentProfilePartial()
        {
            string values = Session["CurrentMail"].ToString();
            int studentID = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
            var studentInformations = context.Students.Where(x => x.StudentID == studentID).FirstOrDefault();
            return PartialView(studentInformations);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}