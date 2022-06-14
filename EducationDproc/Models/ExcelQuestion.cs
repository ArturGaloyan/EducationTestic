using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationDproc.Models
{
    public class ExcelQuestion
    {
        //public string classNumber { get; set; } = "";
        //public string subject { get; set; } = "";
        //public string paragraph { get; set; } = "";

        public string question { get; set; } = "";

        public string answer1 { get; set; } = "";
        public string answer2 { get; set; } = "";
        public string answer3 { get; set; } = "";
        public string answer4 { get; set; } = "";

        public string trueAnswer { get; set; } = "";

        public string point { get; set; } = "";
        public string timer { get; set; } = "";

    }
}
