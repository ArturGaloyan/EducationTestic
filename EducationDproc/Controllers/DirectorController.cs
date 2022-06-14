using EducationDproc.lib;
using EducationDproc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationDproc.Controllers
{
    public class DirectorController : Controller
    {

        EduContext context;

        public object ConfigurationManager { get; private set; }

        public DirectorController(EduContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            if (!isLoggedIn()) // not logged in
            {
                return Redirect("/Director/SignupLogin");
            }
            return Redirect("/Director/HistoryEdu");
        }

        public IActionResult SignupLogin()
        {
            if (isLoggedIn())
            {
                return Redirect("/Director/HistoryEdu");
            }
            return View();
        }

        public IActionResult Finish()
        {
            if (!isLoggedIn()) // not logged in
            {
                return Redirect("/Director/SignupLogin");
            }
            return View();
        }

        public IActionResult HistoryEdu()
        {
            if (!isLoggedIn()) // not logged in
            {
                return Redirect("/Director/SignupLogin");
            }
            return View();
        }

        public IActionResult TestEdu()
        {
            if (!isLoggedIn()) // not logged in
            {
                return Redirect("/Director/SignupLogin");
            }
            return View();
        }

        public IActionResult SchoolClasses()
        {
            if (!isLoggedIn()) // not logged in
            {
                return Redirect("/Director/SignupLogin");
            }
            return View();
        }


        public Boolean isLoggedIn ()
        {
            int? directorID = HttpContext.Session.GetInt32("director");
            return directorID != null;
        }


        // SIGNUPLOGIN

        // registration
        public IActionResult Grancvel(Director obj)
        {

            //TempData["Namak"] = obj.name + " | " + obj.surname + " | " + obj.login + " | " + obj.password;
            //return Redirect("/AuthorSignupLogin/Index");

            if (string.IsNullOrEmpty(obj.name) || string.IsNullOrEmpty(obj.surname) ||
                string.IsNullOrEmpty(obj.email) || string.IsNullOrEmpty(obj.password))
            {
                //Խնդրում ենք լրացնել բոլոր դաշտերը
                //Please fill in all the fields
                //Пожалуйста, заполните все поля
                TempData["Namak"] = "pleaseFillInAllTheFields" + " | " + obj.name + " | " + obj.surname + " | " + obj.email + " | " + obj.password;
                return Redirect("/DirectorSignupLogin/Index/error");
            }

            if (obj.password.Length < 4)
            {
                //Ծածկագիրը կարճ է
                //The password is short
                //Кароткий пороль
                TempData["Namak"] = "thePasswordIsShort";
                return Redirect("/DirectorSignupLogin/Index/error");
            }
            if (obj.name == obj.surname)
            {
                //Անունը և ազգանունը չեն կարող նույնը լինել
                //First name and last name can not be the same
                //Имя и фамилия не могут совпадать
                TempData["Namak"] = "can'tBeTheSame";
                return Redirect("/DirectorSignupLogin/Index/error");
            }

            var t = (from elm in context.Directors where elm.email == obj.email select elm).ToList().Count;
            if (t > 0)
            {
                //Այս Email-ը արդեն զբաղված է
                //This Email is already busy
                //Этот Email уже занят
                TempData["Namak"] = "busyEmail";
                return Redirect("/DirectorSignupLogin/Index/error");
            }


            bool k = false;
            int s = 0;
            for (int i = 0; i < obj.password.Length; i++)
            {
                if (char.IsUpper(obj.password[i])
                  && obj.password.Contains('!')
                  || obj.password.Contains('@')
                  || obj.password.Contains('#')
                  || obj.password.Contains('$')
                  || obj.password.Contains('%')
                  || obj.password.Contains('^')
                  || obj.password.Contains('&')
                  || obj.password.Contains('*'))
                {
                    k = true;
                    s++;

                }
            }

            if (k == false || s < 1)
            {
                //Գաղտնաբառը պետք է պարունակի 1 մեծատառ և տվյալ սիմվոլներից գոնե 1 - ը(!@#$%^&*)
                //Password must contain 1 uppercase letter and at least 1 of these characters (! @ # $% ^ & *)
                //Пароль должен содержать 1 заглавную букву и не менее 1 из этих символов (!@#$%^&*)
                TempData["Namak"] = "passwordMustContain";
                return Redirect("/Director/SignupLogin/error");
            }


            bool b = false;
            int d = 0;

            if (obj.email.Contains('@') && !obj.email.Contains("@.")
                && !obj.email.Contains("..") && !obj.email.EndsWith('.'))
            {
                b = true;
                d++;
            }
            else if (b == false || d != 1)
            {
                //Email-ը սխալ է
                //Email is incorrect
                //Электронная почта неверна
                TempData["Namak"] = "wrongEmail";
                return Redirect("/Director/SignupLogin/error");
            }
            //obj.type = 0;


            var schools = (from elm in context.Schools where elm.license_key == obj.license_key select elm).ToList();
            //var l = t.Count;
            if (schools.Count > 0)
            {
                obj.schoolID = schools[0].id;

            }
            else
            {
                //Այդպիսի Լիցենզիա Չկա
                //There is no such License
                //Нет такой лицензии
                TempData["Namak"] = "wrongLicense";
                return Redirect("/Director/SignupLogin/error");
            }

            obj.password = SecurePasswordHasher.Hash(obj.password);
            context.Directors.Add(obj);
            context.SaveChanges();
            return Redirect("/Director/SignupLogin");
        }


        // login
        public IActionResult Mutqagrel(Director obj)
        {
            var data = (from elm in context.Directors where elm.email == obj.email select elm).FirstOrDefault();
            if (data == null)
            {
                //լոգինը սխալ է
                TempData["Namak"] = "wrongLogin";
                return Redirect("/Director/SignupLogin/error");
            }
            else if (!SecurePasswordHasher.Verify(obj.password, data.password))
            {
                // գաղտնաբառը չի գտնվել
                TempData["Namak"] = "wrongPassword";
                return Redirect("/Director/SignupLogin/error");
            }
            else
            {
                HttpContext.Session.SetInt32("director", data.id);
                HttpContext.Session.SetInt32("school", data.schoolID);
                //return Redirect("/DirectorSelectEdu/Index");
                return Redirect("/Director/HistoryEdu");
            }

        }


        // check login
        public IActionResult Stugel(string id)
        {
            var data = (from item in context.Directors
                        where item.email == id
                        select item).ToList().Count;

            return Json(data);
        }
        // END SIGNUPLOGIN

        // HISTORYEDU
        public IActionResult GetEdusHistory(string classNumber, int subjectID, string classGroup)
        {
            int? directorID = HttpContext.Session.GetInt32("director");
            int? schoolID = HttpContext.Session.GetInt32("school");

            if (directorID != null)
            {
                if (classGroup == null)
                {
                    classGroup = "";
                } 
                var data = (
                        from testEdu in context.TestEdus
                        where testEdu.schoolID == schoolID && testEdu.classNumber == classNumber && testEdu.subjectID == subjectID
                        from testing in context.Testings
                        where testing.testEduID == testEdu.id && testing.classGroup.Contains(classGroup)
                        orderby testing.testingDate descending
                        select new { testing, testEdu }
                    ).ToList();

                return Json(data);
            }
            return Json("notLoggedIn");
        }
        // END HISTORYEDU


        // FINISH
        //veradarcnum e masnakicneri tvyalnerey kaxvac tvanshanneric
        public IActionResult GetFinishResult(int testingID)
        {

            int? directorID = HttpContext.Session.GetInt32("director");
            int? schoolID = HttpContext.Session.GetInt32("school");

            if (directorID == null)
            {
                //You are not logged in! Please log in & try again!
                return Json(new { loginErrorMessage = "notLoggedIn" });
            }

            var testing = (from t in context.Testings
                           where t.id == testingID && t.schoolID == schoolID
                           from te in context.TestEdus
                           where te.id == t.testEduID
                           from tch in context.Teachers
                           where tch.id == te.teacherID
                           select new { testing = t, testEdu = te, teacher = tch }).FirstOrDefault();

            if (testing == null)
            {
                return Json(new { testErrorMessage = "notFoundTesting" });
            }

            //var testEdu = (from elm in context.TestEdus
            //               where elm.id == testing.testEduID
            //               select elm).FirstOrDefault();
            //var teacher = (from elm in context.TestEdus
            //               where elm.id == testing.testEduID
            //               select elm).FirstOrDefault();

            var dataQuestions = (from elm in context.Testings
                                 where elm.id == testingID && elm.schoolID == schoolID
                                 from el in context.Questions
                                 where el.testEduID == elm.testEduID
                                 orderby el.order
                                 select el).ToList();


            var answers = (
                    from elm in context.AnswerStudents
                    where elm.testingID == testingID
                    select elm
                ).ToList();

            var students = (
                    //from elm in context.AnswerStudents
                    //where elm.testingID == testingID
                    from elm in context.TestingResults
                    where elm.testingID == testingID && elm.schoolID == schoolID
                    from st in context.Students
                    where st.id == elm.studentID
                    select st
                ).ToList();

            var testingResults = (
                    from elm in context.TestingResults
                    where elm.testingID == testingID && elm.schoolID == schoolID
                    select elm
                ).ToList();

            var data = new {dataTesting = testing, dataStudents = students, dataAnswers = answers, dataQuestions = dataQuestions, testingResults = testingResults };

            return Json(data);

        }
        // END FINISH

        // TEST EDU

        public IActionResult GetTestEdu(int id)
        {

            //int? teacherID = HttpContext.Session.GetInt32("teacher");
            int? schoolID = HttpContext.Session.GetInt32("school");

            if (schoolID == null)
            {
                return Json("notLoggedIn");
            }
            else
            {
                var testEdus = (from elm in context.TestEdus where elm.id == id && elm.schoolID == schoolID select elm).ToList();

                var teacher = (from elm in context.Teachers where elm.id == testEdus[0].teacherID select elm).FirstOrDefault();

                var questions = (from elm in context.Questions where elm.testEduID == id orderby elm.order select elm).ToList();

                var data = new { testEdus = testEdus, questions = questions, teacher = teacher };


                return Json(data);
            }

        }

        // END TEST EDU

        // SCHOOL CLASSES

        public IActionResult GetClassesInfo()
        {

            //int? teacherID = HttpContext.Session.GetInt32("teacher");
            int? schoolID = HttpContext.Session.GetInt32("school");

            if (schoolID == null)
            {
                return Json("notLoggedIn");
            }
            else
            {

                var teachers = (from elm in context.Teachers where elm.schoolID == schoolID select elm).ToList();
                var classes = (from elm in context.Classes where elm.schoolID == schoolID select elm).ToList();

                var data = new { classes = classes, teachers = teachers };


                return Json(data);
            }

        }

        
        public IActionResult AddClass(string classNumber, string classGroup, int teacherID)
        {

            //int? teacherID = HttpContext.Session.GetInt32("teacher");
            int? schoolID = HttpContext.Session.GetInt32("school");

            if (schoolID == null)
            {
                return Json("notLoggedIn");
            }
            else
            {

                Classes cl = new Classes();

                cl.classNumber = classNumber;
                cl.classGroup = classGroup;
                cl.teacherID = teacherID;
                cl.schoolID = (int)schoolID;

                context.Classes.Add(cl);
                context.SaveChanges();


                //var subject_id = (from elm in context.ClassNumberSubjects
                //                  where elm.classNumber == cl.classNumber && schoolID == cl.schoolID
                //                  select elm.subjectID).FirstOrDefault();


                //ClassSubjectsTeachers classSubjectsTeachers = new ClassSubjectsTeachers();

                //classSubjectsTeachers.classesID = cl.id;           
                //classSubjectsTeachers.subjectID = subject_id;               
                //classSubjectsTeachers.teacherID = cl.teacherID;
                //classSubjectsTeachers.schoolID = cl.schoolID;

                //context.ClassSubjectsTeachers.Add(classSubjectsTeachers);
                //context.SaveChanges();

                return Json(cl);
            }

        }

        
        public IActionResult UpdateClass(Classes cl)
        {

            //int? teacherID = HttpContext.Session.GetInt32("teacher");
            int? schoolID = HttpContext.Session.GetInt32("school");

            if (schoolID == null)
            {
                return Json("notLoggedIn");
            }
            else
            {

                Classes newClass = new Classes();
                newClass.id = cl.id;
                newClass.classNumber = cl.classNumber;
                newClass.classGroup = cl.classGroup;
                newClass.teacherID = cl.teacherID;
                newClass.schoolID = cl.schoolID;



                context.Classes.Update(newClass);

                context.SaveChanges();


                return Json(newClass);
            }

        }

        
         public IActionResult DeleteClass(Classes cl)
        {

            //int? teacherID = HttpContext.Session.GetInt32("teacher");
            int? schoolID = HttpContext.Session.GetInt32("school");

            if (schoolID == null)
            {
                return Json("notLoggedIn");
            }
            else
            {

                Classes newClass = new Classes();
                newClass.id = cl.id;
                newClass.classNumber = cl.classNumber;
                newClass.classGroup = cl.classGroup;
                newClass.teacherID = cl.teacherID;
                newClass.schoolID = cl.schoolID;



                context.Classes.Remove(newClass);

                context.SaveChanges();


                return Json(newClass);
            }

        }

        // END SCHOOL CLASSES


    }
}
