using EducationDproc.Models;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EducationDproc.Controllers
{
    public class ExcelController : Controller
    {
        [HttpPost]
        public IActionResult GetExcelData(IFormFile file, [FromServices] IWebHostEnvironment hostingEnvironment)
        {

            // full path to file in temp location
            if (file.Length > 0)
            {
                if (file.ContentType == "application/vnd.ms-excel" || file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    using (var fileStream = file.OpenReadStream())
                    {
                        List<ExcelQuestion> excel_question = new List<ExcelQuestion>();
                        using (var reader = ExcelReaderFactory.CreateReader(fileStream))
                        {
                            int i = 0;

                            while (reader.Read())
                            {

                                if (reader.GetValue(0) != null && reader.GetValue(0).ToString() != "")
                                {
                                    excel_question.Add(new ExcelQuestion());
                                    i = excel_question.Count();


                                    excel_question[i - 1].question = reader.GetValue(0).ToString();


                                    if (reader.GetValue(1) != null && reader.GetValue(1).ToString() != "")
                                    {
                                        excel_question[i - 1].answer1 = reader.GetValue(1).ToString();
                                    }
                                    if (reader.GetValue(2) != null && reader.GetValue(2).ToString() != "")
                                    {
                                        excel_question[i - 1].answer2 = reader.GetValue(2).ToString();
                                    }

                                    if (reader.GetValue(3) != null && reader.GetValue(3).ToString() != "")
                                    {
                                        excel_question[i - 1].answer3 = reader.GetValue(3).ToString();
                                    }

                                    if (reader.GetValue(4) != null && reader.GetValue(4).ToString() != "")
                                    {
                                        excel_question[i - 1].answer4 = reader.GetValue(4).ToString();
                                    }

                                    if (reader.GetValue(5) != null && reader.GetValue(5).ToString() != "")
                                    {
                                        excel_question[i - 1].trueAnswer = reader.GetValue(5).ToString();
                                    }

                                    if (reader.GetValue(6) != null && reader.GetValue(6).ToString() != "")
                                    {
                                        excel_question[i - 1].point = reader.GetValue(6).ToString();
                                    }

                                    if (reader.GetValue(7) != null && reader.GetValue(7).ToString() != "")
                                    {
                                        excel_question[i - 1].timer = reader.GetValue(7).ToString();
                                    }
                                }


                            }
                            fileStream.Close();
                            return Json(new { excel_question = excel_question });
                        }
                    }
                }
                return Json("Bad File format");
            }

            return Json("no file");
        }


        //[HttpPost]
        //public IActionResult GetExcelData(IFormFile file, [FromServices] IWebHostEnvironment hostingEnvironment)
        //{

        //    // full path to file in temp location
        //    if (file.Length > 0)
        //    {
        //        if (file.ContentType == "application/vnd.ms-excel" || file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        //        {
        //            string filePath = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";

        //            if (System.IO.File.Exists(filePath))
        //            {
        //                System.IO.File.Delete(filePath);// delete file
        //            }

        //            using (var fileStream = System.IO.File.Create(filePath))
        //            {
        //                file.CopyToAsync(fileStream);
        //                fileStream.Flush(); // save file
        //                fileStream.Close();
        //            }


        //            List<ExcelQuestion> excel_question = new List<ExcelQuestion>();

        //            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + file.FileName;
        //            if (System.IO.File.Exists(fileName))
        //            {
        //                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        //                using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
        //                {
        //                    using (var reader = ExcelReaderFactory.CreateReader(stream))
        //                    {
        //                        int i = 0;

        //                        while (reader.Read())
        //                        {

        //                            if (reader.GetValue(3) != null && reader.GetValue(3).ToString() != "")
        //                            {
        //                                excel_question.Add(new ExcelQuestion());
        //                                i = excel_question.Count();


        //                                excel_question[i - 1].question = reader.GetValue(3).ToString();


        //                                if (reader.GetValue(4) != null && reader.GetValue(4).ToString() != "")
        //                                {
        //                                    excel_question[i - 1].answer1 = reader.GetValue(4).ToString();
        //                                }
        //                                if (reader.GetValue(5) != null && reader.GetValue(5).ToString() != "")
        //                                {
        //                                    excel_question[i - 1].answer2 = reader.GetValue(5).ToString();
        //                                }

        //                                if (reader.GetValue(6) != null && reader.GetValue(6).ToString() != "")
        //                                {
        //                                    excel_question[i - 1].answer3 = reader.GetValue(6).ToString();
        //                                }

        //                                if (reader.GetValue(7) != null && reader.GetValue(7).ToString() != "")
        //                                {
        //                                    excel_question[i - 1].answer4 = reader.GetValue(7).ToString();
        //                                }

        //                                if (reader.GetValue(8) != null && reader.GetValue(8).ToString() != "")
        //                                {
        //                                    excel_question[i - 1].trueAnswer = reader.GetValue(8).ToString();
        //                                }

        //                                if (reader.GetValue(9) != null && reader.GetValue(9).ToString() != "")
        //                                {
        //                                    excel_question[i - 1].point = reader.GetValue(9).ToString();
        //                                }

        //                                if (reader.GetValue(10) != null && reader.GetValue(10).ToString() != "")
        //                                {
        //                                    excel_question[i - 1].timer = reader.GetValue(10).ToString();
        //                                }
        //                            }


        //                        }
        //                    }
        //                    stream.Close();
        //                }



        //                System.IO.File.Delete(fileName);// delete file
        //                return Json(new { filePath = filePath, excel_question = excel_question, fileName = fileName });
        //                // This path is a file
        //            }
        //            return Json("file not exists");
        //        }
        //        return Json("Bad File format");
        //    }

        //    return Json("no file");
        //}
    }
}
