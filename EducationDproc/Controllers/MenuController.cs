using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EducationDproc.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetMenuType()
        {
            int? studentID = HttpContext.Session.GetInt32("student");
            int? teacherID = HttpContext.Session.GetInt32("teacher");
            int? directorID = HttpContext.Session.GetInt32("director");


            if (studentID != null)
            {
                return Json(new { menuType = "student" });
            }

            if (teacherID != null)
            {
                int? hasClass = HttpContext.Session.GetInt32("hasClass");
                return Json(new { menuType = "teacher", hasClass = hasClass });
            }

            if (directorID != null)
            {
                return Json(new { menuType = "director" });
            }

            return Json(new { menuType = "notLoggedIn" });
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("director");
            HttpContext.Session.Remove("teacher");
            HttpContext.Session.Remove("student");
            HttpContext.Session.Remove("school");

            return Json("ok");
        }


        
    }
}
