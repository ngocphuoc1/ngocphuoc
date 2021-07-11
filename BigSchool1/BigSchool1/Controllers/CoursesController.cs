using BigSchool1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool1.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ActionResult Create()
        {
            //get list category
            BigSchoolContext context = new BigSchoolContext();
            Course objCourse = new Course();
            objCourse.ListCategory = context.Categories.ToList();
            return View(objCourse);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course objcourse)
        {
            BigSchoolContext context = new BigSchoolContext();

            ModelState.Remove("LecturerId");
            if (!ModelState.IsValid)
            {
                objcourse.ListCategory = context.Categories.ToList();
                return View("Create", objcourse);
            }

            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            objcourse.LecturerId = user.Id;

            context.Courses.Add(objcourse);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Attending()
        {
           
            ApplicationUser currentUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            BigSchoolContext context = new BigSchoolContext();
            var ListAttendances = context.Attendances.Where(p => p.Attendee == currentUser.Id).ToList();
            var courses = new List<Course>();
            foreach (Attendance temp in ListAttendances)
            {
                Course objCourse = temp.Course;
                objCourse.LectureName = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                    .FindById(objCourse.LecturerId).Name;
                courses.Add(objCourse);
            }
            return View(courses);
        }
        public ActionResult Mine()
        {
         
            ApplicationUser currentUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            BigSchoolContext context = new BigSchoolContext();
            List<Course> courses = context.Courses.Where(c => c.LecturerId == currentUser.Id && c.DateTime > DateTime.Now).ToList();

            foreach (Course i in courses)
            {
                i.LectureName = currentUser.Name;
            }
            return View(courses);
        }
        public ActionResult Delete(int? id)
        {
            BigSchoolContext context = new BigSchoolContext();
            Course course = context.Courses.Find(id);
            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            BigSchoolContext context = new BigSchoolContext();
            ApplicationUser currentUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            Course course = context.Courses.Find(id);
            Attendance attendance = context.Attendances.Find(id, currentUser.Id);
            context.Attendances.Remove(attendance);
            context.SaveChanges();
            context.Courses.Remove(course);
            context.SaveChanges();
            return RedirectToAction("Mine", "Courses");
        }
        public ActionResult Edit(int? id)
        {
            BigSchoolContext context = new BigSchoolContext();
            Course course = context.Courses.Find(id);
            course.ListCategory = context.Categories.ToList();
            if (id == null)
            {
                return HttpNotFound();
            }
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course objcourse)
        {
            BigSchoolContext context = new BigSchoolContext();
            ModelState.Remove("LecturerId");
            if (!ModelState.IsValid)
            {
               
                objcourse.ListCategory = context.Categories.ToList();

                return View("Edit", objcourse);
            }

            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            objcourse.LecturerId = user.Id;

            context.Courses.Add(objcourse);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        
    }
}