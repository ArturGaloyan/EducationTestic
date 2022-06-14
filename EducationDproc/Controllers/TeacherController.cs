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
    public class TeacherController : Controller
    {

        EduContext context;

        public object ConfigurationManager { get; private set; }

        public TeacherController(EduContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            if (!isLoggedIn()) // not logged in
            {
                return Redirect("/Teacher/SignupLogin");
            }
            return Redirect("/Teacher/SelectEdu"); // ?
        }

        public IActionResult SignupLogin()
        {
            if (isLoggedIn()) // not logged in
            {
                return Redirect("/Teacher/SelectEdu");
            }
            return View();
        }

        public IActionResult SelectEdu()
        {
            if (!isLoggedIn()) // not logged in
            {
                return Redirect("/Teacher/SignupLogin");
            }
            return View();
        }

        public IActionResult NewEdu()
        {
            if (!isLoggedIn()) // not logged in
            {
                return Redirect("/Teacher/SignupLogin");
            }
            return View();
        }

        public IActionResult EditEdu()
        {
            if (!isLoggedIn()) // not logged in
            {
                return Redirect("/Teacher/SignupLogin");
            }
            return View();
        }

        public IActionResult Edu()
        {
            if (!isLoggedIn()) // not logged in
            {
                return Redirect("/Teacher/SignupLogin");
            }
            return View();
        }

        public IActionResult Finish()
        {
            if (!isLoggedIn()) // not logged in
            {
                return Redirect("/Teacher/SignupLogin");
            }
            return View();
        }

        public IActionResult HistoryEdu()
        {
            if (!isLoggedIn()) // not logged in
            {
                return Redirect("/Teacher/SignupLogin");
            }
            return View();
        }

        public IActionResult MyClass()
        {
            if (!isLoggedIn()) // not logged in
            {
                return Redirect("/Teacher/SignupLogin");
            }
            int? hasClass = HttpContext.Session.GetInt32("hasClass");
            if (hasClass == 0) // not logged in
            {
                return Redirect("/Home");
            }
            return View();
        }

        public Boolean isLoggedIn()
        {
            int? teacherID = HttpContext.Session.GetInt32("teacher");
            return teacherID != null;
        }


        // SIGNUPLOGIN

        // registration
        public IActionResult Grancvel(Teacher obj)
        {

            //TempData["Namak"] = obj.name + " | " + obj.surname + " | " + obj.login + " | " + obj.password;
            //return Redirect("/AuthorSignupLogin/Index");

            if (string.IsNullOrEmpty(obj.name) || string.IsNullOrEmpty(obj.surname) ||
                string.IsNullOrEmpty(obj.email) || string.IsNullOrEmpty(obj.password))
            {
                TempData["Namak"] = "Խնդրում ենք լրացնել բոլոր դաշտերը | " + obj.name + " | " + obj.surname + " | " + obj.email + " | " + obj.password;
                return Redirect("/Teacher/SignupLogin/error");
            }

            if (obj.password.Length < 4)
            {
                TempData["Namak"] = "Ծածկագիրը կարճ է";
                return Redirect("/Teacher/SignupLogin/error");
            }
            if (obj.name == obj.surname)
            {
                TempData["Namak"] = "Անունը և ազգանունը չեն կարող նույնը լինել";
                return Redirect("/Teacher/SignupLogin/error");
            }

            var t = (from elm in context.Teachers where elm.email == obj.email select elm).ToList().Count;
            if (t > 0)
            {
                TempData["Namak"] = "Այս Email-ը արդեն զբաղված է";
                return Redirect("/Teacher/SignupLogin/error");
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
                TempData["Namak"] = "Գաղտնաբառը պետք է պարունակի 2 մեծատառ և տվյալ սիմվոլներից գոնե 1-ը (!@#$%^&*)";
                return Redirect("/Teacher/SignupLogin/error");
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
                TempData["Namak"] = "օգտանունը սխալ է";
                return Redirect("/Teacher/SignupLogin/error");
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
                TempData["Namak"] = "Այդպիսի License Չկա";
                return Redirect("/Teacher/SignupLogin/error");
            }

            obj.password = SecurePasswordHasher.Hash(obj.password);
            context.Teachers.Add(obj);
            context.SaveChanges();
            return Redirect("/Teacher/SignupLogin");
        }


        // login
        public IActionResult Mutqagrel(Teacher obj)
        {
            var data = (from elm in context.Teachers where elm.email == obj.email select elm).FirstOrDefault();
            if (data == null)
            {
                TempData["Namak"] = " լոգինը սխալ է";
                return Redirect("/Teacher/SignupLogin/error");
            }
            else if (!SecurePasswordHasher.Verify(obj.password, data.password))
            {
                TempData["Namak"] = " գաղտնաբառը չի գտնվել";
                return Redirect("/Teacher/SignupLogin/error");
            }
            else
            {
                HttpContext.Session.SetInt32("teacher", data.id);
                HttpContext.Session.SetInt32("school", data.schoolID);
                var classes = (from elm in context.Classes where elm.teacherID == data.id && elm.schoolID == data.schoolID select elm).ToList();
                if (classes.Count() > 0)
                {
                    HttpContext.Session.SetInt32("hasClass", 1);
                } else
                {
                    HttpContext.Session.SetInt32("hasClass", 0);
                }


                return Redirect("/Teacher/SelectEdu");
            }

        }


        // check login
        public IActionResult Stugel(string id)
        {
            var data = (from item in context.Teachers
                        where item.email == id
                        select item).ToList().Count;

            return Json(data);
        }

        // END SIGNUPLOGIN

        // SELECT EDU

        public IActionResult GetEdus(string classNumber, int subjectID)
        {
            int? teacherID = HttpContext.Session.GetInt32("teacher");

            if (teacherID == null)
            {
                return Json("not logge in");
            }
            else
            {
                //naxkin dzevn e 
                var testEdus = (from elm in context.TestEdus
                                where elm.classNumber == classNumber && elm.subjectID == subjectID && elm.teacherID == teacherID
                                select elm).ToList();

                var testings = (from t in context.Testings
                                    //where t.teacherID == teacherID t.testEduID in ()
                                select t).ToList();


                var data = testEdus.GroupJoin(
                        testings, // второй набор
                        elm => elm.id, // свойство-селектор объекта из первого набора
                        t => t.testEduID, // свойство-селектор объекта из второго набора
                        (te, tt) => new  // результирующий объект
                        {
                            id = te.id,
                            classNumber = te.classNumber,
                            paragraph = te.paragraph,
                            subjectID = te.subjectID,
                            isEduStarted = te.isEduStarted,
                            password = te.password,
                            teacherID = te.teacherID,
                            cnt = tt.Count(),
                        });

                return Json(data);
            }

        }

        // END SELECT EDU

        // NEW EDU

        public IActionResult CreateTestEdu(TestEdu testEdu) // List<Question> newList
        {

            int? teacherID = HttpContext.Session.GetInt32("teacher");
            int? schoolID = HttpContext.Session.GetInt32("school");

            //List<Question> newList = new List<Question>();
            Question newquestion = new Question();


            if (teacherID == null)
            {
                return Json("not logge in");
            }
            else if (schoolID == null)
            {
                return Json("not school in");
            }
            else
            {
                TestEdu newTest = new TestEdu();
                newTest.classNumber = testEdu.classNumber;
                newTest.subjectID = testEdu.subjectID;
                newTest.paragraph = testEdu.paragraph;
                newTest.password = ""; // piti generacvi
                newTest.teacherID = (int)teacherID;
                newTest.schoolID = (int)schoolID;

                //testEdu.password = ""; // piti generacvi
                //testEdu.teacherID = (int)teacherID;

                context.TestEdus.Add(newTest);
                context.SaveChanges();

                var data = newTest;

                return Json(data);

            }

        }

        public IActionResult CreateQuestion(Question q) // List<Question> newList
        {

            int? teacherID = HttpContext.Session.GetInt32("teacher");

            //List<Question> newList = new List<Question>();


            if (teacherID == null)
            {
                return Json("not logge in");
            }
            else
            {
                Question newquestion = new Question();
                //list Question i hatvac
                newquestion.question = q.question;
                newquestion.answer1 = q.answer1;
                newquestion.answer2 = q.answer2;
                newquestion.answer3 = q.answer3;
                newquestion.answer4 = q.answer4;
                newquestion.timer = q.timer;
                newquestion.point = q.point;
                newquestion.trueAnswer = q.trueAnswer;
                newquestion.order = q.order;
                newquestion.testEduID = q.testEduID;

                //testEdu.password = ""; // piti generacvi
                //testEdu.teacherID = (int)teacherID;

                context.Questions.Add(newquestion);
                context.SaveChanges();

                var data = newquestion;

                return Json(data);

            }

        }

        // END NEW EDU


        // EDU

        public IActionResult CreateTestEduPassword(int id)
        {
            Random random = new Random();


            int? teacherID = HttpContext.Session.GetInt32("teacher");
            int? schoolID = HttpContext.Session.GetInt32("school");

            if (teacherID == null)
            {
                return Json("not logge in");
            }
            else if (id > 0)
            {
                var testEdu = (from elm in context.TestEdus where elm.teacherID == teacherID && elm.id == id select elm).FirstOrDefault(); // from TestEdu

                if (testEdu == null) // minchev return durs e galis ?
                {
                    return Json("chka test edu");
                }

                var randomPassword = random.Next(10000, 99000).ToString();
                testEdu.password = randomPassword;

                Testing testing = new Testing();
                testing.testEduID = id;
                testing.teacherID = (int)teacherID;
                testing.testingDate = DateTime.Today;
                testing.password = testEdu.password;
                testing.schoolID = (int)schoolID;
                testing.description = "popoxman entaka che";

                context.Testings.Add(testing); // avelacnum e nor Testings tox trvac tvyalnerov;
                context.SaveChanges(); // chi ashxatum

                var data = new { randomPassword = randomPassword, testingEduID = testing.testEduID, testingID = testing.id };
                return Json(data);
            }


            return Json("");
        }


        public IActionResult SelectEduPassword(int id)
        {
            int? teacherID = HttpContext.Session.GetInt32("teacher");

            var testEdu = (
                from t in context.Testings
                where t.id == id
                from te in context.TestEdus
                where te.teacherID == teacherID && te.id == t.testEduID
                select te ).FirstOrDefault();

            return Json(testEdu);
        }



        public IActionResult SelectEduQuestions(int id)
        {
            int? teacherID = HttpContext.Session.GetInt32("teacher");

            var data = (
                        from t in context.Testings
                        where t.id == id //&& t.teacherID == teacherID
                        from te in context.TestEdus
                        where te.teacherID == teacherID && te.id == t.testEduID
                        from q in context.Questions
                        where q.testEduID == t.testEduID
                        orderby q.order
                        select q).ToList();

            return Json(data);
        }



        // stugum e ardyoq edu-n sksvel e, te voch , eta ayo apa  isEduStarted = 1;
        public IActionResult OrderStartEdu(int id, string classGroup)
        {
            int? teacherID = HttpContext.Session.GetInt32("teacher");

            if (teacherID == null)
            {
                return Json("not logged in");
            }
            else
            {
                var testing = (
                    from t in context.Testings
                    where t.id == id
                    select t).FirstOrDefault();
               

                if (testing == null)
                {
                    return Json("no test found");
                }
                else
                {
                    var testEdu = (
                       from elm in context.TestEdus
                       where elm.teacherID == teacherID && elm.id == testing.testEduID
                       select elm).FirstOrDefault();
                    if (testEdu == null)
                    {
                        return Json("no test found");
                    }
                    testEdu.isEduStarted = 1;
                    testing.classGroup = classGroup;
                    context.SaveChanges();

                    return Json(true);

                }
            }


        }

        // END EDU

        // EDIT EDU 


        public IActionResult UpdateTestEdu(TestEdu testEdu)
        {

            int? teacherID = HttpContext.Session.GetInt32("author");

            if (teacherID == null)
            {
                return Json("not logge in");
            }
            else
            {

                if (teacherID == testEdu.teacherID)
                {
                    TestEdu newTest = new TestEdu();
                    newTest.id = testEdu.id;
                    newTest.classNumber = testEdu.classNumber;
                    newTest.subjectID = testEdu.subjectID;
                    newTest.paragraph = testEdu.paragraph;
                    newTest.password = ""; // piti generacvi
                    newTest.teacherID = testEdu.teacherID;

                    //testEdu.password = ""; // piti generacvi
                    //testEdu.authorID = (int)authorID;

                    context.TestEdus.Update(newTest);
                    context.SaveChanges();


                    List<Question> questions = (from elm in context.Questions where elm.testEduID == testEdu.id select elm).ToList();

                    for (int i = 0; i < questions.Count; i++)
                    {
                        context.Questions.Remove(questions[i]);
                    }
                    context.SaveChanges();
                    return Json(newTest);
                }

            }

            return Json("");
        }


        public IActionResult getTestEdu(int id)
        {

            int? teacherID = HttpContext.Session.GetInt32("teacher");

            if (teacherID == null)
            {
                return Json("not logge in");
            }
            else
            {
                var testEdus = (from elm in context.TestEdus where elm.id == id && elm.teacherID == teacherID select elm).ToList();

                var questions = (from elm in context.Questions where elm.testEduID == id orderby elm.order select elm).ToList();


                var testing = (from elm in context.Testings where elm.testEduID == id && elm.teacherID == teacherID select elm).FirstOrDefault();
                bool isEduUsed = true;
                if (testing == null)
                {
                    isEduUsed = false;
                }

                var data = new { testEdus = testEdus, questions = questions, isEduUsed = isEduUsed };

                return Json(data);
            }

        }

        // END EDIT EDU

        // FINISH

        //veradarcnum e masnakicneri tvyalnerey kaxvac tvanshanneric
        public IActionResult GetFinishResult(int testingID)
        {

            int? teacherID = HttpContext.Session.GetInt32("teacher");

            if (teacherID == null)
            {
                //You are not logged in! Please log in & try again!
                return Json(new { loginErrorMessage = "notLoggedIn" });
            }

            var testing = (from t in context.Testings
                           where t.id == testingID && t.teacherID == teacherID
                           from te in context.TestEdus
                           where te.id == t.testEduID
                           from tch in context.Teachers
                           where tch.id == te.teacherID
                           select new { testing = t, testEdu = te, teacher = tch }).FirstOrDefault();

            if (testing == null)
            {
                return Json(new { testErrorMessage = "notFoundTesting" });
            }

            var dataQuestions = (from elm in context.Testings
                                 where elm.id == testingID && elm.teacherID == teacherID
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
                    where elm.testingID == testingID && elm.teacherID == teacherID
                    from st in context.Students
                    where st.id == elm.studentID
                    select st
                ).ToList();

            var testingResults = (
                    from elm in context.TestingResults
                    where elm.testingID == testingID && elm.teacherID == teacherID
                    select elm
                ).ToList();

            var data = new { dataTesting = testing, dataStudents = students, dataAnswers = answers, dataQuestions = dataQuestions, testingResults = testingResults };

            return Json(data);

        }

        // END FINISH

        // HISTORY EDU

        public IActionResult GetEdusHistory(string classNumber, int subjectID, string classGroup)
        {
            int? teacherID = HttpContext.Session.GetInt32("teacher");
            

            if (teacherID != null)
            {
                if (classGroup == null)
                {
                    classGroup = "";
                }
                var data = (
                        from testEdu in context.TestEdus
                        where testEdu.teacherID == teacherID && testEdu.classNumber == classNumber && testEdu.subjectID == subjectID
                        from testing in context.Testings
                        where testing.testEduID == testEdu.id && testing.classGroup.Contains(classGroup)
                        orderby testing.testingDate descending
                        select new { testing, testEdu }
                    ).ToList();

                return Json(data);
            }
            return Json("not logged in");
        }

        // END HISTORY EDU


        public IActionResult CleanEduPassword(int id)
        {
            int? teacherID = HttpContext.Session.GetInt32("teacher");

            var testEdu = (
                        from el in context.TestEdus
                        where el.id == id && el.teacherID == teacherID
                        select el).FirstOrDefault();

            if (testEdu != null)
            {
                testEdu.password = null;
                testEdu.isEduStarted = 0;
                context.SaveChanges();
                return Json("CleanEduPassword isn't  ok ");
            }
            return Json("TestEdu not found");
        }

        //Classes Info
        public IActionResult GetClassesInfo()
        {

            int? teacherID = HttpContext.Session.GetInt32("teacher");
            int? schoolID = HttpContext.Session.GetInt32("school");

            if (schoolID == null && teacherID == null)
            {
                return Json("notLoggedIn");
            }
            else
            {
                var teachers = (from elm in context.Teachers where elm.schoolID == schoolID select elm).ToList();

                var classes = (from elm in context.Classes
                               where elm.schoolID == schoolID && elm.teacherID == teacherID
                               select elm).ToList();

                var subjects = (from elm in context.Classes
                               where elm.schoolID == schoolID 
                               from sub in context.ClassNumberSubjects
                               where sub.classNumber == elm.classNumber
                               from s in context.Subjects 
                               where s.id == sub.subjectID
                               select s.name).ToList();

                var teachersSubjects = (from elm in context.ClassSubjectsTeachers
                                        where elm.schoolID == schoolID
                                        select elm).ToList();

                var data = new { classes = classes, teachers = teachers, subjects = subjects, teachersSubjects = teachersSubjects };


                return Json(data);
            }

        }
        //END Classes Info

        //Class Teacher Subject
        public IActionResult AddClassTeacherSubject(int classesID, int subjectID, int teacherID)
        {
            int? teacherID_s = HttpContext.Session.GetInt32("teacher");
            int? schoolID = HttpContext.Session.GetInt32("school");

            if (schoolID == null && teacherID_s == null)
            {
                return Json("notLoggedIn");
            }
            else
            {
                ClassSubjectsTeachers subjectsTeachers = new ClassSubjectsTeachers();
                subjectsTeachers.classesID = classesID;
                subjectsTeachers.subjectID = subjectID;
                subjectsTeachers.teacherID = teacherID;
                subjectsTeachers.schoolID = (int)schoolID;

                context.ClassSubjectsTeachers.Add(subjectsTeachers);
                context.SaveChanges();

                return Json(subjectsTeachers);
            }
        }
        //END Class Teacher Subject


        // Delete Teacher Subject
        public IActionResult DeleteTeacherSubject()
        {
            return Json("");
        }
        //AND Delete Teacher Subject

        // Update Teacher Subject
        public IActionResult UpdateTeacherSubject()
        {
            return Json("");
        }
        //AND Update Teacher Subject

    }
}
