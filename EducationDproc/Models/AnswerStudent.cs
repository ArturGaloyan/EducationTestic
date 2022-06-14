using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationDproc.Models
{
    public class AnswerStudent
    {
        [Key]
        public int id { get; set; }
        public int answer { get; set; } // -1,0,1,2,3
        public int isTrue { get; set; }
        public int point { get; set; }

        public int studentID { get; set; }
        public int questionID { get; set; }
        public int testingID { get; set; }

        public Student student { get; set; }
        public Question question { get; set; }
        public Testing testing { get; set; }

    }
}
