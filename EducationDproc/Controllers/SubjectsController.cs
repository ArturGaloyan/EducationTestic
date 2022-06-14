using EducationDproc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationDproc.Controllers
{
    public class SubjectsController : Controller
    {

        EduContext context;

        public object ConfigurationManager { get; private set; }

        public SubjectsController(EduContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult getSubjects()
        {

            int? teacherID = HttpContext.Session.GetInt32("teacher");
            int? studentID = HttpContext.Session.GetInt32("student");
            int? directorID = HttpContext.Session.GetInt32("director");

            if (teacherID == null && studentID == null && directorID == null)
            {
                return Json("notLoggedIn");
            }
            else
            {
                // int? schoolID = HttpContext.Session.GetInt32("schoolID");
                int? schoolID = HttpContext.Session.GetInt32("school");
                if (schoolID == null)
                {
                    schoolID = 1;
                }
                var subjects = (from elm in context.Subjects where elm.schoolID == schoolID select elm).ToList();

                var classNumberSubjects = (from elm in context.ClassNumberSubjects where elm.schoolID == schoolID select elm).ToList();

                var data = new { subjects = subjects, classNumberSubjects = classNumberSubjects };

                return Json(data);
            }

        }

        public IActionResult addSubject(string name)
        {
             // int? schoolID = HttpContext.Session.GetInt32("schoolID");
            int? schoolID = HttpContext.Session.GetInt32("school");
            if (schoolID == null)
            {
                return Json(new { id = 0 });
            }

            var subject = (from elm in context.Subjects where elm.schoolID == schoolID && elm.name == name select elm).FirstOrDefault();
            if (subject != null)
            {
                return Json(new { id = subject.id });
            }

            Subjects newSubject = new Subjects();
            newSubject.name = name;
            newSubject.schoolID = (int)schoolID;

            context.Subjects.Add(newSubject);
            context.SaveChanges();

            return Json(new { id = newSubject.id });
        }

        public IActionResult addClassNumberSubject(string classNumber, int subjectID)
        {
            // int? schoolID = HttpContext.Session.GetInt32("schoolID");
            int? schoolID = HttpContext.Session.GetInt32("school");
            if (schoolID == null)
            {
                return Json(new { id = 0 });
            }

            var classNumberSubject = (from elm in context.ClassNumberSubjects where elm.schoolID == schoolID && elm.classNumber == classNumber && elm.subjectID == subjectID select elm).FirstOrDefault();
            if (classNumberSubject != null)
            {
                return Json(new { id = classNumberSubject.id });
            }

            ClassNumberSubjects newClassNumberSubjects = new ClassNumberSubjects();
            newClassNumberSubjects.classNumber = classNumber;
            newClassNumberSubjects.subjectID = subjectID;
            newClassNumberSubjects.schoolID = (int)schoolID;

            context.ClassNumberSubjects.Add(newClassNumberSubjects);
            context.SaveChanges();

            var data = new { id = newClassNumberSubjects.id };
            return Json(data);
        }

    }
}
