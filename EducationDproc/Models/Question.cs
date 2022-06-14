using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationDproc.Models
{
    public class Question
    {
        [Key]
        public int id { get; set; }
        public int timer { get; set; }
        public int point { get; set; }
        public string question { get; set; }
        public string answer1 { get; set; }
        public string answer2 { get; set; }
        public string answer3 { get; set; }
        public string answer4 { get; set; }
        public int order { get; set; }

        public string trueAnswer { get; set; }

        public int testEduID { get; set; }

        public TestEdu testEdu { get; set; }

        // inchpes avelacnel:  or.` ays class-um nor dasht ev migracia anel , vor sql table-um avelana nor hamapatasxan syunak

        //Add - Migration
        // Name  isStart     ?
        //Update - Database
    }
}
