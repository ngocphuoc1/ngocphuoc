﻿using BigSchool1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool1.Controllers
{
    public class HomeController : Controller
    {BigSchoolContext context = new BigSchoolContext();
        public ActionResult Index()
        {

            var upcommingCourse = context.Courses.Where(p => p.DateTime >
            DateTime.Now).OrderBy(p => p.DateTime).ToList();

            var userID = User.Identity.GetUserId();
            foreach (Course i in upcommingCourse)

            {
                ApplicationUser user =

                System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>(
                ).FindById(i.LecturerId);
                i.Name = user.Name;

                if (userID != null)

                {
                    i.isLogin = true;

                    Attendance find = context.Attendances.FirstOrDefault(p =>

                    p.CourseId == i.Id && p.Attendee == userID);
                    if (find == null)
                        i.isShowGoing = true;

                    Following findFollow = context.Followings.FirstOrDefault(p =>

                    p.FollowerId == userID && p.FolloweeId == i.LecturerId);

                    if (findFollow == null)
                        i.isShowFollow = true;
                }
            }
            return View(upcommingCourse);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}