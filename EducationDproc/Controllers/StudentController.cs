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
    public class StudentController : Controller
    {

        EduContext context;

        public object ConfigurationManager { get; private set; }

        public StudentController(EduContext context)
        {
            this.context = context;
        }


        public IActionResult Index()
        {
            if (!isLoggedIn()) // not logged in
            {
                return Redirect("/Student/SignupLogin");
            }
            return Redirect("/Student/HistoryEdu");
        }

        public IActionResult SignupLogin()
        {
            return View();
        }

        public IActionResult Finish()
        {
            if (!isLoggedIn()) // not logged in
            {
                return Redirect("/Student/SignupLogin");
            }
            return View();
        }

        public IActionResult Edu()
        {
            if (!isLoggedIn()) // not logged in
            {
                return Redirect("/Student/SignupLogin");
            }
            return View();
        }
        public IActionResult HistoryEdu()
        {
            if (!isLoggedIn()) // not logged in
            {
                return Redirect("/Student/SignupLogin");
            }
            return View();
        }

        public Boolean isLoggedIn()
        {
            int? studentID = HttpContext.Session.GetInt32("student");
            return studentID != null;
        }



        // SIGNUPPLOGIN
        // registration
        public IActionResult Grancvel(Student obj)
        {
            if (string.IsNullOrEmpty(obj.name) || string.IsNullOrEmpty(obj.surname) || string.IsNullOrEmpty(obj.fatherName) ||
                string.IsNullOrEmpty(obj.email) || string.IsNullOrEmpty(obj.password))
            {
                //Խնդրում ենք լրացնել բոլոր դաշտերը
                //Please fill in all the fields
                //Пожалуйста, заполните все поля
                TempData["Namak"] = "pleaseFillInAllTheFields" + " | " + obj.name + " | " + obj.surname + " | " + obj.fatherName + " | " + obj.email + " | " + obj.password;
                return Redirect("/Student/SignupLogin/error");
            }

            if (obj.password.Length < 4)
            {
                //Ծածկագիրը կարճ է
                //The password is short
                //Кароткий пороль
                TempData["Namak"] = "thePasswordIsShort";
                return Redirect("/Student/SignupLogin/error");
            }

            if (obj.name == obj.surname)
            {
                //Անունը և ազգանունը չեն կարող նույնը լինել
                //First name and last name can not be the same
                //Имя и фамилия не могут совпадать
                TempData["Namak"] = "can'tBeTheSame";
                return Redirect("/Student/SignupLogin/error");
            }

            var t = (from elm in context.Students where elm.email == obj.email select elm).ToList().Count;
            if (t > 0)
            {
                //Այս Email-ը արդեն զբաղված է
                //This Email is already busy
                //Этот Email уже занят
                TempData["Namak"] = "busyEmail";
                return Redirect("/Student/SignupLogin/error");
            }

            var pass = (from el in context.Students where el.password == obj.password select el.password).FirstOrDefault();
            if (pass != null)
            {
                //Այս password-ը արդեն զբաղված է
                //This password is already busy
                //Этот пароль уже занят
                TempData["Namak"] = "busyPassword";
                return Redirect("/Student/SignupLogin/error");
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
                return Redirect("/Student/SignupLogin/error");
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
                return Redirect("/Student/SignupLogin/error");
            }

            obj.password = SecurePasswordHasher.Hash(obj.password);
            context.Students.Add(obj);
            context.SaveChanges();
            TempData["Namak"] = "signupSuccess";
            return Redirect("/Student/SignupLogin"); // ?

        }


        // login
        public IActionResult Mutqagrel(Student obj)
        {
            var data = (from elm in context.Students where elm.email == obj.email select elm).FirstOrDefault();
            if (data == null)
            {
                TempData["Namak"] = "wrongLogin";
                return Redirect("/Student/SignupLogin/error");
            }
            else if (!SecurePasswordHasher.Verify(obj.password, data.password))
            {
                TempData["Namak"] = "wrongPassword";
                return Redirect("/Student/SignupLogin/error");
            }
            else
            {
                HttpContext.Session.SetInt32("student", data.id);
                HttpContext.Session.SetString("studentName", data.name);
                HttpContext.Session.SetString("studentSurname", data.surname);
                HttpContext.Session.SetString("studentFatherName", data.fatherName);
                return Redirect("/Student/Edu");
            }

        }

        // check login
        public IActionResult Stugel(string id)
        {
            var data = (from item in context.Students
                        where item.email == id
                        select item).ToList().Count;

            return Json(data);
        }
        // END SIGNUPPLOGIN

        // EDU

        public IActionResult OrderStrarter(int id)
        {
            int? studentID = HttpContext.Session.GetInt32("student");


            if (studentID != null)
            {

                var isEduStarted = 0;
                //do //naxkin tarberak
                //{ 
                //    isEduStarted = (from elm in context.TestEdus where elm.id == testEduID select elm.isEduStarted).FirstOrDefault();

                //}
                //while (isEduStarted == 0);

                isEduStarted = (from elm in context.TestEdus where elm.id == id select elm.isEduStarted).FirstOrDefault();
                var data = new
                {
                    started = isEduStarted
                };
                return Json(data);


            }
            return Json("notLoggedIn");
        }


        public IActionResult OrderPassword(string testPassword)
        {
            int? studentID = HttpContext.Session.GetInt32("student");

            if (studentID == null)
            {
                return Json("notLoggedIn");
            }
            else
            {
                var testEdu = (from elm in context.TestEdus where elm.password == testPassword select elm).FirstOrDefault();

                if (testEdu == null)
                {
                    return Json("wrongPassword");
                }
                else
                {
                    var questions = (from elm in context.Questions where elm.testEduID == testEdu.id orderby elm.order select elm).ToList();
                    var testing = (from elm in context.Testings where elm.testEduID == testEdu.id orderby elm.id descending select elm).FirstOrDefault();
                    var data = new { testEdu = testEdu, questions = questions, testing = testing };
                    return Json(data);
                }
            }


        }

        //public IActionResult SaveStudentsAnswers( AnswerStudent newAnswer )
        public IActionResult SaveStudentsAnswers(int answer, int isTrue, int point, int questionID, int testingID)
        {
            //stugel ev avelacnel sql-um;  ev tpel Finish ejum;
            int? studentID = HttpContext.Session.GetInt32("student");
            //int? schoolID = HttpContext.Session.GetInt32("school");

            if (studentID != null)
            {
                // poxum enq isEduStarted-i arjeqy
                var testingPassword = (from elm in context.Testings
                                       where elm.id == testingID /*&& elm.schoolID == schoolID*/
                                       select elm.password).FirstOrDefault();

                var isEduStarted = (from elm in context.TestEdus
                                    where elm.password == testingPassword && elm.isEduStarted > 0 /*&& elm.schoolID == schoolID*/
                                    select elm).FirstOrDefault();

                //isEduStarted.isEduStarted = 0;

                AnswerStudent ans = new AnswerStudent();

                ans.answer = answer;
                ans.isTrue = isTrue;
                ans.point = point;
                ans.questionID = questionID;
                ans.testingID = testingID;
                ans.studentID = (int)studentID;

                context.Add(ans);
                context.SaveChanges();

                return Json("added");
            }

            return Json("notLoggedIn");

        }

        //public IActionResult SaveStudentsAnswers( AnswerStudent newAnswer )
        public IActionResult SaveTestingResult(int isTrueCount, int isFalseCount, int isNoneCount, int resultPoint, int maxPoint, int testingID)
        {


            //stugel ev avelacnel sql-um;  ev tpel Finish ejum;
            int? studentID = HttpContext.Session.GetInt32("student");
            //int? schoolID = HttpContext.Session.GetInt32("school");

            if (studentID != null)
            {

                Testing testing = (from elm in context.Testings
                                   where elm.id == testingID /*&& elm.schoolID == schoolID*/
                                   select elm).FirstOrDefault();
                if (testing != null)
                {

                    TestEdu testEdu = (from elm in context.TestEdus
                                       where elm.id == testing.testEduID /*&& elm.schoolID == schoolID*/
                                       select elm).FirstOrDefault();

                    TestingResults result = new TestingResults();
                    result.testingDate = DateTime.Today;
                    result.description = testing.description;
                    result.classNumber = testEdu.classNumber;
                    result.classGroup = testing.classGroup;
                    result.paragraph = testEdu.paragraph;
                    result.subjectID = testEdu.subjectID;

                    result.isTrueCount = isTrueCount;
                    result.isFalseCount = isFalseCount;
                    result.isNoneCount = isNoneCount;
                    result.resultPoint = resultPoint;
                    result.maxPoint = maxPoint;

                    result.testEduID = testing.testEduID;
                    result.testingID = (int)testingID;
                    result.studentID = (int)studentID;
                    result.teacherID = testing.teacherID;
                    result.schoolID = testing.schoolID;

                    context.TestingResults.Add(result);
                    context.SaveChanges();

                    return Json("added");
                }

                return Json("unknown testingID");

            }

            return Json("notLoggedIn");

        }
        
        // END EDU

        // FINISH

        //veradarcnum e masnakicneri tvyalnerey kaxvac tvanshanneric
        public IActionResult GetFinishResult(int testingID)
        {
            //this Student information
            int? studentID = HttpContext.Session.GetInt32("student");
            var studentName = HttpContext.Session.GetString("studentName");
            var studentSurname = HttpContext.Session.GetString("studentSurname");
            var studentFatherName = HttpContext.Session.GetString("studentFatherName");

            int? schoolID = HttpContext.Session.GetInt32("school");

            var student = new
            {
                studentID = studentID,
                studentName = studentName,
                studentSurname = studentSurname,
                studentFatherName = studentFatherName,
            };

            var dataAnswers = (from elm in context.AnswerStudents
                               where elm.testingID == testingID && elm.studentID == studentID
                               select elm).ToList();

            var dataQuestions = (from elm in context.Testings
                                 where elm.id == testingID
                                 from el in context.Questions
                                 where el.testEduID == elm.testEduID
                                 orderby el.order
                                 select el).ToList();

            var result = (from elm in context.TestingResults
                          where elm.studentID == studentID && elm.testingID == testingID
                          select elm).FirstOrDefault();



            var data = new { dataAnswers = dataAnswers, dataQuestions = dataQuestions, student = student, result = result };

            return Json(data);

        }

        // END FINISH

        // HISTORYEDU

        public IActionResult GetEdusHistory(string classNumber, int subjectID)
        {
            int? studentID = HttpContext.Session.GetInt32("student");

            if (studentID != null)
            {
                var data = (
                        from elm in context.TestingResults
                        where elm.studentID == studentID && elm.classNumber.Contains(classNumber) && elm.subjectID == subjectID
                        orderby elm.testingDate descending
                        select elm
                    ).ToList();

                return Json(data);
            }
            return Json("notLoggedIn");
        }

        // END HISTORYEDU


    }
}
